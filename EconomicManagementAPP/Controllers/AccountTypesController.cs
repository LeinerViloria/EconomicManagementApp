using EconomicManagementAPP.Models;
using Microsoft.AspNetCore.Mvc;
using EconomicManagementAPP.Interface;

namespace EconomicManagementAPP.Controllers
{
    public class AccountTypesController : Controller
    {
        private readonly IRepositorieAccountTypes repositorieAccountTypes;
        private readonly IRepositorieUsers repositorieUsers;

        public AccountTypesController(IRepositorieAccountTypes repositorieAccountTypes, IRepositorieUsers repositorieUsers)
        {
            this.repositorieAccountTypes = repositorieAccountTypes;
            this.repositorieUsers = repositorieUsers;
        }

        public async Task<IActionResult> Index()
        {
            if (UsersController.valorSesion is null)
            {
                return RedirectToAction("Login", "Users");
            }
            var userId = UsersController.valorSesion.Id;

            var accountTypes = await repositorieAccountTypes.GetAccountsTypes(userId);
            return View(accountTypes);
        }
        public async Task<IActionResult> Create()
        {
            if (UsersController.valorSesion is null)
            {
                return RedirectToAction("Login", "Users");
            }

            var accountTypesInDb = await repositorieAccountTypes.GetAccountsTypes(UsersController.valorSesion.Id);

            AccountTypes accountTypes = new()
            {
                ExistsAccountsTypesAlready = accountTypesInDb.Any()
            };
            
            return View(accountTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountTypes accountTypes)
        {
            if (!ModelState.IsValid)
            {
                return View(accountTypes);
            }

            accountTypes.UserId = UsersController.valorSesion.Id; ;
            accountTypes.OrderAccount = 1;

            var accountTypeExist = await repositorieAccountTypes.Exist(accountTypes.Name, accountTypes.UserId);

            if (accountTypeExist)
            {
                ModelState.AddModelError(nameof(accountTypes.Name),
                    $"The account {accountTypes.Name} already exist.");

                return View(accountTypes);
            }
            accountTypes.DbStatus = true;
            int newId = await repositorieAccountTypes.Create(accountTypes);
            return RedirectToAction("Create", "Accounts", new { id=newId });
        }

        [HttpGet]
        public async Task<IActionResult> VerificaryAccountType(string Name)
        {
            var userId = UsersController.valorSesion.Id;
            var accountTypeExist = await repositorieAccountTypes.Exist(Name, userId);

            if (accountTypeExist)
            {
                return Json($"The account {Name} already exist");
            }

            return Json(true);
        }

        [HttpGet]
        public async Task<ActionResult> Modify(int id)
        {
            if (UsersController.valorSesion is null)
            {
                return RedirectToAction("Login", "Users");
            }
            var userId = UsersController.valorSesion.Id;
            var accountType = await repositorieAccountTypes.GetAccountById(id, userId);

            if (accountType is null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View(accountType);
        }
        [HttpPost]
        public async Task<ActionResult> Modify(AccountTypes accountTypes)
        {
            var userId = UsersController.valorSesion.Id;
            var accountType = await repositorieAccountTypes.GetAccountById(accountTypes.Id, userId);

            if (accountType is null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            await repositorieAccountTypes.Modify(accountTypes);
            return RedirectToAction("Index","Home");
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (UsersController.valorSesion is null)
            {
                return RedirectToAction("Login", "Users");
            }
            var userId = UsersController.valorSesion.Id;
            var account = await repositorieAccountTypes.GetAccountById(id, userId);

            if (account is null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            account.NumberAccount = await repositorieAccountTypes.GetNumberAccount(id);
           
            return View(account);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var userId = UsersController.valorSesion.Id;
            var account = await repositorieAccountTypes.GetAccountById(id, userId);

            if (account is null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            var account_Type = await repositorieAccountTypes.ExistingAccountType(id);

            if (account_Type == false)
            {
                await repositorieAccountTypes.Delete(id);
                return RedirectToAction("Index", "Home");
            }

            await repositorieAccountTypes.DeleteModify(id);
            return RedirectToAction("Index","Home");
        }
    }
}
