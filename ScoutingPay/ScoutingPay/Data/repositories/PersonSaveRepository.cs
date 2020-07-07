using System.Collections.Generic;
using ScoutingPay.Interfaces;
using ScoutingPay.Models;

namespace ScoutingPay.Data.repositories
{
    public class PersonSaveRepository
    {
        private readonly IPersonSaveContext _contextRet;

        public PersonSaveRepository(IPersonSaveContext contextRet)
        {
            _contextRet = contextRet;
        }
        
        public void UpdatePerson(Person p)
        {
            _contextRet.UpdateMemberByBonNr(p);
        }
    }
}