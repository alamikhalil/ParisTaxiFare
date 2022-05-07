namespace ParisTaxiFare.RideAPI.Models.Dto
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; } = true;

        public List<string> ErrorMessage { get; set; }

        public object Result { get; set; }
    }
}
