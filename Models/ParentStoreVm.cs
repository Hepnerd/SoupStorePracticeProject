namespace SoupStorePracticeProject.Models
{
    public class ParentStoreVm
    {
        public int Id { get; set; }
        public List<Store> Stores { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
