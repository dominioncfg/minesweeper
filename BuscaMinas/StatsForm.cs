using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaMinas
{
  /// <summary>
  /// Form que permite mostrar al usuario información con las estadísticas acerca de los mejores tiempos.
  /// </summary>
  public partial class StatsForm : Form
  {
    //Campos
    /// <summary>
    /// Estadisticas que cargará el form al crearse.
    /// </summary>
    Records Stats;
   
    //Metodos
     //Construtores:
    /// <summary>
    /// Construye un Form de este tipo.
    /// </summary>
    /// <param name="Path">Ubicación del fichero donde están las estadísticas.</param>
    public StatsForm(String Path)
    {
      InitializeComponent();
      try
      {
        Stats = Records.Deserialize(Path);
      }
      catch
      {
        
      }            
    }

    //Eventos:

    //Boton Cerrar
    private void button1_Click(object sender, EventArgs e)
    {
      Close();     
    }
    //Al Cargar el Form:
    private void StatsForm_Load(object sender, EventArgs e)
    {
      try
      {
        ShowStatsOnListView(Stats.GetList(Dificultad.Facil), Dificultad.Facil);
        ShowStatsOnListView(Stats.GetList(Dificultad.Medio), Dificultad.Medio);
        ShowStatsOnListView(Stats.GetList(Dificultad.Dificil), Dificultad.Dificil);
      }
      catch
      {

      }
    }

    /// <summary>
    /// Permite generar y mostrar en el ListView los items a partir de una lista de datos.
    /// </summary>
    /// <param name="Data">Lista a que se va meter.</param>
    /// <param name="Group">Grupo al que pertenecen los datos.</param>
    private void ShowStatsOnListView(List<Stat> Data, Dificultad Group)
    {
      //Para saber en que grupo del list view Meterlo.
      string dif = "";
      switch (Group)
      {
        case Dificultad.Facil:
          dif = "EasyG";
          break;
        case Dificultad.Medio:
          dif = "NormalG";
          break;
        default:
          dif = "HardG";
          break;
      }
      ListViewGroup GroupList = listView1.Groups[dif];

      //Agregar los records:
      foreach (Stat item in Data)
      {
        string[] StringData = new string[2];
        StringData[0] =item.Player;
        StringData[1] = item.Time.ToString();
        ListViewItem lvi = new ListViewItem(StringData, GroupList);
        listView1.Items.Add(lvi);
      }
    }
  }
}
