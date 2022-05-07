namespace ParisTaxiFare.RideAPI.Data.Dao
{
    public partial class RideDao
    {
        public long Id { get; set; }

        public long? Distance { get; set; }

        public string? StartTime { get; set; }

        public long? Duration { get; set; }
    }
}