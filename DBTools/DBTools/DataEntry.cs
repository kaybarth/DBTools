using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                txtName.Text        = ServerItem.Name;
                txtIp.Text          = ServerItem.Ip;
                txtPort.Text        = ServerItem.Port;
                txtUser.Text        = ServerItem.User;
                txtPassword.Text    = ServerItem.Password;

                if (accion == "ver")
                {
                    var textboxes = new TextBox[] { txtName, txtIp, txtPort, txtUser, txtPassword };
                    foreach (var textbox in textboxes) { textbox.ReadOnly = true; }
                }
            }
        }
        private void DataEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveHost_Click(object sender, EventArgs e)
        {
            var missingFields = new List<string>();
            string PortPattern = @"\d{4}$";

            string name     = txtName.Text;
            string ip       = txtIp.Text;
            string port     = txtPort.Text;
            string user     = txtUser.Text;
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
                ServerItem.Name     = txtName.Text;
                ServerItem.Ip       = txtIp.Text;
                ServerItem.Port     = txtPort.Text;
                ServerItem.User     = txtUser.Text;
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
                fullServer += ":" + txtPort.Text;
            }
            Clipboard.SetText(fullServer);
            toolTip.Show("Copied to clipboard", btnCopyHost, 2000);
            toolTip.Hide(btnCopyHost);
        }
    }
}
