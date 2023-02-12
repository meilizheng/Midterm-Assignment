using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Assignment
{
    public class Apartment
    {
        string apartmentNumber;
        string firstName;
        string lastName;
        float numberOfBedrooms;
        decimal monthlyPayment;
        decimal currentBalance;        
        string apartmentNotes = string.Empty;
        bool isOccupied;

        public Apartment(string apartmentNumber, string firstName, string lastName, float numberOfBedrooms, decimal monthlyPayment)
        {
            this.apartmentNumber = apartmentNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.numberOfBedrooms = numberOfBedrooms;
            this.monthlyPayment = monthlyPayment;

            this.isOccupied = true; 
        }

        public Apartment(string apartmentNumber, bool isOccupied)
        {            
            this.apartmentNumber = apartmentNumber;
            this.isOccupied = isOccupied;
        }

        public Apartment(string firstName, string lastName, decimal monthlyPayment)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.monthlyPayment = monthlyPayment;

            this.isOccupied = true;
        }

        public string ApartmentNumber { get => apartmentNumber; set => apartmentNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public float NumberOfBedrooms { get => numberOfBedrooms; set => numberOfBedrooms = value; }
        public decimal MonthlyPayment { get => monthlyPayment; set => monthlyPayment = value; }
        public decimal CurrentBalance { get => currentBalance; set => currentBalance = value; }
        public string ApartmentNote { get => apartmentNotes; set => apartmentNotes = value; }
        
        public bool IsOccupied { get => isOccupied; set => isOccupied = value; }

        public override string ToString()
        {

            if (isOccupied)
            {
                return $"Apartment#: {apartmentNumber} -- First Name: {firstName} -- Last Name: {lastName} -- Total of bedroom: {numberOfBedrooms} -- Monthly Payment: ${monthlyPayment}";
            }
            else
            {
                return $"Apartment#: {apartmentNumber} -- vacant";
            }
        }       
    }
}
