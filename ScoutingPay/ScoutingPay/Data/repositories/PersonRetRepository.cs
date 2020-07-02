using System.Collections.Generic;
using ScoutingPay.Interfaces;
using ScoutingPay.Models;

namespace ScoutingPay.Data.repositories
{
    public class PersonRetRepository
    {
        private readonly IPersonRetrieveContext _contextRet;

        public PersonRetRepository(IPersonRetrieveContext contextRet)
        {
            _contextRet = contextRet;
        }
        
        public List<Person> GetAll()
        {
            return _contextRet.GetAllMembers();
        }

        public List<Person> GetAllActive()
        {
            return _contextRet.GetAllActiveMembers();
        }
        
    }
}