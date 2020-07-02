using System.Collections.Generic;
using ScoutingPay.Interfaces;
using ScoutingPay.Models;

namespace ScoutingPay.Data.repositories
{
    public class ProductRetRepository
    {
        private readonly IProductRetrieveContext _contextRet;

        public ProductRetRepository(IProductRetrieveContext contextRet)
        {
            _contextRet = contextRet;
        }
        
        public List<Product> GetAll()
        {
            return _contextRet.GetAllProducts();
        }
        
        public Product GetById(int id)
        {
            return _contextRet.GetProductById(id);
        }
    }
}