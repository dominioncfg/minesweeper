namespace BuscaMinas
{
  partial class Form1
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.x0910MinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.x1640MinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.x3099MinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.pausaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.estadísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
      this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.menuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.estadísticasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(280, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // archivoToolStripMenuItem
      // 
      this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.toolStripSeparator1,
            this.pausaToolStripMenuItem,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
      this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
      this.archivoToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
      this.archivoToolStripMenuItem.Text = "&Juego";
      // 
      // nuevoToolStripMenuItem
      // 
      this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x0910MinasToolStripMenuItem,
            this.x1640MinasToolStripMenuItem,
            this.x3099MinasToolStripMenuItem});
      this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
      this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.nuevoToolStripMenuItem.Text = "Nuevo";
      // 
      // x0910MinasToolStripMenuItem
      // 
      this.x0910MinasToolStripMenuItem.Name = "x0910MinasToolStripMenuItem";
      this.x0910MinasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
      this.x0910MinasToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.x0910MinasToolStripMenuItem.Text = "Fácil";
      this.x0910MinasToolStripMenuItem.Click += new System.EventHandler(this.x0910MinasToolStripMenuItem_Click);
      // 
      // x1640MinasToolStripMenuItem
      // 
      this.x1640MinasToolStripMenuItem.Name = "x1640MinasToolStripMenuItem";
      this.x1640MinasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
      this.x1640MinasToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.x1640MinasToolStripMenuItem.Text = "Medio";
      this.x1640MinasToolStripMenuItem.Click += new System.EventHandler(this.x1640MinasToolStripMenuItem_Click);
      // 
      // x3099MinasToolStripMenuItem
      // 
      this.x3099MinasToolStripMenuItem.Name = "x3099MinasToolStripMenuItem";
      this.x3099MinasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
      this.x3099MinasToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.x3099MinasToolStripMenuItem.Text = "Difícil";
      this.x3099MinasToolStripMenuItem.Click += new System.EventHandler(this.x3099MinasToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
      // 
      // pausaToolStripMenuItem
      // 
      this.pausaToolStripMenuItem.Enabled = false;
      this.pausaToolStripMenuItem.Name = "pausaToolStripMenuItem";
      this.pausaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
      this.pausaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.pausaToolStripMenuItem.Text = "Pausa";
      this.pausaToolStripMenuItem.Click += new System.EventHandler(this.pausaToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
      // 
      // salirToolStripMenuItem
      // 
      this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
      this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.salirToolStripMenuItem.Text = "Salir";
      this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
      // 
      // estadísticasToolStripMenuItem
      // 
      this.estadísticasToolStripMenuItem.Name = "estadísticasToolStripMenuItem";
      this.estadísticasToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
      this.estadísticasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
      this.estadísticasToolStripMenuItem.Text = "&Estadísticas";
      this.estadísticasToolStripMenuItem.Click += new System.EventHandler(this.estadísticasToolStripMenuItem_Click);
      // 
      // ayudaToolStripMenuItem
      // 
      this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
      this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
      this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
      this.ayudaToolStripMenuItem.Text = "Ayuda";
      // 
      // acercaDeToolStripMenuItem
      // 
      this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
      this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
      this.acercaDeToolStripMenuItem.Text = "Acerca De";
      this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel5});
      this.statusStrip1.Location = new System.Drawing.Point(0, 233);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(280, 25);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel4
      // 
      this.toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
      this.toolStripStatusLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripStatusLabel4.Image = global::BuscaMinas.Properties.Resources.clock;
      this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
      this.toolStripStatusLabel4.Size = new System.Drawing.Size(20, 20);
      this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 20);
      this.toolStripStatusLabel1.Text = "Tiempo";
      // 
      // toolStripStatusLabel3
      // 
      this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
      this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripStatusLabel3.Image = global::BuscaMinas.Properties.Resources.flags1;
      this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
      this.toolStripStatusLabel3.Size = new System.Drawing.Size(20, 20);
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 20);
      this.toolStripStatusLabel2.Text = "CantMinas";
      // 
      // toolStripProgressBar1
      // 
      this.toolStripProgressBar1.Name = "toolStripProgressBar1";
      this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
      // 
      // toolStripStatusLabel5
      // 
      this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
      this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
      this.toolStripStatusLabel5.Size = new System.Drawing.Size(46, 20);
      this.toolStripStatusLabel5.Text = "Estado";
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flowLayoutPanel1.BackColor = System.Drawing.Color.Blue;
      this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 209);
      this.flowLayoutPanel1.TabIndex = 2;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.Blue;
      this.ClientSize = new System.Drawing.Size(280, 258);
      this.Controls.Add(this.flowLayoutPanel1);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Busca Minas";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem pausaToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    private System.Windows.Forms.ToolStripMenuItem x0910MinasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem x1640MinasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem x3099MinasToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    private System.Windows.Forms.ToolStripMenuItem estadísticasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
  }
}

