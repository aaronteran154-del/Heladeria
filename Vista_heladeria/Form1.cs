using Heladeria;
using Microsoft.EntityFrameworkCore;
using Vista_heladeria.Presenters;
using Vista_heladeria.Views;

namespace Vista_heladeria
{
    public partial class Form1 : Form, IClientView
    {
        private readonly ClientPresenter _presenter;
        private readonly HeladeriaDbContext _context;

        // Mapeamos las propiedades de la interfaz a los nombres base del diseñador
        public string Nombre
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public string Telefono
        {
            get => textBox2.Text;
            set => textBox2.Text = value;
        }

        public Form1()
        {
            InitializeComponent();

            // Configura tu cadena de conexión a PostgreSQL
            var optionsBuilder = new DbContextOptionsBuilder<HeladeriaDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=Heladeria;Username=postgres;Password=Poporopo.2000");
            _context = new HeladeriaDbContext(optionsBuilder.Options);

            _presenter = new ClientPresenter(this, _context);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await _presenter.CargarClientesAsync();
        }

        public async void btnGuardar_Click(object sender, EventArgs e)
        {
            await _presenter.GuardarClienteAsync();
        }

        public void MostrarClientes(IEnumerable<Cliente> clientes)
        {
            dataGridView1.DataSource = clientes.ToList();
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}