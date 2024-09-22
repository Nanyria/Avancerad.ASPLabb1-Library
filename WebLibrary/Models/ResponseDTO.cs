namespace WebLibrary.Models
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public Object Result { get; set; }
        public string DisplayMessages { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
