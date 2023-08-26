using VFT.CMS.Core;

namespace VFT.CMS.Client.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total
        {
            get { return Quantity * Price; }
        }
        public string Image { get; set; }

        public CartItem() { }

        public CartItem(Product product)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            Price = (int)product.Price;
            Quantity = 1;
            Image = product.Image;

        }
    }
}
