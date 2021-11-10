using CarpoolingProject.Data;

namespace CarpoolingProject.Models.RequestModels
{
    public class TravelDto
    {
        public TravelDto()
        {

        }
        public TravelDto(Travel travel)
        {
            travel.TravelId = this.Id;
            travel.StartPoint = this.StartPoint;
            travel.EndPoint = this.EndPoint;
        }
        public int Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }

    }
}