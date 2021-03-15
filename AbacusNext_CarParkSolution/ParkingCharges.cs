using System;

namespace AbacusNext_CarParkSolution
{
    public class ParkingCharges
    {
        
        public const double feePerHour = 1.10;
        public const double feePerDay = 7.50;

        public StayType stayType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ParkingCharges(StayType _stayType,DateTime _startTime,DateTime _endTime)
        {
            stayType = _stayType;
            StartTime = _startTime;
            EndTime = _endTime;
        }

        public double CalculateCharges()
        {
            double charges = 0;           

            switch (stayType)
            {
                case StayType.ShortStay:                    
                    var hours = GetParkingChargeHours(StartTime, EndTime);                                                                              
                    charges = hours * feePerHour;
                    break;
                case StayType.LongStay:
                    var days = (EndTime.Date - StartTime.Date).TotalDays + 1;
                    charges = days * feePerDay;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid Value for StayType"); 
                    break;
            }

            return Math.Round(charges,2); 
        }

        private int GetParkingChargeHours(DateTime from, DateTime to)
        {            
            int Hours = 0;

            for (var i = from; i < to; i = i.AddHours(1))
            {
                if((i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday) &&
                     (i.TimeOfDay.Hours >= 8 && i.TimeOfDay.Hours < 18))                                 
                        Hours++;                                 
            }

            return Hours;

        }
    }   

    public enum StayType 
    {
        ShortStay,
        LongStay
    }
}
