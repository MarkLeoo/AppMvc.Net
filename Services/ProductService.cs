using App.Models;

namespace App.Service
{
    public class ProductService : List<ProductViewModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductViewModel[] {
                new ProductViewModel() { Id = 1, Name = "Iphone X", Price = 1000},
                new ProductViewModel() { Id = 2, Name = "Samsung", Price = 2000},
                new ProductViewModel() { Id = 3, Name = "Nokia", Price = 3000}
            });
        }
    }
}