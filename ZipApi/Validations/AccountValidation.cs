using EFRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZipApi.Validations
{
    public static class AccountValidation
    {
        public static bool CanUserCreateAccount(User user)
        {
            return (user.MonthlySalary - user.MonthlyExpenses) >= 1000;
        }
    }
}
