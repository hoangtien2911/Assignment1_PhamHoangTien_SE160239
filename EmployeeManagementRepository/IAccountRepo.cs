using EmployeeManagementBO.Models;

namespace EmployeeManagementRepository;

/// <summary>
/// Interface for managing account in the repository.
/// </summary>
/// <author>TienPH</author>
public interface IAccountRepo
{
    /// <summary>
    /// Creates a new account in the database.
    /// </summary>
    /// <param name="account">The account object to be created.</param>
    /// <returns>True if the account is successfully created, otherwise false.</returns>
    bool Create(Account account);

    /// <summary>
    /// Retrieves all accounts from the database.
    /// </summary>
    /// <returns>An IEnumerable of all accounts.</returns>
    IEnumerable<Account> GetAll();

    /// <summary>
    /// Retrieves all accounts with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all accounts.</returns>
    IQueryable<Account> GetAllInclude();

    /// <summary>
    /// Updates an existing account in the database.
    /// </summary>
    /// <param name="account">The account object to be updated.</param>
    /// <returns>True if the account is successfully updated, otherwise false.</returns>
    bool Update(Account account);

    /// <summary>
    /// Deletes a account from the database.
    /// </summary>
    /// <param name="account">The account object to be deleted.</param>
    /// <returns>True if the account is successfully deleted, otherwise false.</returns>
    bool Delete(Account account);
}
