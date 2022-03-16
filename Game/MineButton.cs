using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;

namespace Game
{
  /// <summary>
  /// Clase que define el comportamiento y las nuevas características del tipo de botón que se usa en el juego.
  /// </summary>
  public class MineButton:Button
  {
    //Campos
    /// <summary>
    /// Indica si el botón tiene una mina o no.
    /// </summary>
    private bool MineState;

    /// <summary>
    /// Permite saber si el botón esta marcado con la bandera o no.
    /// </summary>
    private bool CheckedState;

    /// <summary>
    /// Indica si el botón ha sido revisado ya o no (si se dio clic en él).
    /// </summary>
    private bool Rev;

    /// <summary>
    /// posición del botón en el juego.
    /// </summary>
    Point Position;   

    //Propiedades
    /// <summary>
    /// Obtiene o cambia la propiedad de tener mina del botón.
    /// </summary>
    public bool HasAMine
    {
      get
      {
        return MineState;
      }
      set
      {
        MineState = value;
      }
    }

    /// <summary>
    /// Permite saber si el botón esta marcado con la bandera o no.
    /// </summary>
    public bool IsChecked
    {
      get
      {
        return CheckedState;
      }
    }

    /// <summary>
    /// Obtiene la posición del boton en el juego.
    /// </summary>
    public Point GamePosition
    {
      get
      {
        return Position;
      }
    }

    /// <summary>
    /// Indica si el botón ha sido o no revisado.
    /// </summary>
    public bool RevState
    {
      get
      {
        return Rev;
      }
    }  

    
    //Eventos
    /// <summary>
    /// Permite que se pueda lanzar un evento cuando el usuario marca un boton con la bandera.
    /// </summary>
    /// <param name="Add">true(si se marcó); fasle(si se desmarcó).</param>
    public delegate void RightCheckedHandler(bool Add);

    /// <summary>
    /// Evento que es lanzado cuando se hace click derecho en un botón.
    /// </summary>
    public event RightCheckedHandler OnCheckedMine;


    /// <summary>
    /// Permite que se pueda lanzar un evento cuando el botón es revisado (que no tiene Mina).
    /// </summary>
    public delegate void RevChanged();

    /// <summary>
    /// Evento que es lanzado cuando el botón es revisado.
    /// </summary>
    public event RevChanged OnRevButton;
    
    //Metodos 

    //Constructores
    /// <summary>
    /// Permite construir un botón de tipo MineButton e inicializa sus estados por defecto.
    /// </summary>
    /// <param name="Position">Posición del botón en el juego.</param>
    public MineButton(Point Position) :base()
    {
      this.Position=Position;
      this.MouseUp += new MouseEventHandler(RightClick);
      this.Size= new Size(32,32);
      this.FlatStyle= System.Windows.Forms.FlatStyle.Flat;
      this.BackColor = System.Drawing.SystemColors.WindowText;
      Font ControlDef = DefaultFont;
      Font Mod= new Font(ControlDef, FontStyle.Bold);      
      this.Font = Mod;
    }

    /// <summary>
    /// Desabilita el botón.
    /// </summary>
    public void Disable()
    {
      if (Rev == true) return;
      Rev = true;
      this.BackColor = System.Drawing.SystemColors.Highlight;
      this.Enabled = false;
      if (OnRevButton != null)
      {
        OnRevButton();
      }
    }

    //EventHandler
    //ClickDerecho
    /// <summary>
    /// Manipula el click derecho del botón.
    /// </summary>
    /// <param name="sender">Botón sobre el cual se ejecuta el evento.</param>
    /// <param name="e">Información adicional.</param>
    private void RightClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
      {
        return;
      }

      if (this.CheckedState == false)
      {
        Bitmap m = new Bitmap("flags1.png");
        this.BackgroundImage = m;
        this.BackgroundImageLayout = ImageLayout.Stretch;
        CheckedState = true;
        if (OnCheckedMine != null)
        {
          OnCheckedMine(true);
        }        
      }
      else
      {
        this.BackgroundImage= null;
        CheckedState = false;
        if (OnCheckedMine != null)
        {
          OnCheckedMine(false);
        }
      }     
    }
  }
}
