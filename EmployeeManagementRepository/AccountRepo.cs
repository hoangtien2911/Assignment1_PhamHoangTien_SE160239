using EmployeeManagementBO.Models;
using EmployeeManagementDAO;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementRepository;

/// <summary>
/// Repository class for managing accounts.
/// </summary>
/// <author>TienPH</author>
public class AccountRepo : IAccountRepo
{
    private readonly AccountDAO _dao = AccountDAO.Instance;

    /// <summary>
    /// Creates a new account in the database.
    /// </summary>
    /// <param name="account">The account object to be created.</param>
    /// <returns>True if the account is successfully created, otherwise false.</returns>
    public bool Create(Account account)
    {
        return _dao.Create(account);
    }

    /// <summary>
    /// Retrieves all accounts the database.
    /// </summary>
    /// <returns>An IEnumerable of all accounts.</returns>
    public IEnumerable<Account> GetAll()
    {
        return _dao.GetAll().ToList();
    }

    /// <summary>
    /// Retrieves all accounts with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all accounts.</returns>
    public IQueryable<Account> GetAllInclude()
    {
        return _dao.GetAll().AsQueryable();
    }

    /// <summary>
    /// Updates an existing account in the database.
    /// </summary>
    /// <param name="account">The account object to be updated.</param>
    /// <returns>True if the account is successfully updated, otherwise false.</returns>
    public bool Update(Account account)
    {
        return _dao.Update(account);
    }

    /// <summary>
    /// Deletes a account from the database.
    /// </summary>
    /// <param name="account">The account object to be deleted.</param>
    /// <returns>True if the account is successfully deleted, otherwise false.</returns>
    public bool Delete(Account account)
    {
        return _dao.Delete(account);
    }
}
