using System.Collections.Generic;
using ScoutingPay.Models;

namespace ScoutingPay.Interfaces
{
    public interface IProductRetrieveContext
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
    }
}