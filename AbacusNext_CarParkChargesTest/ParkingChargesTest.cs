using System;
using Xunit;
using AbacusNext_CarParkSolution;

namespace AbacusNext_CarParkChargesTest
{
    public class ParkingChargesTest
    {
        [Fact]
        public void ShortStay_two_hours_aseert_Test()
        {
            var startTime = new DateTime(2017, 09, 07, 16, 50, 0);
            var endTime = new DateTime(2017, 09, 07, 19, 15, 0);
            ParkingCharges parkingCharges = new ParkingCharges(StayType.ShortStay, startTime, endTime);
            var result = parkingCharges.CalculateCharges();

            Assert.Equal(2.2, result);
        }
        

        [Fact]
        public void ShortStay_Out_of_Business_hours_Test()
        {
            var startTime = new DateTime(2017, 09, 09, 18, 00, 0);
            var endTime = new DateTime(2017, 09, 09, 19, 15, 0);
            ParkingCharges parkingCharges = new ParkingCharges(StayType.ShortStay, startTime, endTime);
            var result = parkingCharges.CalculateCharges();

            Assert.Equal(0.00, result);
        }

        [Fact]
        public void ShortStay_Weekend_Test()
        {
            var startTime = new DateTime(2017, 09, 09, 11, 00, 0);
            var endTime = new DateTime(2017, 09, 09, 19, 15, 0);
            ParkingCharges parkingCharges = new ParkingCharges(StayType.ShortStay, startTime, endTime);
            var result = parkingCharges.CalculateCharges();

            Assert.Equal(0.00, result);
        }

        [Fact]
        public void ShortStay_Multiple_Days_including_weekend()
        {
            var startTime = new DateTime(2017, 09, 07, 16, 50, 0);
            var endTime = new DateTime(2017, 09, 09, 19, 15, 0);
            ParkingCharges parkingCharges = new ParkingCharges(StayType.ShortStay, startTime, endTime);
            var result = parkingCharges.CalculateCharges();
            //As mentioned in assignment charges should be 12.28 but i think it should be 12.20 for twelve hours (please advice if need to amend this)
            // 07 Sep 2019 16:50 - 18:00 :  1 hour 10 min
            // 08 Sep 2019 08:00- 1800 : 10 houes 
            // 1:10 + 10 = 11:10-  for extra 10 min 1 hour will be added so it will be 12 hours charges = 1.1* 12 = 13.20  
            Assert.Equal(13.2, result);
        }

        [Fact]
        public void ShortStay_Multiple_Failed_Test()
        {
            var startTime = new DateTime(2017, 09, 07, 16, 50, 0);
            var endTime = new DateTime(2017, 09, 09, 19, 15, 0);
            ParkingCharges parkingCharges = new ParkingCharges(StayType.ShortStay, startTime, endTime);
            var result = parkingCharges.CalculateCharges();
                      
            Assert.NotEqual(12.20, result);
        }

        [Fact]
        public void LongStay_Test()
        {
            var startTime = new DateTime(2017, 09, 07, 7, 50, 0);
            var endTime = new DateTime(2017, 09, 09, 5, 20, 0);
            ParkingCharges parkingCharges = new ParkingCharges(StayType.LongStay, startTime, endTime);
            var result = parkingCharges.CalculateCharges();

            Assert.Equal(22.50, result);
        }

        [Fact]
        public void LongStayFailedTest()
        {
            var startTime = new DateTime(2017, 09, 07, 07, 50, 0);
            var endTime = new DateTime(2017, 09, 09, 5, 20, 0);
            ParkingCharges parkingCharges = new ParkingCharges(StayType.LongStay, startTime, endTime);
            var result = parkingCharges.CalculateCharges();

            Assert.NotEqual(20.5, result);
        }
    }
}
