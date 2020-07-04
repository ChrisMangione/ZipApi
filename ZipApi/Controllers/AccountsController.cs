using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFRepository;
using EFRepository.Model;
using ZipApi.DataTransferObjects;
using ZipApi.Validations;
using Microsoft.Extensions.Logging;

namespace ZipApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly EFContext _context;

        public AccountsController(EFContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(long id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(AccountDTO accountDto)
        {
            var result = await new UsersController(_context).GetUser(accountDto.UserId);
            if (result.Value == null)
                return NotFound();
            if (!AccountValidation.CanUserCreateAccount(result.Value))
                return ValidationProblem("User's gross monthly income is below the required amount ($1000)");

            var account = new Account
            {
                AccountId = accountDto.AccountId,
                AccountLimit = accountDto.AccountLimit,
                UserId = accountDto.UserId,
                CreationDate = DateTime.Now
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        }

        // DELETE: api/Accounts/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(long id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return account;
        }
    }
}
