namespace Entities
{
    public class TipoVehiculo
    {
        private int id;
        private string descripcion;
        private bool estado;

        public TipoVehiculo()
        { }

        public TipoVehiculo(
            int id,
            string descripcion,
            bool estado
            )
        {
            this.id = id;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public bool Estado
        {
            set { estado = value; }
            get { return estado; }
        }
    }
}
