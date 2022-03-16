using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Game
{
  public class MainGame
  {
    //Campos
    //Delegates:
    /// <summary>
    /// Permite que se pueda lanzar un evento para cuando se gane el juego.
    /// </summary>
    public delegate void WinEventHandler();

    /// <summary>
    /// Permite que se pueda lanzar un evento para cuando se pierda el juego.
    /// </summary>
    /// <param name="Clicked">Botón en que se dió click.</param>
    public delegate void LoseEventHandler(MineButton Clicked);

    /// <summary>
    /// Permite que se lanze un evento cuando se ponga o se quite una bandera sobre un botón.
    /// </summary>
    public delegate void FlagEventHandler();

    /// <summary>
    /// Delegado que permite lanzar un evento cuando empieze el juego y permita contar el tiempo.
    /// </summary>
    public delegate void StartTimer ();
    
    //Eventos:
    /// <summary>
    /// Evento que se lanza cuando el juego es ganado.
    /// </summary>
    public event WinEventHandler Win;

    /// <summary>
    /// Evento que se lanza cuando el juego se pierde.
    /// </summary>
    public event LoseEventHandler Lose;

    /// <summary>
    /// Evento que es lanzado cuando la cantidad de minas que faltan por marcar (correctamente o no) cambia.
    /// /// </summary>
    public event FlagEventHandler CheckedButtonChanged;

    /// <summary>
    /// Sirve Para habilitar el Timer del Form.
    /// </summary>
    public event StartTimer OnGameStart;


    //Campos
    /// <summary>
    /// El conjunto de botones del juego.
    /// </summary>
    private MineButton[,] Buttons;

    /// <summary>
    /// Cantidad total de minas del juego.
    /// </summary>
    private uint Mines;

    /// <summary>
    /// Minas sin marcar.
    /// </summary>
    private int  MissingMines;

    /// <summary>
    /// Indica si el juego ha empezado o no 
    /// (sirve para en caso de que no haya emezado y se de click en un botón se generen la ubicación de las minas).
    /// </summary>
    private bool FirstClick=true;

    /// <summary>
    /// Cantidad total de botones que no tienen minas.
    /// </summary>
    private uint ButtonsWithoutMines;

    /// <summary>
    /// Cantidad de botones que ya han sido revisados.
    /// </summary>
    private uint RevButtons;

    //Propiedades:
    //Obtiene cuantas minas faltan por marcar (correctamente o no).
    public int MMines
    {
      get
      {
        return MissingMines;
      }
    }

    public uint MinesCount
    {
      get
      {
        return Mines;
      }
    }

    /// <summary>
    /// Devuelve si el juego a empezado o no.
    /// </summary>
    public bool HasBegun
    {
      get 
      { 
       return !FirstClick;
      }
    }

   
    //Métodos:
    //Constructores:
    /// <summary>
    /// Construye un juego a partir de determinadas características en inicializa todo lo necesario.
    /// </summary>
    /// <param name="Width">Dimensión por el eje X.</param>
    /// <param name="Height">Dimensión por el eje Y.</param>
    /// <param name="Container">Panel en donde se van a insertar los botones creados.</param>
    /// <param name="Mines">Cantidad de minas que va a tener el juego.</param>
    public MainGame(uint Width,uint Height, FlowLayoutPanel Container,uint Mines)
    {
      //Inicializar Campos
      if (Width * Height <= Mines)
      {
        throw new InvalidGameException("No pueden haber esa cantidad de minas");
      }

      this.Mines = Mines;
      MissingMines= (int) Mines;
      ButtonsWithoutMines= Width*Height-Mines;
      
      this.Win+= OnEnd;
      this.Lose+= OnEnd;
   


      Buttons = new MineButton[Width, Height];
      for (int i = 0; i < Buttons.GetLength(0); i++)
      {
        MineButton LastRowButton = null;
        for (int j = 0; j < Buttons.GetLength(1); j++)
        {
          //Crear Botón
          Buttons[i, j] = new MineButton(new Point(i, j));
          
          //Registrar Eventos
          Buttons[i, j].Click += OnEveryButtonClickEventHandler;
          Buttons[i, j].OnCheckedMine += OnCheckedMineEventHandler;
          Buttons[i,j].OnRevButton += OnRevButtonEventHandler;

          //Agregar al contenedor
          Container.Controls.Add(Buttons[i, j]);
          LastRowButton = Buttons[i, j];
        }
        Container.SetFlowBreak(LastRowButton, true);
      }
    }

    //EvenHandlers:
    /// <summary>
    /// Permite saber cuantas minas faltan por marcar (correctamente o no).
    /// </summary>
    /// <param name="Add"></param>
    private void OnCheckedMineEventHandler(bool Add)
    {
      if (Add)
      {
        MissingMines--;
      }
      else
      {
        MissingMines++;
      }
      if (CheckedButtonChanged != null)
      {
        CheckedButtonChanged();
      }
    }

    /// <summary>
    /// Acutaliza lo nesesario cada vez que se revisa un botón.
    /// </summary>
    public void OnRevButtonEventHandler()
    {
      RevButtons++;
      if (RevButtons == ButtonsWithoutMines && Win != null)
      {
        Win();
      }
    }

    /// <summary>
    /// Administra que se hace cuando se da click en un botón.
    /// </summary>
    /// <param name="sender">Botón en cual se dió el click.</param>
    /// <param name="e">Información adicional del evento.</param>
    private void OnEveryButtonClickEventHandler(object sender, EventArgs e)
    {      
      MineButton ClickedButton = (MineButton)sender;
      //Si todavia no ha empezado el juego:
      if (FirstClick)
      {
        GenerateMines(ClickedButton);
        if (OnGameStart != null)
        {
          OnGameStart();
        }
      }
      //Si Tiene bandera no hacer nada:
      if (ClickedButton.IsChecked) return;
      //Si dio clic en un botón con mina perdió.
      if (ClickedButton.HasAMine && Lose != null)
      {
        Lose(ClickedButton);
        return;
      }

      //Calcular la cantidad de botones que tienen minas alrededor del botón que se dió click.
      List<MineButton> ContB = GetSurroundingButtons(ClickedButton);

      int CantMines = 0;
      foreach (MineButton Button in ContB)
      {
        if (Button.HasAMine)
        {
          CantMines++;
        }
      }

      //Desabilitar para que el algotitmo no se repita infinitamente.
      ClickedButton.Disable();
      //Si No Hay Minas Alrededor (aplicar este algoritm a los botones del alrededor).
      if (CantMines == 0)
      {
        foreach (MineButton Button in ContB)
        {
          //No tener en cuenta los botones revisados o los que estan marcados con banderas.
          if (Button.RevState == true||Button.IsChecked==true)
          {
            continue;
          }                   
          OnEveryButtonClickEventHandler(Button, new EventArgs());
        }
      }
      //Cambiar el texto.
      else
      {
        ClickedButton.Text = CantMines.ToString();       
      }     
    }

    /// <summary>
    /// Administra que se hace cuando se acaba el juego. Pone la imagen de las bombas a cualquier botón que tenga una.
    /// </summary>
    private void OnEnd()
    {
      Bitmap BombImg = new Bitmap("Bomb.png");
      ImageLayout CorrectBIL = ImageLayout.Stretch;

      foreach (MineButton but in Buttons)
      {
        if (but.HasAMine)
        {
          but.BackgroundImage = BombImg;
          but.BackgroundImageLayout = CorrectBIL;
        }
        if (but.HasAMine && but.IsChecked)
        {
          but.BackColor =Color.GreenYellow;
        }
        if (but.HasAMine == false && but.IsChecked == true)
        {
          but.BackColor = Color.Yellow;
        }
      }

    }

    /// <summary>
    /// Administra que se hace cuando se acaba el juego. Pone la imagen de las bombas a cualquier botón que tenga una.
    /// </summary>
    /// <param name="MButton">Boton en que se dio click.</param>
    private void OnEnd(MineButton MButton)
    {
      OnEnd();
      MButton.BackColor = Color.Maroon;
    }

    //Metodos Auxiliares:
    /// <summary>
    /// Permite obtener los botones que están alrededor de un botón en el juego.
    /// </summary>
    /// <param name="ClickedButton">El botón al partir del cual se buscarán los botones que le rodean.</param>
    /// <returns>Una lista con dichos botones.</returns>
    private List<MineButton> GetSurroundingButtons(MineButton ClickedButton)
    {
      int PosX = ClickedButton.GamePosition.X;
      int PosY = ClickedButton.GamePosition.Y;

      List<MineButton> Res = new List<MineButton>();

      for (int i = -1; i <= 1; i++)
      {
        for (int j = -1; j <= 1; j++)
        {
          //No tener en cuenta el botón en sí
          if (j == 0 && i == 0) continue;
          //En caso que no exista(botones que se encuentran el los bordes)
          try
          {
            Res.Add(Buttons[PosX + i, PosY + j]);
          }
          catch
          {

          }
        }
      }
      return Res;
    }
    
    /// <summary>
    /// Método que se encarga de repartir las minas alrededor de todo el juego.
    /// </summary>
    /// <param name="sender"></param>
    private void GenerateMines(MineButton ClickedButton)
    {
      Random R = new Random();      

      int PosX = ClickedButton.GamePosition.X;
      int PosY = ClickedButton.GamePosition.Y;
      
      for (int i = 1; i <= Mines; i++)
      {
        int Num1 = R.Next(Buttons.GetLength(0));
        int Num2 = R.Next(Buttons.GetLength(1));
        
        /*Para No repartir Minas alrededor de donde se dió clic para que al menos el usuario tenga suficientes
         pistas.*/
        int DifX=  Num1 - PosX;
        int DifY = Num2 - PosY;
        bool IsContinusToClickedButton = (DifX == -1 || DifX == 0 || DifX == 1 && DifY == -1 || DifY == 0 || DifY == 1);

        /*Para no repartir las minas en botones que estén cubiertos totalmente por otras minas.*/
        List<MineButton> SB= GetSurroundingButtons(Buttons[Num1,Num2]);
        int CantMinas=0;
        foreach (MineButton Button in SB)
        {
          if (Button.HasAMine == true)
          {
            CantMinas++;
          }
        }
        bool IsTotallyCover= (CantMinas==SB.Count);

        //*Si ocurre algo de esto volver a empezar (los números al azar no sirvieron)
        if (Buttons[Num1, Num2].HasAMine || IsContinusToClickedButton||IsTotallyCover)
        {
          i--;
        }
        else
        {
          Buttons[Num1, Num2].HasAMine = true;
        }
      }
      FirstClick = false;
    }     
  }
}
