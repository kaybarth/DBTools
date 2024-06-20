
namespace DBTools
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.connectionsList = new System.Windows.Forms.ListView();
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.OptionBarOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImportConections = new System.Windows.Forms.ToolStripMenuItem();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.importCSVConnections = new System.Windows.Forms.OpenFileDialog();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfigManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.setManagementRoute = new System.Windows.Forms.OpenFileDialog();
            this.topMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionsList
            // 
            this.connectionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionsList.HideSelection = false;
            this.connectionsList.Location = new System.Drawing.Point(0, 24);
            this.connectionsList.Name = "connectionsList";
            this.connectionsList.Size = new System.Drawing.Size(800, 426);
            this.connectionsList.TabIndex = 0;
            this.connectionsList.UseCompatibleStateImageBehavior = false;
            this.connectionsList.SelectedIndexChanged += new System.EventHandler(this.connectionsList_SelectedIndexChanged);
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionBarOptions,
            this.configuracionesToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(800, 24);
            this.topMenu.TabIndex = 1;
            this.topMenu.Text = "menuStrip1";
            // 
            // OptionBarOptions
            // 
            this.OptionBarOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveConnection,
            this.btnImportConections});
            this.OptionBarOptions.Name = "OptionBarOptions";
            this.OptionBarOptions.Size = new System.Drawing.Size(81, 20);
            this.OptionBarOptions.Text = "Conexiones";
            // 
            // btnSaveConnection
            // 
            this.btnSaveConnection.Name = "btnSaveConnection";
            this.btnSaveConnection.Size = new System.Drawing.Size(183, 22);
            this.btnSaveConnection.Text = "Agregar conexion";
            this.btnSaveConnection.Click += new System.EventHandler(this.btnSaveConnection_Click);
            // 
            // btnImportConections
            // 
            this.btnImportConections.Name = "btnImportConections";
            this.btnImportConections.Size = new System.Drawing.Size(183, 22);
            this.btnImportConections.Text = "Importar conexiones";
            this.btnImportConections.Click += new System.EventHandler(this.btnImportConections_Click);
            // 
            // iconsList
            // 
            this.iconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsList.ImageStream")));
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsList.Images.SetKeyName(0, "db");
            this.iconsList.Images.SetKeyName(1, "db_ok");
            this.iconsList.Images.SetKeyName(2, "db_error");
            // 
            // importCSVConnections
            // 
            this.importCSVConnections.Filter = "CSV|*.csv";
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfigManagement});
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // btnConfigManagement
            // 
            this.btnConfigManagement.Name = "btnConfigManagement";
            this.btnConfigManagement.Size = new System.Drawing.Size(180, 22);
            this.btnConfigManagement.Text = "Ruta Managment";
            this.btnConfigManagement.Click += new System.EventHandler(this.btnConfigManagement_Click);
            // 
            // setManagementRoute
            // 
            this.setManagementRoute.FileName = "Ssms";
            this.setManagementRoute.Filter = "Ssms.exe|Ssms.exe";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connectionsList);
            this.Controls.Add(this.topMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenu;
            this.Name = "Home";
            this.Text = "DBTools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.Load += new System.EventHandler(this.Home_Load);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView connectionsList;
        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem OptionBarOptions;
        private System.Windows.Forms.ToolStripMenuItem btnSaveConnection;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.ToolStripMenuItem btnImportConections;
        private System.Windows.Forms.OpenFileDialog importCSVConnections;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnConfigManagement;
        private System.Windows.Forms.OpenFileDialog setManagementRoute;
    }
}

