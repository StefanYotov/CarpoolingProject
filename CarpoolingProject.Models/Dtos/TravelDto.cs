using CarpoolingProject.Models.EntityModels;
using System;

namespace CarpoolingProject.Services.Dtos
{
    public class TravelDto
    {
        public TravelDto(Travel travel)
        {
            this.StartPoint = travel.StartPoint;
            this.EndPoint = travel.EndPoint;
            this.DepartureTime = travel.DepartureTime;
            this.FreeSeats = travel.FreeSpots;
        }
        
        public Address StartPoint { get; set; }
        public Address EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public int FreeSeats { get; set; }
    }
}