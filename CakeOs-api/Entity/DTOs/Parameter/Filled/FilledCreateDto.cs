namespace CakeOs.Entity.DTOs.Parameter.Filled
{
    public class FilledCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool DefaultFilled { get; set; }
        public bool IsActive { get; set; }
    }
}