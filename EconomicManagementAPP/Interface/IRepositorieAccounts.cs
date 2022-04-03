using EconomicManagementAPP.Models;

namespace EconomicManagementAPP.Interface
{
    public interface IRepositorieAccounts
    {
        Task Create(Accounts accounts);
        Task<bool> ExistingAccount(string Name, int AccountTypeId);
        Task<IEnumerable<Accounts>> GetAccounts(int userId);
        Task Modify(Accounts accounts);
        Task<Accounts> GetAccountById(int id);
        Task Delete(int id);
        Task DeleteModify(int id);
        Task<int> GetNumberTransaction(int id);
        Task<bool> ExistingAccountTransaction(int Id);




    }
}
