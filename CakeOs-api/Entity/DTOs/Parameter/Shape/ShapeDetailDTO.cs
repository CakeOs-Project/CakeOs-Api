namespace CakeOs.Entity.DTOs.Parameter.Shape
{
    public class ShapeDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

}