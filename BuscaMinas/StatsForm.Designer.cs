namespace BuscaMinas
{
  partial class StatsForm
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
      System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Facil", System.Windows.Forms.HorizontalAlignment.Center);
      System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Medio", System.Windows.Forms.HorizontalAlignment.Center);
      System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Dificil", System.Windows.Forms.HorizontalAlignment.Center);
      this.button1 = new System.Windows.Forms.Button();
      this.listView1 = new System.Windows.Forms.ListView();
      this.PlayerCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.TimeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(251, 244);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Cerrar";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // listView1
      // 
      this.listView1.BackColor = System.Drawing.Color.Blue;
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PlayerCol,
            this.TimeCol});
      this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
      this.listView1.ForeColor = System.Drawing.SystemColors.Info;
      this.listView1.FullRowSelect = true;
      this.listView1.GridLines = true;
      listViewGroup1.Header = "Facil";
      listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
      listViewGroup1.Name = "EasyG";
      listViewGroup2.Header = "Medio";
      listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
      listViewGroup2.Name = "NormalG";
      listViewGroup3.Header = "Dificil";
      listViewGroup3.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
      listViewGroup3.Name = "HardG";
      this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
      this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.listView1.LabelWrap = false;
      this.listView1.Location = new System.Drawing.Point(0, 0);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(338, 235);
      this.listView1.TabIndex = 2;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // PlayerCol
      // 
      this.PlayerCol.Text = "Jugador";
      this.PlayerCol.Width = 273;
      // 
      // TimeCol
      // 
      this.TimeCol.Text = "Tiempo";
      // 
      // StatsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.HotTrack;
      this.ClientSize = new System.Drawing.Size(338, 274);
      this.Controls.Add(this.listView1);
      this.Controls.Add(this.button1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "StatsForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Estadísticas";
      this.Load += new System.EventHandler(this.StatsForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader PlayerCol;
    private System.Windows.Forms.ColumnHeader TimeCol;
  }
}