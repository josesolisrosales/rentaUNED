namespace Entities
{
    public class Sucursal
    {
        private int id;
        private string nombre;
        private string direccion;
        private bool estado;
        private string telefono;
        public Sucursal()
        { }
        public Sucursal(int id, string nombre, string direccion, bool estado, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.estado = estado;
            this.telefono = telefono;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public string Direccion
        {
            set { direccion = value; }
            get { return direccion; }
        }

        public bool Estado
        {
            set { estado = value; }
            get { return estado; }
        }

        public string Telefono
        {
            set { telefono = value; }
            get { return telefono; }
        }
    }
}
