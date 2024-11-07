namespace PostLand_Api.Model
{
    public class Authmodel
    {
        public string? Message { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
        public DateTime Expired { get; set; }
        public string? Username { get; set; }

    }
}
