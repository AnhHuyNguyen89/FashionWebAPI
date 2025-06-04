namespace FashionWebAPI.Models
{
    public class NewFashionItems
    {
        //Declare and store all database
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public bool IsItemAvailable { get; set; }

    }
}
