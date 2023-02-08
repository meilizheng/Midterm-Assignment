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

namespace Midterm_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Apartment>apartments = new List<Apartment>();
        public MainWindow()
        {
            InitializeComponent();
            Preload();
            DisplayInformation();
        }
        public void Preload()
        {
            Random rand = new Random();
            for (int i = 100; i < 301; i++)
            {
                string apart = "H" + i;
                if (rand.Next(2) != 0)
                {
                    decimal monthly = rand.Next(1500, 4500);
                    float bedrooms = rand.Next(1, 4);
                    //Apartment apartment = new Apartment(apart, "Alisa", "Bobik", bedrooms, monthly);
                    //apartments.Add(apartment);
                    //apartments.Add(new Apartment(apart, "Meili", "Zheng", bedrooms, monthly));
                    //apartments.Add(new Apartment(apart, "Robert", "Kwan", bedrooms, monthly));
                    //apartments.Add(new Apartment(apart, "Oliva", "Park", bedrooms, monthly));
                    //apartments.Add(new Apartment(apart, "Sara", "Smith", bedrooms, monthly));
                }
                else
                {
                    apartments.Add(new Apartment(apart, false));
                }
            }
        }

        private void btnAddUpdateTenant_Click(object sender, RoutedEventArgs e)
        {
            string ApartNumber = txtAptNum.Text;
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string MonthlyPay = txtMontylyPayments.Text;
            string TotalBedRoom = txtTotalbedroom.Text;
            string TennantInformation = $"Apart#: {ApartNumber} - First Name: {FirstName}- Last Name: {LastName} - Monthly Payment: {MonthlyPay} - Total Bedroom: {TotalBedRoom}";
            lbDisplayTennantInfo.Items.Add(TennantInformation);            
        }

        public void DisplayInformation()
        {
            lbDisplayTennantInfo.Items.Clear();

            for (int i = 0; i < apartments.Count; i++)
            {
                lbDisplayTennantInfo.Items.Add(apartments[i]);
            }
        }

       
    }
}
