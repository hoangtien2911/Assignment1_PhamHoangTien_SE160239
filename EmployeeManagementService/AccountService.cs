using EmployeeManagementBO.Models;
using EmployeeManagementRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementService;

/// <summary>
/// Service class for managing account.
/// </summary>
/// <author>TienPH</author>
public class AccountService : IAccountService
{
    private readonly IAccountRepo accountRepo;

    public AccountService()
    {
        accountRepo = new AccountRepo();
    }

    /// <summary>
    /// Creates a new account.
    /// </summary>
    /// <param name="account">The account object to be created.</param>
    /// <returns>True if the account creation is successful, otherwise false.</returns>
    public bool Create(Account account)
    {
        return accountRepo.Create(account);
    }

    /// <summary>
    /// Retrieves all accounts with delete flag = 0 from the database.
    /// </summary>
    /// <returns>An IEnumerable of all accounts.</returns>
    public IEnumerable<Account> GetAll()
    {
        return accountRepo.GetAll().Where(a => a.DeleteFlag.Equals(0));
    }

    /// <summary>
    /// Retrieves all accounts include address with role not equal admin and delete flag = 0 from the database.
    /// </summary>
    /// <returns>An IEnumerable of all accounts.</returns>
    public IEnumerable<Account> GetAllIncludeAddressWithRoleNotAdmin()
    {
        return accountRepo.GetAllInclude().Include(a => a.Address).Where(a => a.DeleteFlag.Equals(0) && !a.Role.Equals("Admin")).ToList();
    }

    /// <summary>
    /// Updates an existing account in the database.
    /// </summary>
    /// <param name="account">The account object to be updated.</param>
    /// <returns>True if the account is successfully updated, otherwise false.</returns>
    public bool Update(Account account)
    {
        return accountRepo.Update(account);
    }

    /// <summary>
    /// Retrieves all accounts with not a employee and delete flag = 0 from the database.
    /// </summary>
    /// <returns>An IEnumerable of all accounts.</returns>
    public IEnumerable<Account> FindAccountsWithNullEmployee()
    {
        return accountRepo.GetAllInclude().Include(a => a.Employee).Where(a => a.Employee == null && a.Role.Equals("User") && a.DeleteFlag == 0);
    }

    /// <summary>
    /// Find account by username and password and delete flag = 0
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <param name="password">The password of the account.</param>
    /// <returns>An account</returns>
    public Account? FindAccountByUsernameAndPassword(string username, string password)
    {       
        return accountRepo.GetAllInclude().Include(a => a.Address).FirstOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password) && a.DeleteFlag.Equals(0));
    }

    /// <summary>
    /// Find account by username and delete flag = 0
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <returns>An account if exist, ortherwise null</returns>
    public Account? FindAccountByUsername(string username)
    {
        return accountRepo.GetAllInclude().Include(a => a.Address).FirstOrDefault(a => a.Username.Equals(username) && a.DeleteFlag.Equals(0));
    }

    /// <summary>
    /// Find account by username include employee and delete flag = 0
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <returns>An account</returns>
    public Account FindAccountIncludeEmployeeByUsername(string username)
    {
        return accountRepo.GetAllInclude().Include(a => a.Employee).First(a => a.Username.Equals(username) && a.DeleteFlag.Equals(0));
    }

    /// <summary>
    /// Find all account by name include address
    /// </summary>
    /// <param name="name">The name to search for in account records.</param>
    /// <returns>An IEnumerable of all accounts.</returns>
    public IEnumerable<Account> FindAccountIncludeAddressByFullname(string name)
    {
        return accountRepo.GetAllInclude().Include(a => a.Address).Where(a => a.FullName.Contains(name) && a.DeleteFlag.Equals(0) && !a.Role.Equals("Admin")).ToList();
    }

    /// <summary>
    /// Find all account by email include address
    /// </summary>
    /// <param name="email">The email to search for in account records.</param>
    /// <returns>An IEnumerable of all accounts.</returns>
    public IEnumerable<Account> FindAccountIncludeAddressByEmail(string email)
    {
        return accountRepo.GetAllInclude().Include(a => a.Address).Where(a => a.Email.Contains(email) && a.DeleteFlag.Equals(0) && !a.Role.Equals("Admin")).ToList();
    }
}
