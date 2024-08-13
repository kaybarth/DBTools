
namespace DBTools
{
    partial class DataEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataEntry));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCopyHost = new System.Windows.Forms.PictureBox();
            this.btnCopyUser = new System.Windows.Forms.PictureBox();
            this.btnCopyPassword = new System.Windows.Forms.PictureBox();
            this.btnSaveHost = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(86, 66);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(185, 20);
            this.txtIp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(86, 110);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(185, 20);
            this.txtPort.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Puerto";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(86, 150);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 20);
            this.txtUser.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Usuario";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(86, 198);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Clave";
            // 
            // btnCopyHost
            // 
            this.btnCopyHost.Image = global::DBTools.Properties.Resources.copyIcon;
            this.btnCopyHost.Location = new System.Drawing.Point(287, 66);
            this.btnCopyHost.Name = "btnCopyHost";
            this.btnCopyHost.Size = new System.Drawing.Size(29, 31);
            this.btnCopyHost.TabIndex = 10;
            this.btnCopyHost.TabStop = false;
            this.btnCopyHost.Click += new System.EventHandler(this.btnCopyHost_Click);
            // 
            // btnCopyUser
            // 
            this.btnCopyUser.Image = global::DBTools.Properties.Resources.copyIcon;
            this.btnCopyUser.Location = new System.Drawing.Point(287, 150);
            this.btnCopyUser.Name = "btnCopyUser";
            this.btnCopyUser.Size = new System.Drawing.Size(29, 31);
            this.btnCopyUser.TabIndex = 11;
            this.btnCopyUser.TabStop = false;
            this.btnCopyUser.Click += new System.EventHandler(this.btnCopyUser_Click_1);
            // 
            // btnCopyPassword
            // 
            this.btnCopyPassword.Image = global::DBTools.Properties.Resources.copyIcon;
            this.btnCopyPassword.Location = new System.Drawing.Point(287, 198);
            this.btnCopyPassword.Name = "btnCopyPassword";
            this.btnCopyPassword.Size = new System.Drawing.Size(29, 31);
            this.btnCopyPassword.TabIndex = 12;
            this.btnCopyPassword.TabStop = false;
            // 
            // btnSaveHost
            // 
            this.btnSaveHost.Location = new System.Drawing.Point(196, 236);
            this.btnSaveHost.Name = "btnSaveHost";
            this.btnSaveHost.Size = new System.Drawing.Size(75, 23);
            this.btnSaveHost.TabIndex = 13;
            this.btnSaveHost.Text = "Guardar";
            this.btnSaveHost.UseVisualStyleBackColor = true;
            this.btnSaveHost.Click += new System.EventHandler(this.btnSaveHost_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(86, 236);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(104, 23);
            this.btnTestConnection.TabIndex = 14;
            this.btnTestConnection.Text = "Probar conexion";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click_1);
            // 
            // DataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 308);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnSaveHost);
            this.Controls.Add(this.btnCopyPassword);
            this.Controls.Add(this.btnCopyUser);
            this.Controls.Add(this.btnCopyHost);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataEntry";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.DataEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox btnCopyHost;
        private System.Windows.Forms.PictureBox btnCopyUser;
        private System.Windows.Forms.PictureBox btnCopyPassword;
        private System.Windows.Forms.Button btnSaveHost;
        private System.Windows.Forms.Button btnTestConnection;
    }
}