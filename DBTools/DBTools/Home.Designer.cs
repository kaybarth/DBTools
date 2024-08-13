
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Ejemplo 1", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.connectionsList = new System.Windows.Forms.ListView();
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.OptionBarOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImportConections = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfigManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsList = new System.Windows.Forms.ImageList(this.components);
            this.importCSVConnections = new System.Windows.Forms.OpenFileDialog();
            this.setManagementRoute = new System.Windows.Forms.OpenFileDialog();
            this.exportarCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.vistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view_list = new System.Windows.Forms.ToolStripMenuItem();
            this.view_icon = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconList = new System.Windows.Forms.ImageList(this.components);
            this.topMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionsList
            // 
            this.connectionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Ejemplo 1";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup1.Tag = "dgetw";
            this.connectionsList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.connectionsList.HideSelection = false;
            this.connectionsList.Location = new System.Drawing.Point(0, 24);
            this.connectionsList.Name = "connectionsList";
            this.connectionsList.Size = new System.Drawing.Size(800, 426);
            this.connectionsList.TabIndex = 0;
            this.connectionsList.UseCompatibleStateImageBehavior = false;
            this.connectionsList.View = System.Windows.Forms.View.Details;
            this.connectionsList.SelectedIndexChanged += new System.EventHandler(this.connectionsList_SelectedIndexChanged);
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionBarOptions,
            this.configuracionesToolStripMenuItem,
            this.vistaToolStripMenuItem});
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
            this.btnImportConections,
            this.exportarCSV});
            this.OptionBarOptions.Name = "OptionBarOptions";
            this.OptionBarOptions.Size = new System.Drawing.Size(81, 20);
            this.OptionBarOptions.Text = "Conexiones";
            // 
            // btnSaveConnection
            // 
            this.btnSaveConnection.Name = "btnSaveConnection";
            this.btnSaveConnection.Size = new System.Drawing.Size(180, 22);
            this.btnSaveConnection.Text = "Agregar";
            this.btnSaveConnection.Click += new System.EventHandler(this.btnSaveConnection_Click);
            // 
            // btnImportConections
            // 
            this.btnImportConections.Name = "btnImportConections";
            this.btnImportConections.Size = new System.Drawing.Size(180, 22);
            this.btnImportConections.Text = "Importar";
            this.btnImportConections.Click += new System.EventHandler(this.btnImportConections_Click);
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
            // largeIconsList
            // 
            this.largeIconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeIconsList.ImageStream")));
            this.largeIconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeIconsList.Images.SetKeyName(0, "db");
            this.largeIconsList.Images.SetKeyName(1, "db_ok");
            this.largeIconsList.Images.SetKeyName(2, "db_error");
            // 
            // importCSVConnections
            // 
            this.importCSVConnections.Filter = "CSV|*.csv";
            // 
            // setManagementRoute
            // 
            this.setManagementRoute.FileName = "Ssms";
            this.setManagementRoute.Filter = "Ssms.exe|Ssms.exe";
            // 
            // exportarCSV
            // 
            this.exportarCSV.Name = "exportarCSV";
            this.exportarCSV.Size = new System.Drawing.Size(180, 22);
            this.exportarCSV.Text = "Exportar";
            this.exportarCSV.Click += new System.EventHandler(this.exportarCSV_Click);
            // 
            // vistaToolStripMenuItem
            // 
            this.vistaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.view_list,
            this.view_icon});
            this.vistaToolStripMenuItem.Name = "vistaToolStripMenuItem";
            this.vistaToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.vistaToolStripMenuItem.Text = "Vista";
            // 
            // view_list
            // 
            this.view_list.Name = "view_list";
            this.view_list.Size = new System.Drawing.Size(180, 22);
            this.view_list.Text = "Lista";
            this.view_list.Click += new System.EventHandler(this.view_list_Click);
            // 
            // view_icon
            // 
            this.view_icon.Name = "view_icon";
            this.view_icon.Size = new System.Drawing.Size(180, 22);
            this.view_icon.Text = "Iconos";
            this.view_icon.Click += new System.EventHandler(this.view_icon_Click);
            // 
            // smallIconList
            // 
            this.smallIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallIconList.ImageStream")));
            this.smallIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallIconList.Images.SetKeyName(0, "db_ok");
            this.smallIconList.Images.SetKeyName(1, "db_error");
            this.smallIconList.Images.SetKeyName(2, "db");
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
        private System.Windows.Forms.ImageList largeIconsList;
        private System.Windows.Forms.ToolStripMenuItem btnImportConections;
        private System.Windows.Forms.OpenFileDialog importCSVConnections;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnConfigManagement;
        private System.Windows.Forms.OpenFileDialog setManagementRoute;
        private System.Windows.Forms.ToolStripMenuItem exportarCSV;
        private System.Windows.Forms.ToolStripMenuItem vistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view_list;
        private System.Windows.Forms.ToolStripMenuItem view_icon;
        private System.Windows.Forms.ImageList smallIconList;
    }
}

