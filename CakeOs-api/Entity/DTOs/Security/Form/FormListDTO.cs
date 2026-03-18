namespace CakeOS.Entity.DTOs.Security.Form
{
    public class FormListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public bool IsActive { get; set; }
    }
}