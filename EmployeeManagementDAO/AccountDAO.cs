using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementDAO;

/// <summary>
/// Account DAO for managing account data in the database.
/// </summary>
/// <author>TienPH</author>
public class AccountDAO
{
    private readonly EmployeesManagementContext _empManagementDBContext;
    private readonly DbSet<Account> _dbSet;
    private static AccountDAO instance;
    private static readonly object instanceLock = new object();

    /// <summary>
    /// Gets the singleton instance of the AccountDAO.
    /// </summary>
    public static AccountDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the AccountDAO class.
    /// </summary>
    private AccountDAO()
    {
        _empManagementDBContext = new EmployeesManagementContext();
        _dbSet = _empManagementDBContext.Set<Account>();
    }

    /// <summary>
    /// Creates a new account in the database.
    /// </summary>
    /// <param name="account">The account object to be created.</param>
    /// <returns>True if the account is successfully created, otherwise false.</returns>
    public bool Create(Account account)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            _dbSet.Add(account);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Retrieves all accounts from the database.
    /// </summary>
    /// <returns>An IQueryable of all accounts.</returns>
    public IQueryable<Account> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    /// <summary>
    /// Updates an existing account in the database.
    /// </summary>
    /// <param name="account">The account object to be updated.</param>
    /// <returns>True if the account is successfully updated, otherwise false.</returns>
    public bool Update(Account account)
    {
        try
        {           
            _empManagementDBContext.ChangeTracker.Clear();
            _empManagementDBContext.Entry(account).State = EntityState.Modified;
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Deletes a account from the database.
    /// </summary>
    /// <param name="account">The account object to be deleted.</param>
    /// <returns>True if the account is successfully deleted, otherwise false.</returns>
    public bool Delete(Account account)
    {
        try
        {
            account.DeleteFlag = 1;
            _empManagementDBContext.ChangeTracker.Clear();
            var tracker = _empManagementDBContext.Attach(account);
            tracker.State = EntityState.Modified;
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }
}
