namespace OA.Service.Implementation.UserServices.Dtos
{
    public class StudentLoginResponseDto
    {
        public string Token { get; set; }

        public bool isExist { get; set; }

        public string Password { get; set; }

        public string Message { get; set; }

        public string Role { get; set; }
    }
}