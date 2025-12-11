namespace DayCare.Application.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;          
        public string Description { get; set; } = string.Empty;  
        public string RecommendedGroup { get; set; } = string.Empty; 
    }
}
