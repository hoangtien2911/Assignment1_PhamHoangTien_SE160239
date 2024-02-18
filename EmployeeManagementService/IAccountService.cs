using EmployeeManagementBO.Models;

namespace EmployeeManagementService;

/// <summary>
/// Interface for managing account in the service layer.
/// </summary>
/// <author>TienPH</author>
public interface IAccountService
{
    /// <summary>
    /// Creates a new account in the database.
    /// </summary>
    /// <param name="account">The account object to be created.</param>
    /// <returns>True if the account is successfully created, otherwise false.</returns>
    bool Create(Account account);

    /// <summary>
    /// Retrieves all accounts with delete flag = 0 from the database.
    /// </summary>
    /// <returns>An IEnumerable of all accounts.</returns>
    IEnumerable<Account> GetAll();

    /// <summary>
    /// Retrieves all accounts include address with role not equal admin and delete flag = 0 from the database.
    /// </summary>
    /// <returns>An IEnumerable of all accounts.</returns>
    IEnumerable<Account> GetAllIncludeAddressWithRoleNotAdmin();

    /// <summary>
    /// Retrieves all accounts with not a employee and delete flag = 0 from the database.
    /// </summary>
    /// <returns>An IEnumerable of all accounts.</returns>
    IEnumerable<Account> FindAccountsWithNullEmployee();

    /// <summary>
    /// Find account by username and password and delete flag = 0
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <param name="password">The password of the account.</param>
    /// <returns>An account</returns>
    Account? FindAccountByUsernameAndPassword(string username, string password);

    /// <summary>
    /// Find account by username and delete flag = 0
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <returns>An account if exist, ortherwise null</returns>
    Account? FindAccountByUsername(string username);

    /// <summary>
    /// Find account by username include employee and delete flag = 0
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <returns>An account</returns>
    Account? FindAccountIncludeEmployeeByUsername(string username);

    /// <summary>
    /// Find all account by name include address
    /// </summary>
    /// <param name="name">The name to search for in account records.</param>
    /// <returns>An IEnumerable of all accounts.</returns>
    IEnumerable<Account> FindAccountIncludeAddressByFullname(string name);

    /// <summary>
    /// Find all account by email include address
    /// </summary>
    /// <param name="email">The email to search for in account records.</param>
    /// <returns>An IEnumerable of all accounts.</returns>
    IEnumerable<Account> FindAccountIncludeAddressByEmail(string email);

    /// <summary>
    /// Updates an existing account in the database.
    /// </summary>
    /// <param name="account">The account object to be updated.</param>
    /// <returns>True if the account is successfully updated, otherwise false.</returns>
    bool Update(Account account);
}
