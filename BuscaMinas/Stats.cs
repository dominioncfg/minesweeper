using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace BuscaMinas
{
  /// <summary>
  /// Clase que permite llevar tener en cuenta tolo lo que se va a salvar como estádisticas.
  /// </summary>
  [Serializable]
  public class Stat
  {
    //Campos
    /// <summary>
    /// Nombre del Jugador.
    /// </summary>
    private String Name;
    /// <summary>
    /// Tiempo que hizo el jugador.
    /// </summary>
    private int Seconds;
    /// <summary>
    /// Dificultad del juego.
    /// </summary>
    private Dificultad Dif;

    //Propiedades:
    /// <summary>
    /// Permite cambiar o obtener el nombre del jugador.
    /// </summary>
    public String Player
    {
      get
      {
        return Name;
      }
      set
      {
        Name = value;
      }
    }
    /// <summary>
    /// Permite cambiar o obtener el tiempo que hizo el jugador en la partida.
    /// </summary>
    public int Time
    {
      get
      {
        return Seconds;
      }
      set
      {
        Seconds = value;
      }
    }
    /// <summary>
    /// Permite cambiar o obtener el tipo de juego.
    /// </summary>
    public Dificultad TypeGame
    {
      get
      {
        return Dif;
      }
      set
      {
        Dif = value;
      }
    }

    //Operadores:
    //>   true->Si hizo un mejor tiempo el primero que el segundo.
    public static bool operator >(Stat st1, Stat st2)
    {
      if (st1.Time < st2.Time)
      {
        return true;
      }
      else return false;
    }
    //<   true->Si hizo un tiempo mas malo el primero que el segundo.
    public static bool operator <(Stat st1, Stat st2)
    {
      if (st1.Time > st2.Time)
      {
        return true;
      }
      else return false;
    }

  }

  /// <summary>
  /// Enumeración que describe los tipos de juegos que existen.
  /// </summary>
  [Serializable]
  public enum Dificultad
  {
    Facil, Medio, Dificil
  }

  /// <summary>
  /// Clase que enlista los mejores tiempos en general y permite la serialización.
  /// </summary>
  [Serializable]
  public class Records
  {
    //Campos
    /// <summary>
    /// Lista que representa los mejores tiempos de la dificultad:Facil.
    /// </summary>
    private List<Stat> Facil = new List<Stat>(5);
    /// <summary>
    /// Lista que representa los mejores tiempos de la dificultad:Medio.
    /// </summary>
    private List<Stat> Medio = new List<Stat>(5);
    /// <summary>
    /// Lista que representa los mejores tiempos de la dificultad:Dificil.
    /// </summary>
    private List<Stat> Dificil = new List<Stat>(5);

    //Metodos:
    /// <summary>
    /// Permite obtener todos una lista con los mejores tiempos de una dificultad específica.
    /// </summary>
    /// <param name="Mod">Modalidad de juego.</param>
    /// <returns>Una lista con los mejores tiempos.</returns>
    public List<Stat> GetList(Dificultad Mod)
    {
      switch (Mod)
      {
        case Dificultad.Facil:
          return Facil;
        case Dificultad.Medio:
          return Medio;
        default:
          return Dificil;
      }
    }

    /// <summary>
    /// Agrega un record a la lista. (Se queda con los 5 mejores tiempos.)
    /// </summary>
    /// <param name="GameStat">Stat que representa el record a agregar.</param>
    public void Add(Stat GameStat)
    {
      List<Stat> TargetList = new List<Stat>();
      if (GameStat.TypeGame == Dificultad.Facil)
      {
        TargetList = Facil;
      }
      else
      {
        if (GameStat.TypeGame == Dificultad.Medio)
        {
          TargetList = Medio;
        }
        else
        {
          TargetList = Dificil;
        }
      }

      TargetList.Add(GameStat);
      Sort(TargetList);
      if (TargetList.Count == 6)
      {
        TargetList.RemoveAt(5);
      }
    }

    /// <summary>
    /// Permite ordenar la lista segun los tiempos.
    /// </summary>
    /// <param name="TargetList">Lista a ordenar.</param>
    private void Sort(List<Stat> TargetList)
    {
      for (int i = 0; i < TargetList.Count; i++)
      {
        for (int j = i + 1; j < TargetList.Count; j++)
        {
          if (TargetList[i] < TargetList[j])
          {
            Stat tmp = TargetList[i];
            TargetList[i] = TargetList[j];
            TargetList[j] = tmp;
          }
        }
      }
    }

    /// <summary>
    /// Salva en un archivo las estadísticas con los mejores tiempos.
    /// </summary>
    /// <param name="Path">Ubicación del archivo donde se van a guardar las estadísticas.</param>
    /// <param name="AllStats">Estadísticas a salvar.</param>
    public static void Serialize(string Path, Records AllStats)
    {
      FileStream fs = new FileStream(Path, FileMode.Create);
      BinaryFormatter bf = new BinaryFormatter();
      try
      {
        bf.Serialize(fs, AllStats);
      }
      catch (SerializationException e)
      {
        throw e;
      }
      finally
      {
        fs.Close();
      }

    }

    /// <summary>
    /// Carga a partir de un archivo las estadísticas con los mejores tiempos.
    /// </summary>
    /// <param name="Path">Ubicación del archivo con las estadísticas</param>
    /// <returns></returns>
    public static Records Deserialize(string Path)
    {
      FileStream fs = new FileStream(Path, FileMode.Open);
      BinaryFormatter bf = new BinaryFormatter();
      try
      {

        return (Records)bf.Deserialize(fs);
      }
      catch (SerializationException e)
      {
        throw e;
      }
      finally
      {
        fs.Close();
      }
    }

    /// <summary>
    /// Devuelve si un juego en especial es considerado un record.
    /// </summary>
    /// <param name="Game">Juego en cuestión</param>
    /// <returns></returns>
    public bool IsARecord(Stat Game)
    {
      if (Facil.Count < 5) return true;
      Dificultad Mod = Game.TypeGame;
      switch (Mod)
      {
        case Dificultad.Facil:
          return (Game > Facil[Facil.Count - 1]);
        case Dificultad.Medio:
          return (Game > Medio[Medio.Count - 1]);
        default:
          return (Game > Medio[Medio.Count - 1]);
      }
    }
  }
}
