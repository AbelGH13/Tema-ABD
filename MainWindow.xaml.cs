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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ClientPageUS ClientPageUS { get; set; }
        public NewAccUC NewAccUC { get; set; }
        public AngajatUC AngajatUC { get; set; }
        

        public MainWindow()
        {
            InitializeComponent();
            AddClientPageUS();
            AddNewAccUC();
            AddAngajatUC();
        }

        private void AddClientPageUS()
        {
            ClientPageUS = new ClientPageUS();
            MainGridPanel.Children.Add(ClientPageUS);
            ClientPageUS.Visibility = Visibility.Hidden;
        }

        private void AddNewAccUC()
        {
            NewAccUC = new NewAccUC();
            MainGridPanel.Children.Add(NewAccUC);
            NewAccUC.Visibility = Visibility.Hidden;
        }

        private void AddAngajatUC()
        {
            AngajatUC = new AngajatUC();
            MainGridPanel.Children.Add(AngajatUC);
            AngajatUC.Visibility = Visibility.Hidden;
        }

        private void AutentificareButton_Click(object sender, RoutedEventArgs e)
        {
            //ClientPageUS.Visibility = Visibility.Visible;
            try
            {
                if (Utilities.VerificareEmail(EmailTextBox.Text)
                && Utilities.VerificareParola(ParolaTextBox.Text)
                && ClientRadioButton.IsChecked == true)
                {
                    ClientPageUS.SetClient(Utilities.GetName(EmailTextBox.Text), Utilities.GetFirstName(EmailTextBox.Text));
                    ClientPageUS.Visibility = Visibility.Visible;
                }
                else
                {
                    throw (new Exception());
                }

            }
            catch(Exception exception)
            {
                MessageBox.Show("Parola sau Email incorect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
           // AngajatUC.Visibility = Visibility.Visible;
        }

        private void CreeazaContButton_Click(object sender, RoutedEventArgs e)
        {
            NewAccUC.Visibility = Visibility.Visible;
        }
    }
}
