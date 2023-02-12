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
//Meili Zheng;
//Midterm Assignment;
//2/10/2023;

namespace Midterm_Assignment
{
    public partial class MainWindow : Window
    {
        List<Apartment> apartments = new List<Apartment>();
        Apartment selectedApartment = null;

        public MainWindow()
        {
            InitializeComponent();

            Preload(); 
          
            DisplayTennantInformation();

            ShowTotalApartment();
        }

  
        public void Preload()
        {
            Random rand = new Random();

            for (int i = 100; i < 301; i++)
            {
                string apart = "H" + i;
                if (rand.Next(2) != 0) // 1
                {
                    decimal monthly = rand.Next(1500, 4500);
                    float bedrooms = rand.Next(1, 4);
                    
                    apartments.Add(new Apartment(apart, "Alisa", "Bobik", bedrooms, monthly));
                    apartments.Add(new Apartment(apart, "Meili", "Zheng", bedrooms, monthly));
                    apartments.Add(new Apartment(apart, "Robert", "Kwan", bedrooms, monthly));
                    apartments.Add(new Apartment(apart, "Oliva", "Park", bedrooms, monthly));
                    apartments.Add(new Apartment(apart, "Sara", "Smith", bedrooms, monthly));
                }
                else // 0
                {
                    apartments.Add(new Apartment(apart, false));
                }
            }
        }

        private void btnDisplayTennant_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbDisplayTennantInfo.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Please select a tennant from the list box");
            }
            else
            {
                DisplayApartmentInfor(selectedApartment);
            }
        }

       
        private void btnAddUpdateTenant_Click(object sender, RoutedEventArgs e)
        {
            // ADD
            if (lbDisplayTennantInfo.SelectedIndex == -1)
            {
                string ApartNumber = txtAptNum.Text;
                string FirstName = txtFirstName.Text;
                string LastName = txtLastName.Text;
                string MonthlyPay = txtMontylyPayments.Text;
                string TotalBedRoom = txtTotalbedroom.Text;
                string TennantInformation = $"Apart#: {ApartNumber} - First Name: {FirstName}- Last Name: {LastName} - Monthly Payment: {MonthlyPay} - Total Bedroom: {TotalBedRoom}";
                lbDisplayTennantInfo.Items.Add(TennantInformation);  
                rtbDisplay.AppendText("\n" + TennantInformation + " " + "Added!");
                lbDisplayTennantInfo.Items.Refresh();
                ShowTotalApartment();                
            }
            // UPDATE
            else
            {
                string TennantInformation = $"Apart#: {txtAptNum.Text} - First Name: {txtFirstName.Text}- Last Name: {txtLastName.Text} - Monthly Payment: {txtMontylyPayments.Text} - Total Bedroom: {txtTotalbedroom.Text}";
                
                Apartment selectedApt = (Apartment)lbDisplayTennantInfo.SelectedItem;

                selectedApt.FirstName = txtFirstName.Text;
                selectedApt.LastName = txtLastName.Text;
                selectedApt.ApartmentNumber = txtAptNum.Text;
                selectedApt.MonthlyPayment = decimal.Parse(txtMontylyPayments.Text);
                selectedApt.NumberOfBedrooms = float.Parse(txtTotalbedroom.Text);

                lbDisplayTennantInfo.Items.Refresh(); // refreh updated data                
                rtbDisplay.AppendText("\n" + TennantInformation + " " + "Updated!");                
            }  
        }


        public void DisplayTennantInformation()
        {
            lbDisplayTennantInfo.Items.Clear();
           
            foreach (var item in apartments)
            {
                lbDisplayTennantInfo.Items.Add(item);
            }
        }

        
        private void btnRemoveTennant_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbDisplayTennantInfo.SelectedIndex;
            apartments.RemoveAt(selectedIndex);
            //lbDisplayTennantInfo.Items.RemoveAt(lbDisplayTennantInfo.SelectedIndex);
            lbDisplayTennantInfo.Items.Refresh();
            string DisplayNotes = $"\n{apartments[selectedIndex]} Removed!";
            rtbDisplay.AppendText(DisplayNotes);           
            DisplayTennantInformation();            
        }           
              

        public void DisplayApartmentInfor(Apartment apartment)
        {
            // populate the list of textboxes
            txtFirstName.Text = apartment.FirstName;
            txtLastName.Text = apartment.LastName;
            txtMontylyPayments.Text = apartment.MonthlyPayment.ToString();
            txtTotalbedroom.Text = apartment.NumberOfBedrooms.ToString();
            txtAptNum.Text = apartment.ApartmentNumber.ToString();
            int occupied = OccupiedVacant(apartments);
            txtoccupied.Text = occupied.ToString();
            txtvacant.Text = (apartments.Count - occupied).ToString();

            // right area for making full payment or partial payment
            txtPayInFull.Text = apartment.MonthlyPayment.ToString();            
            txtCurrentDue.Text = (decimal.Parse(txtPayInFull.Text) /3).ToString();
        }

        private void lbDisplayTennantInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTotalApartment();
           if (lbDisplayTennantInfo.SelectedIndex == -1)
            {
                return;
            }
            selectedApartment = apartments[lbDisplayTennantInfo.SelectedIndex];
            DisplayApartmentInfor(selectedApartment);
        }

    
        public void ShowTotalApartment()
        {          
            txtTotalAppartments.Text = lbDisplayTennantInfo.Items.Count.ToString();
        }

       public int OccupiedVacant(List<Apartment> apartments)
        {
            int ocuupied = 0;
            
            foreach(Apartment apartment in apartments)
            {
                if (apartment.IsOccupied)
                {
                    ocuupied++;
                }               
            }
            return ocuupied;
        }

        private void btnPaymentInFull_Click(object sender, RoutedEventArgs e)
        {
            Apartment selectedPay = (Apartment)lbDisplayTennantInfo.SelectedItem;
            
            txtPayInFull.Text = (selectedPay.MonthlyPayment).ToString();            
        }

        private void btnPartialPayment_Click(object sender, RoutedEventArgs e)
        {
            decimal result = 0;
            Apartment selectedPartialPay = (Apartment)lbDisplayTennantInfo.SelectedItem;
            bool IsANumber = decimal .TryParse(txtPartialPayment.Text, out result);
            if (IsANumber)
            {
                decimal PartialPay = decimal.Parse(txtPartialPayment.Text);

                decimal RestOfPay = selectedPartialPay.MonthlyPayment - PartialPay;
                string restOfPayment = RestOfPay.ToString();
                rtbDisplay.AppendText($" \n your Outstanding balance is $ {restOfPayment} \n");
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }           
        }

        private void btnMonthlyDue_Click(object sender, RoutedEventArgs e)
        {
            Apartment selectedtennant = (Apartment)lbDisplayTennantInfo.SelectedItem;
            rtbDisplay.AppendText($" \n your Month Due is {selectedtennant.MonthlyPayment}");
        }
    }  
}

