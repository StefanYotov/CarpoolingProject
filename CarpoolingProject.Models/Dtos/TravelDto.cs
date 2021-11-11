using CarpoolingProject.Data;
using System;

namespace CarpoolingProject.Services.Dtos
{
    public class TravelDto
    {
        public TravelDto(Travel travel)
        {
            this.Id = travel.TravelId;
            this.StartPoint = travel.StartPoint;
            this.EndPoint = travel.EndPoint;
            this.DepartureTime = travel.DepartureTime;
            this.FreeSeats = travel.FreeSpots;
        }
        public int Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public int FreeSeats { get; set; }
    }
}