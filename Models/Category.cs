namespace Pop_Claudia_Lab2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public required string CategoryName { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
