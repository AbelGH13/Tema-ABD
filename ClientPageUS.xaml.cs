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
        private List<Appointment> appointments;
        public ClientPageUS()
        {
            InitializeComponent();
            Client = new Client();
            CreateAppointments();
            DataContext = appointments;
        }

        

        private void ProgrameazaButton_Click(object sender, RoutedEventArgs e)
        {
            using (var data = new SpalatorieEntities())
            {
                Programari programare = new Programari()
                {
                    ClientID = data.Clienti.First(c => c.Nume == Client.Nume).ClientID, 
                    Data = DateTime.Parse(DataTextBox.Text),
                    NumarInmatriculare = NrMasinaTextBox.Text,
                    Ora = TimeSpan.Parse(OraTextBox.Text),
                    TipulSpalarii = TipSpalareTextBox.Text
                };
                try
                {
                    if (data.Programari.Find(programare.Ora) != null)
                    {
                        throw (new Exception());
                    }
                    else
                    {
                        data.Programari.Add(programare);
                        MessageBox.Show("Programarea a fost realizata cu succes!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Exista deja o programare la aceasta ora", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void CreateAppointments()
        {
            int i = 0;
            using (var data = new SpalatorieEntities())
            {
                foreach (var programare in data.Programari)
                {
                    if(programare.ClientID == data.Clienti.First(c => c.Nume == Client.Nume).ClientID)
                    {
                        appointments[i] = new Appointment()
                        {
                            ClientName = Client.Nume,
                            ClientFirstName = Client.Prenume,
                            CarNumber = programare.NumarInmatriculare,
                            Date = programare.Data,
                            Hour = programare.Ora,
                            WashType = programare.TipulSpalarii
                        };
                        if (data.Clienti.First(c => c.Nume == Client.Nume).TipClient == "Permanent")
                        {
                            appointments[i].Cost = data.ServiciiSpalatorie.First(c => c.TipSpalare == programare.TipulSpalarii).PretRedus;
                        }
                        else appointments[i].Cost = data.ServiciiSpalatorie.First(c => c.TipSpalare == programare.TipulSpalarii).Pret;
                        i++;
                    }
                }
            }
        }
        public void SetClient(string nume, string prenume)
        {
            Client.Nume = nume;
            Client.Prenume = prenume;
        }
    }
}
