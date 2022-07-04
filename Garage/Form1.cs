namespace Garage
{
    using CarLibrary;
    public partial class Form1 : Form
    {
        Bus bus = new Bus(70, 60, 25, 14);
        Truck truck = new Truck(90, 40, 2000, 500);
        System.Windows.Forms.Timer tim;
        Thread[] tbus;
        Random delay = new Random();
        public Form1()
        {
            InitializeComponent();
            Weight.Text = truck.Cargo.ToString();
            tbus = new[] {new Thread(
                new ThreadStart(UpBus)),
                new Thread
                (new ThreadStart(DownBus))};
            tbus[0].Start();
            tbus[1].Start();
            tim = new System.Windows.Forms.Timer();
            tim.Interval = 10;
            tim.Tick += new EventHandler(tim_Tick);
            tim.Start();
        }

        private void tim_Tick(object? sender, EventArgs e)
        {
            NbPassengers.Text = bus.Passengers.ToString();
        }

        void UpBus()
        {
            while (true)
            {
                lock (this)
                {
                    bus.Up();
                }
                Thread.Sleep(delay.Next(500) + delay.
                Next(500));
            }
        }
        void DownBus()
        {
            while (true)
            {
                lock (this)
                {
                    bus.Down();
                }
                Thread.Sleep(delay.Next(500) + delay.
                Next(500));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            truck.Up();
            Weight.Text = truck.Cargo.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            truck.Down();
            Weight.Text = truck.Cargo.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tbus[0].Abort();
                tbus[1].Abort();
            }
            finally
            {

            }
        }
    }
}