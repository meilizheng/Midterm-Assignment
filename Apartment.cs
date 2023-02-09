using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Assignment
{
    public class Apartment
    {
        string ApartmentNumber;
        string FirstName;
        string LastName;
        float numberOfBedrooms;
        decimal MonthlyPayment;
        decimal CurrentBalance;        
        string ApartmentNotes;
        bool isOccupied;

        public Apartment(string apartmentNumber, string firstName, string lastName, float numberOfBedrooms, decimal monthlyPayment)
        {
            Random random = new Random();
            ApartmentNumber = apartmentNumber;
            FirstName = firstName;
            LastName = lastName;
            this.numberOfBedrooms = numberOfBedrooms;
            MonthlyPayment = monthlyPayment;
            this.isOccupied = true;
        }

        public Apartment(string apartmentNumber, bool IsOccupied)
        {
            Random random = new Random();
            this.ApartmentNumber = apartmentNumber;
            this.isOccupied = false;
        }       

        public string ApartmentNumber1 { get => ApartmentNumber; set => ApartmentNumber = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public float NumberOfBedrooms { get => numberOfBedrooms; set => numberOfBedrooms = value; }
        public decimal MonthlyPayment1 { get => MonthlyPayment; set => MonthlyPayment = value; }
        public decimal CurrentBalance1 { get => CurrentBalance; set => CurrentBalance = value; }
        public string ApartmentNotes1 { get => ApartmentNotes; set => ApartmentNotes = value; }
        public bool IsOccupied { get => isOccupied; set => isOccupied = value; }

        public override string ToString()
        {

            if (isOccupied)
            {
                return $"Apartment#: {ApartmentNumber} -- First Name: {FirstName} -- Last Name: {LastName} -- Total of bedroom: {numberOfBedrooms} -- Monthly Payment: ${MonthlyPayment}";
            }
            else
            {
                return $"Apartment#: {ApartmentNumber} -- vacant";
            }
        }
    }
}
