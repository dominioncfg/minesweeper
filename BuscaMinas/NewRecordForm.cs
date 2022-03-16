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
  /// Form que permite que el usario escriba su nombre al haber ganado un juego y haber establecido un record.
  /// </summary>
  public partial class NewRecordForm : Form
  {
    //Propiedades
    /// <summary>
    /// Obtiene el texto escrito por el usuario.
    /// </summary>
    public String UserText
    {
      get
      {
        return textBox1.Text;
      }
    }

    //Metodos:
    //Consructores
    public NewRecordForm()
    {
      InitializeComponent();
    }
    //Otros
    
    //Eventos:
     //Boton Cerrar:
    private void button2_Click(object sender, EventArgs e)
    {
      this.DialogResult= DialogResult.Cancel;
      Close();
    }

    //Boton Aceptar:
    private void button1_Click(object sender, EventArgs e)
    {
      this.DialogResult= DialogResult.OK;
      Close();
    }

    //Al camiar el texto en el TextBox:
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(textBox1.Text))
      {
        button1.Enabled = false;
      }
      else
      {
        double d=0;
        if (Double.TryParse(textBox1.Text, out d))
        {
          button1.Enabled = false;
        }
        else
        {
          button1.Enabled=true;
        }
      }
    }
  }
}
