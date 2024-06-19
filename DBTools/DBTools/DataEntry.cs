using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DBTools
{
    public partial class DataEntry : Form
    {
        private ToolTip toolTip;
        public Servers ServerItem { get; private set; }
        public string accion = null;
        public DataEntry(Servers server = null, string Accion = null)
        {
            InitializeComponent();
            ServerItem = server;
            accion = Accion;
            InitializeControls();
        }

        private void InitializeControls()
        {
            toolTip = new ToolTip();
            if (ServerItem != null)
            {
                txtName.Text = ServerItem.Name;
                txtIp.Text = ServerItem.Ip;
                txtPort.Text = ServerItem.Port;
                txtUser.Text = ServerItem.User;
                txtPassword.Text = ServerItem.Password;

                if (accion == "ver")
                {
                    var textboxes = new TextBox[] { txtName, txtIp, txtPort, txtUser, txtPassword };
                    foreach (var textbox in textboxes) { textbox.ReadOnly = true; }
                }
            }
            else
            {
                btnCopyHost.Visible = false;
                btnCopyPassword.Visible = false;
                btnCopyUser.Visible = false;
            }
        }
        private void DataEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveHost_Click(object sender, EventArgs e)
        {
            var missingFields = new List<string>();
            string PortPattern = @"\d{4}$";

            string name = txtName.Text;
            string ip = txtIp.Text;
            string port = txtPort.Text;
            string user = txtUser.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                missingFields.Add("Name");
            }
            if (string.IsNullOrWhiteSpace(ip))
            {
                missingFields.Add("IP");
            }
            if (string.IsNullOrWhiteSpace(user))
            {
                missingFields.Add("User");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                missingFields.Add("Password");
            }

            if (missingFields.Any())
            {
                string missingFieldsMessage = string.Join(", ", missingFields);
                MessageBox.Show($"Debes llenar los siguientes campos para continuar: {missingFieldsMessage}");
                return;
            }
            if (ServerItem != null)
            {
                ServerItem.Name = txtName.Text;
                ServerItem.Ip = txtIp.Text;
                ServerItem.Port = txtPort.Text;
                ServerItem.User = txtUser.Text;
                ServerItem.Password = txtPassword.Text;
            }
            else
            {
                ServerItem = new Servers(name, ip, port, user, password);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCopyHost_Click(object sender, EventArgs e)
        {
            string fullServer = txtIp.Text;
            if (string.IsNullOrWhiteSpace(txtIp.Text))
            {
                toolTip.Show("No hay nada que copiar", btnCopyHost, 2000);
                toolTip.Hide(btnCopyHost);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtPort.Text))
            {
                fullServer += "," + txtPort.Text;
            }
            Clipboard.SetText(fullServer);
            toolTip.Show("Copied to clipboard", btnCopyHost, 2000);
            toolTip.Hide(btnCopyHost);
        }

        private void btnCopyUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                toolTip.Show("No hay nada que copiar", btnCopyUser, 2000);
                toolTip.Hide(btnCopyUser);
                return;
            }
            Clipboard.SetText(txtUser.Text);
            toolTip.Show("Copied to clipboard", btnCopyUser, 2000);
            toolTip.Hide(btnCopyUser);
        }

        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                toolTip.Show("No hay nada que copiar", btnCopyPassword, 2000);
                toolTip.Hide(btnCopyPassword);
                return;
            }
            Clipboard.SetText(txtPassword.Text);
            toolTip.Show("Copied to clipboard", btnCopyPassword, 2000);
            toolTip.Hide(btnCopyPassword);
        }

        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            Servers testServer = new Servers(txtName.Text, txtIp.Text, txtPort.Text, txtUser.Text, txtPassword.Text);

            var response = await Servers.TestConnection(testServer);
            if (response.status)
            {
                MessageBox.Show("Conexión exitosa", "Conexión exitosa");
            }
            else
            {
                MessageBox.Show($"{response.msj}", "Error de conexión");
            }
            testServer = null;
        }
    }
}
