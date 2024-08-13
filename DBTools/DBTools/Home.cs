using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBTools
{
    public partial class Home : Form
    {
        private List<Servers> serversList = new List<Servers>();
        private ContextMenuStrip serverMenu;
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            // Cargar servidores al iniciar la aplicación
            serversList = Servers.LoadServers();

            // Agrega accion de doble click al item
            connectionsList.DoubleClick += connectionsList_DoubleClick;
            connectionsList.MouseClick  += connectionsList_MouseClick;
            connectionsList.SmallImageList = smallIconList;
            connectionsList.LargeImageList = largeIconsList;

            // Crea el menu contextual del servidor
            serverMenu = new ContextMenuStrip();
            serverMenu.Items.Add("Editar",          null, Editar_Click);
            serverMenu.Items.Add("Eliminar",        null, Eliminar_Click);
            serverMenu.Items.Add("Detalles",        null, Detail_Click);
            serverMenu.Items.Add("Probar conexión", null, TestConnection_Click);

            connectionsList.Columns.Add("Server Name", 200);
            connectionsList.Columns.Add("Server Ip", 100);
            connectionsList.Columns.Add("Server Port", 50);

            // Mostrar los servidores en el ListView
            foreach (Servers server in serversList)
            {
                Servers ServerItem = new Servers(server.Id);
                // Agrega el objeto al listview
                displayServerIcon(server);
            }
        }
        private void displayServerIcon(Servers server)
        {
            ListViewItem newItem = new ListViewItem(server.Name, "db");
            newItem.SubItems.Add(server.Ip);
            newItem.SubItems.Add(server.Port);
            newItem.Tag = server;
            // Agrega el objeto al listview
            connectionsList.Items.Add(newItem);
            _ = UpdateConnectionStatus(newItem);
        }

        public async Task UpdateConnectionStatus(ListViewItem item)
        {
            item.ImageKey = "db";
            var server = (Servers)item.Tag;
            var response = await Servers.TestConnection(server);
            string img = response.status ? "db_ok" : "db_error";
            item.ImageKey = img;
            server.ConnectionStatus = response.status;
            item.Tag = server;
        }
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servers.Save(serversList);
        }
        private void btnSaveConnection_Click(object sender, EventArgs e)
        {
            DataEntry entryForm = new DataEntry();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                Servers itemData = entryForm.ServerItem;
                if (itemData != null)
                {
                    addConnection(itemData);
                }
            }
        }
        private void addConnection(Servers server)
        {
            serversList.Add(server);
            Servers.Save(serversList);
            displayServerIcon(server);
        }
        private void connectionsList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selectedItem = connectionsList.HitTest(e.Location)?.Item;
                if (selectedItem != null)
                {
                    serverMenu.Show(connectionsList, e.Location);
                }
            }
        }
        private void connectionsList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = connectionsList.SelectedItems[0];
            if (((Servers)selectedItem.Tag).ConnectionStatus == false )
            {
                MessageBox.Show("No hay conexión con el servidor, no es posible iniciar SQL management studio", "Error de conexión");
                return;
            }
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.managementRoute))
            {
                MessageBox.Show("La ruta de SQL Server Management Studio no esta configurada", "Error");
                return;
            }
            DialogResult result = MessageBox.Show("¿Iniciar conexión con SQL management studio?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Verificar si se ha seleccionado un elemento
            if (connectionsList.SelectedItems.Count > 0 && result == DialogResult.Yes)
            {
                Servers server = serversList.Find(s => s.Name == selectedItem.Text);
                StartSSMS(server.Ip, server.Port, server.User, server.Password);
            }
        }

        public void StartSSMS(string server, string port, string userId, string password)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(port))
                {
                    server = server + "," + port;
                }
                string ManagementRoute = Properties.Settings.Default.managementRoute;
                string arguments = $"-S {server} -d master -U {userId}";
                Process.Start(ManagementRoute, arguments);
                Clipboard.SetText(password);

                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                //toolTip.IsBalloon = true;
                int x = this.ClientSize.Width / 2;
                int y = this.ClientSize.Height / 2;

                // Ajusta la posición para que el ToolTip se muestre en el medio
                // del formulario
                Point screenPoint = this.PointToScreen(new Point(x, y));
                toolTip.ToolTipTitle = "Mensaje";
                toolTip.Show("Clave copiada al portapapeles", this, x, y, 1500);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar SQL Server Management Studio: " + ex.Message, "Error");
            }
        }

        private void TestConnection_Click(object sender, EventArgs e)
        {
            if (connectionsList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = connectionsList.SelectedItems[0];
                _ = UpdateConnectionStatus(selectedItem);
            }
        }
        private void Editar_Click(object sender, EventArgs e)
        {
            // Lógica para editar el elemento seleccionado
            if (connectionsList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = connectionsList.SelectedItems[0];
                Servers server = (Servers)selectedItem.Tag;
                Servers actualServer = serversList.Find(s => s.Id == server.Id);
                DataEntry entryForm = new DataEntry(actualServer);
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    Servers itemData = entryForm.ServerItem;
                    addConnection(itemData);
                }
            }
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro eliminar este servidor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (connectionsList.SelectedItems.Count > 0 && result == DialogResult.Yes)
            {
                ListViewItem selectedItem = connectionsList.SelectedItems[0];
                Servers server = (Servers)selectedItem.Tag;

                Servers serverToDelete = serversList.Find(s => s.Id == server.Id);
                serversList.Remove(serverToDelete);
                connectionsList.Items.Remove(selectedItem);
            }
        }
        private void Detail_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar detalles del elemento seleccionado
            if (connectionsList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = connectionsList.SelectedItems[0];
                Servers server = (Servers)selectedItem.Tag;
                Servers actualServer = serversList.Find(s => s.Id == server.Id);
                DataEntry entryForm = new DataEntry(actualServer, "ver");
                entryForm.Show();
            }
        }
        private void connectionsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnImportConections_Click(object sender, EventArgs e)
        {
            if (importCSVConnections.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionada
                string filePath = importCSVConnections.FileName;
                // Leer y procesar el archivo CSV
                ProcessCsvFile(filePath);
            }
        }
        private void ProcessCsvFile(string filePath)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    // Leer la primera línea para obtener los títulos de las columnas
                    string[] columnTitles = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        // Dividir la línea en columnas
                        string[] values = parser.ReadFields();
                        // Crear un diccionario para almacenar los valores de las columnas
                        var columnValues = new Dictionary<string, string>();
                        // Procesar cada columna
                        for (int i = 0; i < values.Length; i++)
                        {
                            columnValues[columnTitles[i]] = values[i];
                        }
                        // Verificar que los campos requeridos estén presentes
                        if (columnValues.TryGetValue("Name", out string name) && !string.IsNullOrWhiteSpace(name) &&
                            columnValues.TryGetValue("Ip", out string host) && !string.IsNullOrWhiteSpace(host) &&
                            columnValues.TryGetValue("User", out string username) && !string.IsNullOrWhiteSpace(username) &&
                            columnValues.TryGetValue("Password", out string password) && !string.IsNullOrWhiteSpace(password))
                        {
                            string port = columnValues.TryGetValue("Port", out string p) ? p : "";

                            // Verificar si el objeto con la combinación de host y port ya existe
                            if (!serversList.Exists(s => s.Ip == host && s.Port == port))
                            {
                                // Crear el objeto Servers usando los valores del diccionario
                                Servers server = new Servers(name, host, port, username, password);
                                addConnection(server);
                            }
                            else
                            {
                                Servers server = serversList.Find(s => s.Ip == host && s.Port == port);
                                MessageBox.Show($"La conexión {server.Name}:{server.Ip},{server.Port} ya se encuentra registrada", "Conexión ya registrada");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo CSV: " + ex.Message);
            }
        }
        private void btnConfigManagement_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.managementRoute))
            {
                DialogResult result = MessageBox.Show($"Ruta actual {Properties.Settings.Default.managementRoute}, deseas actualizarla?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No || result == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (setManagementRoute.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionada
                string filePath = setManagementRoute.FileName;
                Properties.Settings.Default.managementRoute = filePath;
                Properties.Settings.Default.Save();
                MessageBox.Show("Ruta actualizada correctamente.");
            }
        }

        private void exportarCSV_Click(object sender, EventArgs e)
        {
            var csv = new StringBuilder();

            var properties = typeof(Servers).GetProperties();
            var excludedProperties = new List<string> { "Id", "ConnectionStatus" };

            var filteredProperties = properties.Where(p => !excludedProperties.Contains(p.Name));
            csv.AppendLine(string.Join(",", filteredProperties.Select(p => p.Name)));

            // Filtrar y agregar los valores de cada objeto
            foreach (var item in serversList)
            {
                var values = filteredProperties.Select(p => p.GetValue(item)?.ToString() ?? string.Empty);
                csv.AppendLine(string.Join(",", values));
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Guardar conexiones";
            saveFileDialog.Filter = "Delimitado por comas (*.csv)|*.csv";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Mostrar el diálogo y obtener el resultado
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, csv.ToString());
                MessageBox.Show("Conexiones exportadas correctamente");
            }
        }

        private void view_list_Click(object sender, EventArgs e)
        {
            connectionsList.View = View.Details;
            checkAllConnections();
        }

        private void view_icon_Click(object sender, EventArgs e)
        {
            connectionsList.View = View.LargeIcon;
            checkAllConnections();
        }
        private void checkAllConnections()
        {
            foreach (ListViewItem item in connectionsList.Items)
            {
                _ = UpdateConnectionStatus(item);
            }

        }
    }
}
