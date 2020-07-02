using System.Collections.Generic;
using System.Data;
using ScoutingPay.Data.datasetparsers;
using ScoutingPay.Interfaces;
using ScoutingPay.Models;

namespace ScoutingPay.Data.mssql
{
    public class ProductMssqlContext : BaseMssqlContext, IProductRetrieveContext
    {
        public ProductMssqlContext(string connString) : base(connString)
        {
            
        }


        public List<Product> GetAllProducts()
        {
            string query = "SELECT * FROM producten";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            DataSet results = ExecuteMssql(query, parameters);
            List<Product> products = new List<Product>();

            if (results != null)
            {
                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Product p = ProductDataSetParser.DataSetToProduct(results, x);
                    products.Add(p);
                }
            }

            return products;
        }

        public Product GetProductById(int id)
        {
            string query = "SELECT * FROM producten WHERE id = @id";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("id", id.ToString()));
            DataSet results = ExecuteMssql(query, parameters);
            Product p = null;// = new Product();

            if (results != null && results.Tables[0].Rows.Count > 0)
            {
                p = ProductDataSetParser.DataSetToProduct(results, 0);
            }
            return p;
        }
    }
}