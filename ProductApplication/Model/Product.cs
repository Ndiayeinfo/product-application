using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Model
{
    public class Product
    {
        public int productId { get; set; }

        [Required(ErrorMessage="Product Name is required")]
        public string? productName { get; set; }
        public double productPrice { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public bool IsExpire { get; set; }
        public DateTime DateTime { get; set; }
    }
}
