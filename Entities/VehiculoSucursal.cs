using System;

namespace Entities
{
    public class VehiculoSucursal
    {
        private int id;
        private DateTime fecha;
        private Sucursal sucursal;
        private string idVehiculo;

        public VehiculoSucursal()
        { }

        public VehiculoSucursal(
            int id,
            DateTime fecha,
            Sucursal sucursal,
            string idVehiculo)
        {
            this.id = id;
            this.fecha = fecha;
            this.sucursal = sucursal;
            this.idVehiculo = idVehiculo;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public DateTime Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }

        public Sucursal Sucursal
        {
            set { sucursal = value; }
            get { return sucursal; }
        }

        public String IdVehiculo
        {
            set { idVehiculo = value; }
            get { return idVehiculo; }
        }
    }
}
