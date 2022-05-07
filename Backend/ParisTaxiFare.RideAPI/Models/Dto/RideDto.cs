namespace ParisTaxiFare.RideAPI.Models.Dto
{
    public class RideDto
    {
        public long Id { get; set; }

        public long? Distance { get; set; }

        public DateTime StartTime { get; set; }

        public long? Duration { get; set; }

        public decimal? Price { get; set; }
    }
}