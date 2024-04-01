using System;
using System.Drawing;
using System.Windows.Forms;

namespace controlEscritorio 
{
    public partial class Form1 : Form
    {
        private Label estadoLabel;
        private Label fechaHoraLabel;
        private Button botonIzquierda;
        private Button botonDerecha;
        private Button botonDetener;
        private Timer timer;
        private PictureBox gifMotor;

        public Form1()
        {
            InitializeComponent();
            InicializarComponentesCustom();
            ActualizarFechaHora();
        }

        private void InicializarComponentesCustom()
        {
            // Configurar PictureBox para el GIF del motor
            gifMotor = new PictureBox()
            {
                Location = new Point(5, 265), // Ajusta la ubicación según tus preferencias
                Size = new Size(200, 200), // Ajusta el tamaño según el GIF
                AutoSize = true,
                SizeMode = PictureBoxSizeMode.Zoom 
            };
            this.Controls.Add(gifMotor);
            gifMotor.Image = Image.FromFile("detenido.gif");

            // Configurar Label de estado
            estadoLabel = new Label()
            {
                
                Text = "Estado del motor: Detenido",
                Font = new Font("Arial Bold", 20),
                ForeColor = Color.Blue,
                Location = new Point(0, 100),
                AutoSize = true,
               

        };
            this.Controls.Add(estadoLabel);

            // Configurar Label de fecha y hora
            fechaHoraLabel = new Label()
            {
                Font = new Font("Arial Bold", 20),
                ForeColor = Color.Blue,
                Location = new Point(0, 200),
                AutoSize = true
            };
            this.Controls.Add(fechaHoraLabel);
            

            // Configurar botones
            botonIzquierda = new Button()
            {
                Image = Image.FromFile("flecha-izquierda.png"),
                AutoSize = true,
                Location = new Point(0, 0)
            };
            botonIzquierda.Click += (sender, e) => Izquierda();
            this.Controls.Add(botonIzquierda);

            botonDetener = new Button()
            {
                Image = Image.FromFile("pausa.png"),
                AutoSize = true,
                Location = new Point(100, 0),
                Enabled = false

            };
            botonDetener.Click += (sender, e) => Detener();
            this.Controls.Add(botonDetener);

            botonDerecha = new Button()
            {
                Image = Image.FromFile("flecha-correcta.png"),
                AutoSize = true,
                Location = new Point(200, 0)
            };
            botonDerecha.Click += (sender, e) => Derecha();
            this.Controls.Add(botonDerecha);

           //

            // Configurar timer para actualizar fecha y hora
            timer = new Timer()
            {
                Interval = 1000
            };
            timer.Tick += (sender, e) => ActualizarFechaHora();
            timer.Start();
        }

        private void Izquierda()
        {
            estadoLabel.Text = "Estado del motor: Girando en sentido antihorario";
            botonDetener.Enabled = true;
            botonDerecha.Enabled = true;
            botonIzquierda.Enabled = false;
            gifMotor.Image = Image.FromFile("izquierda.gif"); 
        }

        private void Derecha()
        {
            estadoLabel.Text = "Estado del motor: Girando en sentido horario";
            botonDetener.Enabled = true;
            botonIzquierda.Enabled = true;
            botonDerecha.Enabled = false;
            gifMotor.Image = Image.FromFile("derecha.gif"); 
        }

        private void Detener()
        {
            estadoLabel.Text = "Estado del motor: Detenido";
            botonDetener.Enabled = false;
            botonIzquierda.Enabled = true;
            botonDerecha.Enabled = true;
            gifMotor.Image = Image.FromFile("detenido.gif");
        }

        private void ActualizarFechaHora()
        {
            fechaHoraLabel.Text = DateTime.Now.ToString("HH:mm:ss - yyyy-MM-dd");
        }
    }
}