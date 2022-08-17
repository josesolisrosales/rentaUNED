using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    /// <summary>
    /// Esta clase facilita la comunicacion cliente-servidor, basada en ejemplo visto durante tutoria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SocketMsg<T>
    {
        public string Method { get; set; }
        public T Entity { get; set; }
    }

    public struct CheckReserva
    {
        public string idVehiculo;
        public DateTime fechaInicio;
        public DateTime fechaFin;
    }
}
