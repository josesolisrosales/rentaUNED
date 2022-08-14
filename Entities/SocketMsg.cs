using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Esta clase facilita la comunicacion cliente-servidor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SocketMsg<T>
    {
        public string Method { get; set; }
        public T entity { get; set; }
    }
}
