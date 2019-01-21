using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoWash
{
    /// <summary>
    /// Interaction logic for ClientPageUS.xaml
    /// </summary>
    public partial class ClientPageUS : UserControl
    {
        private Client Client { get; set; }
        private List<Programari> appointments;
        public ClientPageUS()
        {
            InitializeComponent();
            Client = new Client();

            appointments = GetAppointments();
            DataContext = appointments;
        }

        

        private void ProgrameazaButton_Click(object sender, RoutedEventArgs e)
        {
            using (var data = new SpalatorieEntities())
            {
                Appointment Programare = new Appointment();

                Programari programare = new Programari();//DateTime.Parse(DataTextBox.Text),
                 //   TimeSpan.Parse(OraTextBox.Text), MasinaTextBox.Text);
                try
                {

                }
                catch(Exception exception)
                {
                    
                }
                data.Programari.Add(programare);
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private List<Programari> GetAppointments()
        {
            using (var data = new SpalatorieEntities())
            {
                return data.Programari.ToList<Programari>();
            }
        }
        private void CreateAppointment(Appointment appointment, SpalatorieEntities data)
        {
           
        }
        public void SetClient(string nume, string prenume)
        {
            Client.Nume = nume;
            Client.Prenume = prenume;
        }
    }
}
