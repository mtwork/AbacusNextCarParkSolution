using System;

namespace AbacusNext_CarParkSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Parking.");
        
            ParkingCharges pc = new ParkingCharges(StayType.ShortStay, new DateTime(2017, 09, 07, 16, 50, 00), new DateTime(2017, 09, 09, 19, 15, 00));
            var charges = pc.CalculateCharges();

            Console.WriteLine("Parking charges: £" + charges);
            Console.ReadLine();
        }
    }
}
