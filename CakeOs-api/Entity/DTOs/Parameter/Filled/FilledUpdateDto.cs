namespace CakeOs.Entity.DTOs.Parameter.Filled
{
    public class FilledUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool DefaultFilled { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}