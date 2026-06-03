using Logica;

namespace Obligatorio_P1
{
    public class Persona
    {

        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int Telefono { get; set; }
        public Cargo Cargo { get; set; }

        public Persona(int cedula, string nombre, string email, string contraseña, int telefono, Cargo cargo)
        {
            Cedula = cedula;
            Nombre = nombre;
            Email = email;
            Contraseña = contraseña; 
            Telefono = telefono;
            Cargo = cargo;
        }

        public void validarNombre() 
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("el nombre no puede estar vacio");
        }

        public void validarEmail() 
        {
            if (string.IsNullOrEmpty(Email)) throw new Exception("El email no puede estar vacío");

            if (Email.IndexOf('@') == -1) 
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
            return obj is Persona p && Cedula.Equals(p.Cedula);
        }

        public override string ToString()
        {
            return $"Cédula: {Cedula}, Nombre: {Nombre}, Email: {Email}, Teléfono: {Telefono}";
        }

       
    }
}
