namespace CakeOs.Entity.DTOs.Parameter.Shape
{
    public class ShapeUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}