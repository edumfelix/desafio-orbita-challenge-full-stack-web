namespace WebApi.Controllers.Data.ValueObject
{
    public class StudentVO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string CPF { get; set; }
        public required string RA { get; set; }

    }
}
