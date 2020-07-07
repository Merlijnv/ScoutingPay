using ScoutingPay.Models;

namespace ScoutingPay.Interfaces
{
    public interface IPersonSaveContext
    {
        public void UpdateMemberByBonNr(Person p);
    }
}