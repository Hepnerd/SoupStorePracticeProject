namespace SoupStorePracticeProject.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string product { get; set; }
        public int quantity { get; set; }
        public string price { get; set; }
        public string user { get; set; }
        public Cart()
        {

        }
    }
}
