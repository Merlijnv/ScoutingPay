using System.Collections.Generic;
using ScoutingPay.Models;

namespace ScoutingPay.Interfaces
{
    public interface IPersonRetrieveContext
    {
        public List<Person> GetAllMembers();
        public List<Person> GetAllActiveMembers();
    }
}