using System;
using System.Data;
using ScoutingPay.Models;

namespace ScoutingPay.Data.datasetparsers
{
    public class PersonDataSetParser
    {
        public static Person DataSetToPerson(DataSet set, int rowIndex)
        {
            var bonNr = (int)set.Tables[0].Rows[rowIndex][0];
            var name = set.Tables[0].Rows[rowIndex][1].ToString();
            var mail = set.Tables[0].Rows[rowIndex][2].ToString();
            var active = (byte)set.Tables[0].Rows[rowIndex][3];
            return new Person(bonNr, name, mail, active)
            {
                BonNr = bonNr,
                Name = name,
                Mail = mail,
                Active = active
            };
        }
    }
}