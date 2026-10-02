using Heladeria; // <-- Necesario para que reconozca las clases del proyecto Heladeria

namespace Vista_heladeria.Views
{
    public interface IClientView
    {
        // Propiedades para capturar o mostrar texto en los inputs
        string Nombre { get; set; }
        string Telefono { get; set; }

        // Métodos que la vista implementará de forma pasiva
        void MostrarClientes(IEnumerable<Cliente> clientes);
        void MostrarMensaje(string mensaje);
    }
}