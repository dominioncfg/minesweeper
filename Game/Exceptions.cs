using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
  /// <summary>
  /// Excepción que define que cuando se está creando un juego que no tiene sentido.
  /// </summary>
  [Serializable]  
  public class InvalidGameException : ApplicationException
  {
    public InvalidGameException() { }
    public InvalidGameException(string message) : base(message) { }
    public InvalidGameException(string message, Exception inner) : base(message, inner) { }
    protected InvalidGameException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
