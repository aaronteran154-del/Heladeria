using Heladeria;
using Microsoft.EntityFrameworkCore;
using Vista_heladeria.Views;

namespace Vista_heladeria.Presenters
{
    public class ClientPresenter
    {
        private readonly IClientView _view;
        private readonly HeladeriaDbContext _context;

        public ClientPresenter(IClientView view, HeladeriaDbContext context)
        {
            _view = view;
            _context = context;
        }

        // Método para cargar los clientes desde la base de datos y pasarlos a la vista
        public async Task CargarClientesAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();
            _view.MostrarClientes(clientes);
        }

        // Método para registrar un nuevo cliente validando que el campo no esté vacío
        public async Task GuardarClienteAsync()
        {
            if (string.IsNullOrWhiteSpace(_view.Nombre))
            {
                _view.MostrarMensaje("El nombre del cliente es obligatorio.");
                return;
            }

            var nuevoCliente = new Cliente
            {
                Nombre = _view.Nombre,
                Telefono = _view.Telefono
            };

            _context.Clientes.Add(nuevoCliente);
            await _context.SaveChangesAsync();

            _view.MostrarMensaje("¡Cliente registrado correctamente!");
            await CargarClientesAsync(); // Refresca la lista en pantalla
        }
    }
}