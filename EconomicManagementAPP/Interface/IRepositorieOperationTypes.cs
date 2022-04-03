using EconomicManagementAPP.Models;

namespace EconomicManagementAPP.Interface
{
    public interface IRepositorieOperationTypes
    {
        Task Create(OperationTypes operationTypes);
        Task<bool> Exist(string Description);
        Task<IEnumerable<OperationTypes>> GetOperation();
        Task Modify(OperationTypes operationTypes);
        Task<OperationTypes> GetOperationById(int id); 
        Task Delete(int id);
        Task<string> GetOperationTypeByCategoryId(int categoryId, int userId);
    }
}
