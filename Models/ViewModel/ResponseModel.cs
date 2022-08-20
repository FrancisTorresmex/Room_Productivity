namespace Room_Productivity.Models.ViewModel
{
    public class ResponseModel
    {
        public string Error { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }

        public ResponseModel()
        {
            Status = 200; //valor defecto 
            Message = "Ok";
        }
    }
}
