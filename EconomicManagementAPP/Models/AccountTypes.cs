using EconomicManagementAPP.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EconomicManagementAPP.Models
{
    public class AccountTypes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [FirstCapitalLetter]
        [Remote(action: "VerificaryAccountType", controller: "AccountTypes")]
        public string Name { get; set; }
        public int UserId { get; set; }
        public int OrderAccount { get; set; }
        public int NumberAccount { get; set; }
        public Boolean DbStatus { set; get; }
        public Boolean ExistsAccountsTypesAlready { get; set; }
    }
}
