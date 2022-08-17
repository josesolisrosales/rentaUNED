using System;

namespace Entities
{
    public class Reserva
    {
        private int id;
        private string idCliente;
        private string idVehiculo;
        private DateTime fechaReserva;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int monto;
        public Reserva()
        { }
        public Reserva(int id, string idCliente, string idVehiculo, DateTime fechaReserva, DateTime fechaInicio, DateTime fechaFin, int monto)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.idVehiculo = idVehiculo;
            this.fechaReserva = fechaReserva;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.monto = monto;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string IdCliente
        {
            set { idCliente = value; }
            get { return idCliente; }
        }
        public string IdVehiculo
        {
            set { idVehiculo = value; }
            get { return idVehiculo; }
        }
        public DateTime FechaReserva
        {
            set { fechaReserva = value; }
            get { return fechaReserva; }
        }
        public DateTime FechaInicio
        {
            set { fechaInicio = value; }
            get { return fechaInicio; }
        }
        public DateTime FechaFin
        {
            set { fechaFin = value; }
            get { return fechaFin; }
        }

        public int Monto
        {
            set { monto = value; }
            get { return monto; }
        }

        


    }
}
