using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;

namespace BuscaMinas
{
  //El Form Principal del juego.
  public partial class Form1 : Form
  {
    //Campos:
    /// <summary>
    /// Campo que se corresponde con el juego que se está jugando.
    /// </summary>
    private MainGame MG;

    /// <summary>
    /// Tiempo en segundos que dura el juego.
    /// </summary>
    private int Time;

    /// <summary>
    /// Indica si el juego está o no en Pausa.
    /// </summary>
    private bool Paused;

    /// <summary>
    /// Indica si el juego ya termino es decir si el form está en espera.
    /// </summary>
    private bool End = true;

    /// <summary>
    /// Ubicación del fichero donde se guardan las estádisticas y records.
    /// </summary>
    private string Path;

    /// <summary>
    /// Dificultad del juego que se está jugando.
    /// </summary>
    private Dificultad GameMod;

   

    //Metodos:
    //Constructores:

    /// <summary>
    /// Permite la construcción de un Form e inicializa sus valores por defecto.
    /// </summary>
    public Form1()
    {
      InitializeComponent();
      Path = "records.dat";
      
    }
    
    //Eventos:
    //***Controles Internos

    //Load del Form:
    private void Form1_Load(object sender, EventArgs e)
    {
      this.toolStripStatusLabel1.Text = "0";
      this.toolStripStatusLabel2.Text = "0";
      this.toolStripStatusLabel5.Text =  "";
    }

   

    //Al cerrar el Form:
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (End == false && MG.HasBegun == true)
      {
        DialogResult dr = MessageBox.Show("Se perderá el estado de este juego. ¿Desea continuar?.", "Busca Minas",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        if (dr == DialogResult.No)
        {
          e.Cancel = true;
        }
      }
    }

    //Tick del timer (Actualiza el tiempo que se ha demorado el juego):
    private void timer1_Tick(object sender, EventArgs e)
    {
      Time++;
      toolStripStatusLabel1.Text = Time.ToString();
    }

    //****Menu

    //Botón Pausa:
    private void pausaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OnPaused();
    }   

    //Botón Salir:
    private void salirToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    //Boton Nuevo->Facil:
    private void x0910MinasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StartNewGame(9, 9, 10, Dificultad.Facil);
    }

    //Boton Nuevo->Medio:
    private void x1640MinasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StartNewGame(16, 16, 40, Dificultad.Medio);
    }

    //Boton Nuevo->Dificil:
    private void x3099MinasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StartNewGame(16, 30, 99, Dificultad.Dificil);
    }

    //Botón Estadísticas:
    private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StatsForm st = new StatsForm(Path);
      st.ShowDialog();
    }

    //Botón Ayuda->Acerca De:
    private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutForm1 ab= new AboutForm1();
      ab.ShowDialog();
    }   

    //****Eventos que ocurren durante el juego:
    /// <summary>
    /// Permite actualizar la cantidad de minas que el usuario a encontrado y si el ProggresBar.
    /// </summary>
    private void OnCheckedButtonChanged()
    {
      toolStripStatusLabel2.Text = MG.MMines.ToString();
      double MinasFalt = (double)MG.MMines;
      double Total = (double)MG.MinesCount;
      double MinasAct = Total - MinasFalt;

      double tmp = MinasAct / Total * 100;
      int tmpToInt = (int)(Math.Round(tmp, 0));
      if (tmpToInt <= 100)
      {
        toolStripProgressBar1.Value = tmpToInt;
      }


    }

    /// <summary>
    /// Ocurre cuando se gana el juego.
    /// </summary>
    private void OnWin()
    {
      flowLayoutPanel1.Enabled = false;
      End = true;
      timer1.Enabled = false;
      MessageBox.Show("Bien hecho, has ganado en " +  Time.ToString() + " segundos.", "BuscaMinas",  MessageBoxButtons.OK, MessageBoxIcon.Information);
      CheckRecord();
      pausaToolStripMenuItem.Enabled=false;
    }

    /// <summary>
    /// Ocurre cuando se pierde el juego.
    /// </summary>
    /// <param name="Clicked">Botón al que se le dió click</param>
    private void OnGameOver(MineButton Clicked)
    {
      MessageBox.Show("Lo siento, has perdido. Quizas en la proxima...no se, es que jugando tan mal...", "Busca Minas",  MessageBoxButtons.OK);
      flowLayoutPanel1.Enabled = false;
      timer1.Enabled = false;
      End = true;
      pausaToolStripMenuItem.Enabled = false;
    }

    /// <summary>
    /// Permite empezar un nuevo juego.
    /// </summary>
    /// <param name="Width">Dimensión por el eje X.</param>
    /// <param name="Height">Dimensión por el eje Y.</param>
    /// <param name="Mines">Cantidad de Minas.</param>
    /// <param name="GM">Dificultad del juego</param>
    public void StartNewGame(uint Width, uint Height, uint Mines, Dificultad GM)
    {
      if (!End)
      {
        if (MG != null)
        {
          if (MG.HasBegun)
          {
            DialogResult dr = MessageBox.Show("Se perderá el estado de este juego. ¿Desea continuar?.", "Busca Minas",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == System.Windows.Forms.DialogResult.No)
            {
              return;
            }
          }
        }
      }
      End = false;

      if (Paused)
      {
        OnPaused();
      }


      this.Hide();
      flowLayoutPanel1.Controls.Clear();

      MG = new MainGame(Width, Height , flowLayoutPanel1, Mines);
      this.toolStripStatusLabel2.Text = Mines.ToString();
      MG.Lose += OnGameOver;
      MG.Win += OnWin;
      MG.CheckedButtonChanged += OnCheckedButtonChanged;
      MG.OnGameStart += StartTimer;

      Time = 0;
      toolStripProgressBar1.Value = 0;
      flowLayoutPanel1.Enabled = true;
      this.AutoSize = true;
      GameMod = GM;
      pausaToolStripMenuItem.Enabled=true;
      this.Show();
    }

    

    /// <summary>
    /// Permite chequear al final de un juego ganado si el usuario hizo un record, en tal caso lo guarda.
    /// </summary>
    private void CheckRecord()
    {
      Records r = null;
      try
      {
        r = Records.Deserialize(Path);
      }
      catch
      {
        r = null;
      }
      if (r == null)
      {         
        r= new Records();
      }
      Stat t = new Stat();
      t.Time = Time;
      t.TypeGame = GameMod;
      if (r.IsARecord(t))
      {
        NewRecordForm nrf = new NewRecordForm();
        nrf.ShowDialog();
        if (nrf.DialogResult != System.Windows.Forms.DialogResult.OK)
        {
          return;
        }
        t.Player = nrf.UserText;
        r.Add(t);
        Records.Serialize(Path, r);
      }
    }

    /// <summary>
    /// Metodo que indica que hacer cuando se pone pausa.
    /// </summary>
    private void OnPaused()
    {
      if (Paused)
      {
        this.Hide();
        flowLayoutPanel1.Visible = true;
        timer1.Enabled = true;
        this.AutoSize = true;
        Paused = false;
        this.Show();
        toolStripStatusLabel5.Text="";
      }
      else
      {
        this.Hide();
        this.timer1.Enabled = false;
        this.AutoSize = false;
        this.flowLayoutPanel1.Visible = false;
        Paused = true;
        this.Show();
        toolStripStatusLabel5.Text = "En Pausa";
      }
    }

    /// <summary>
    /// Habilita el Timer del form al empezar el juego.
    /// </summary>
    private void StartTimer()
    {
      timer1.Enabled=true;
    }
  }
}
