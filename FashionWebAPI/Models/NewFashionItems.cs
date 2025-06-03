namespace FashionWebAPI.Models
{
    public class NewFashionItems
    {
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public bool IsItemAvailable { get; set; }

    }
}
