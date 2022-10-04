using System.ComponentModel.DataAnnotations;

namespace SoupStorePracticeProject.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string product { get; set; }
        public string price { get; set; }
        public string picture { get; set; }

        public Store()
        {

        }
    }
}
