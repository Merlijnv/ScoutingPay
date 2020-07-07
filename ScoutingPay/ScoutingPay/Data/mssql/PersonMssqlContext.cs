using System.Collections.Generic;
using System.Data;
using ScoutingPay.Data.datasetparsers;
using ScoutingPay.Interfaces;
using ScoutingPay.Models;

namespace ScoutingPay.Data.mssql
{
    public class PersonMssqlContext : BaseMssqlContext, IPersonRetrieveContext, IPersonSaveContext
    {
        public PersonMssqlContext(string connString) : base(connString)
        {
            
        }

        public List<Person> GetAllMembers()
        {
            string query = "SELECT * FROM leden";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            DataSet results = ExecuteMssql(query, parameters);
            List<Person> members = new List<Person>();

            if (results != null)
            {
                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Person m = PersonDataSetParser.DataSetToPerson(results, x);
                    members.Add(m);
                }
            }

            return members;
        }
        
        public List<Person> GetAllActiveMembers()
        {
            string query = "SELECT * FROM leden WHERE actief = 1";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            DataSet results = ExecuteMssql(query, parameters);
            List<Person> members = new List<Person>();

            if (results != null)
            {
                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Person m = PersonDataSetParser.DataSetToPerson(results, x);
                    members.Add(m);
                }
            }
            return members;
        }

        public void UpdateMemberByBonNr(Person p)
        {
            string query = "UPDATE leden SET naam = @name, email = @email, actief = @active WHERE id = @bonnr";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("bonnr",p.BonNr.ToString()));
            parameters.Add(new KeyValuePair<string, string>("name",p.Name));
            parameters.Add(new KeyValuePair<string, string>("email",p.Mail));
            parameters.Add(new KeyValuePair<string, string>("active",p.Active.ToString()));
            ExecuteMssql(query, parameters);
            
        }

    }
}