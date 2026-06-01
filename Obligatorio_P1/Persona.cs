using Logica;

namespace Obligatorio_P1
{
    public class Persona
    {
        private int _cedula { get; set; }
        private string _nombre;
        private string _email;
        private int _telefono;
        private Cargo _cargo;

        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public Cargo Cargo { get; set; }

        public Persona(int cedula, string nombre, string email, int telefono, Cargo cargo)
        {
            _cedula = cedula;
            _nombre = nombre;
            _email = email;
            _telefono = telefono;
            _cargo = cargo;
        }

        public void validarNombre() 
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("el nombre no puede estar vacio");
        }

        public void validarEmail() 
        {
            if (string.IsNullOrEmpty(_email)) throw new Exception("El email no puede estar vacío");

            if (_email.IndexOf('@') == -1) 
            { 
                throw new Exception("El email debe contener una arroba (@)");
            }

        }

        public void validacion()
        {
            validarNombre();
            validarEmail();

        }

        
        public override bool Equals(object? obj)
        {
            return obj is Persona p && _cedula.Equals(p._cedula);
        }

        public override string ToString()
        {
            return $"Cédula: {Cedula}, Nombre: {Nombre}, Email: {Email}, Teléfono: {Telefono}";
        }

       
    }
}
