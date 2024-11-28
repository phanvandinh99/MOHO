namespace Ecommerce.Data.ViewModel
{
    public class UpdateProductViewModel
    {
        public string Name { set; get; }
        public string? UrlImage { set; get; }
        public string? Description { set; get; }

        public decimal Price { set; get; }
        public decimal? OriginalPrice { set; get; }

        public string Details { set; get; }
        public int Quantity { set; get; }

        public int Stock { set; get; }


        public int? CategoryId { set; get; }
    }
}
