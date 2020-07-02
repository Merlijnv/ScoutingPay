using System;
using System.Data;
using ScoutingPay.Models;

namespace ScoutingPay.Data.datasetparsers
{
    public class PersonDataSetParser
    {
        public static Person DataSetToPerson(DataSet set, int rowIndex)
        {
            int bonNr = (int)set.Tables[0].Rows[rowIndex][0];
            string name = set.Tables[0].Rows[rowIndex][1].ToString();
            string mail = set.Tables[0].Rows[rowIndex][2].ToString();
            return new Person(bonNr, name, mail)
            {
                BonNr = bonNr,
                Name = name,
                Mail = mail
            };
        }
    }
}