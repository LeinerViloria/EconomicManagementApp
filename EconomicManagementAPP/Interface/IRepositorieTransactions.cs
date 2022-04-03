using EconomicManagementAPP.Models;

namespace EconomicManagementAPP.Interface
{
    public interface IRepositorieTransactions
    {
        Task Create(Transactions transactions);
        Task<IEnumerable<Transactions>> GetTransactionsByAccount(int AccountId, int UserId);
        Task<IEnumerable<Transactions>> GetTransactions(int UserId);
    }
}