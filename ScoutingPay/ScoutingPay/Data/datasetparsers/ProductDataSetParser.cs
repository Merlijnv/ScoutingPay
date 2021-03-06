﻿using System;
using ScoutingPay.Models;
using System.Data;


namespace ScoutingPay.Data.datasetparsers
{
    public class ProductDataSetParser
    {
        public static Product DataSetToProduct(DataSet set, int rowIndex)
        {
            var id = (int)set.Tables[0].Rows[rowIndex][0];
            var productName = set.Tables[0].Rows[rowIndex][1].ToString();
            var price = Convert.ToDecimal(set.Tables[0].Rows[rowIndex][2]);
            return new Product(id, productName, price)
            {
                Id = id,
                ProductName = productName,
                Price = price
            };
        }
        
    }
}