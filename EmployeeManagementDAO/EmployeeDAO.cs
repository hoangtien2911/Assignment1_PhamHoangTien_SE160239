using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace EmployeeManagementDAO;

/// <summary>
/// Employee DAO for managing Employee data in the database.
/// </summary>
/// <author>TienPH</author>
public class EmployeeDAO
{
    private readonly EmployeesManagementContext _empManagementDBContext;
    private readonly DbSet<Employee> _dbSet;
    private static EmployeeDAO instance;
    private static readonly object instanceLock = new object();

    /// <summary>
    /// Gets the singleton instance of the EmployeeDAO.
    /// </summary>
    public static EmployeeDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new EmployeeDAO();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the EmployeeDAO class.
    /// </summary>
    private EmployeeDAO()
    {
        _empManagementDBContext = new EmployeesManagementContext();
        _dbSet = _empManagementDBContext.Set<Employee>();
    }

    /// <summary>
    /// Creates a new employee in the database.
    /// </summary>
    /// <param name="employee">The employee object to be created.</param>
    /// <returns>True if the employee is successfully created, otherwise false.</returns>
    public bool Create(Employee employee)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            _dbSet.Add(employee);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Retrieves all employee from the database.
    /// </summary>
    /// <returns>An IQueryable of all employee.</returns>
    public IQueryable<Employee> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    /// <summary>
    /// Updates an existing employee in the database.
    /// </summary>
    /// <param name="employee">The employee object to be updated.</param>
    /// <returns>True if the employee is successfully updated, otherwise false.</returns>
    public bool Update(Employee employee)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            _empManagementDBContext.Entry(employee).State = EntityState.Modified;
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Deletes a employee from the database.
    /// </summary>
    /// <param name="employee">The employee object to be deleted.</param>
    /// <returns>True if the employee is successfully deleted, otherwise false.</returns>
    public bool Delete(Employee employee)
    {
        try
        {
            _dbSet.Remove(employee);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }
}
