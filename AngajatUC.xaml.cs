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
    /// Interaction logic for AngajatUC.xaml
    /// </summary>
    public partial class AngajatUC : UserControl
    {
        private List<Appointment> allAppointments;
        private List<Appointment> acceptedAppointments;
        private Angajat angajat;

        public void InitializeProperties()
        {
            angajat = new Angajat();
            allAppointments = new List<Appointment>();
            acceptedAppointments = new List<Appointment>();
        }

        public AngajatUC()
        {
            InitializeComponent();
            InitializeProperties();
            ProgramariDataGrid.DataContext = allAppointments;
            ProgramariAcceptateDataGrid.DataContext = acceptedAppointments;
        }

        private Refresh()
        {
            ProgramariDataGrid.DataContext = allAppointments;
            ProgramariAcceptateDataGrid.DataContext = acceptedAppointments;
        }

        private void CreateAppointments()
        {
            int i = 0;
            using (var data = new SpalatorieEntities())
            {
                foreach (var programare in data.Programari)
                {
                    if (programare.MuncitorID == data.Muncitori.First(c => c.Nume == angajat.Nume).MuncitorID)
                    {
                        allAppointments[i] = new Appointment()
                        {
                            CarNumber = programare.NumarInmatriculare,
                            ClientFirstName = data.Clienti.First(c => c.ClientID == programare.ClientID).Prenume,
                            ClientName = data.Clienti.First(c => c.ClientID == programare.ClientID).Nume,
                            Date = programare.Data,
                            Hour = programare.Ora,
                            WashType = programare.TipulSpalarii
                        };
                        if (data.Clienti.First(c => c.Nume == allAppointments[i].ClientName).TipClient == "Permanent")
                            allAppointments[i].Cost = data.ServiciiSpalatorie.First(c => c.TipSpalare == programare.TipulSpalarii).PretRedus;
                        else allAppointments[i].Cost = data.ServiciiSpalatorie.First(c => c.TipSpalare == programare.TipulSpalarii).Pret;
                    }
                }
            }     
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            acceptedAppointments.Add(allAppointments[ProgramariDataGrid.SelectedIndex]);
            string nume = allAppointments[ProgramariDataGrid.SelectedIndex].ClientName;
            allAppointments.Remove(allAppointments[ProgramariDataGrid.SelectedIndex]);
            
            using (var data = new SpalatorieEntities())
            {
                data.Programari.Remove(data.Programari.First(c => c.Clienti.Nume == nume));
            }
                ProgramariAcceptateDataGrid.DataContext = acceptedAppointments;
        }

        public void SetAngajat(string nume, string prenume)
        {
            angajat.Nume = nume;
            angajat.Prenume = prenume;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            string nume = acceptedAppointments[ProgramariAcceptateDataGrid.SelectedIndex].ClientName;
            using (var data = new SpalatorieEntities())
            {
                IstoricProgramari programare;
                programare = SetProgramare(data, nume);
                data.IstoricProgramari.Add(programare);
                acceptedAppointments.Remove(acceptedAppointments[ProgramariAcceptateDataGrid.SelectedIndex]);
            }
        }

        private IstoricProgramari SetProgramare(SpalatorieEntities data, string nume)
        {
            IstoricProgramari programare = new IstoricProgramari()
            {  
                Data = acceptedAppointments.First(c => c.ClientName == nume).Date,
                MuncitorID = data.Muncitori.First(c => c.Nume == angajat.Nume).MuncitorID,
                NumarInmatriculare = data.Clienti.First(c => c.Nume == nume).NumarInmatriculare,
                ClientID = data.Clienti.First(c => c.Nume == nume).ClientID,
                NumarTelefon = data.Clienti.First(c => c.Nume == nume).NumarTelefon,
                Ora = acceptedAppointments.First(c => c.ClientName == nume).Hour,
                TipulSpalarii = acceptedAppointments.First(c => c.ClientName == nume).WashType
            };
            return programare;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
