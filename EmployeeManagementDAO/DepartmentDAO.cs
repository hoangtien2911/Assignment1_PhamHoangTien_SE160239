using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Department DAO for managing Department data in the database.
/// </summary>
/// <author>TienPH</author>
namespace EmployeeManagementDAO;

public class DepartmentDAO
{
    private readonly EmployeesManagementContext _empManagementDBContext;
    private readonly DbSet<Department> _dbSet;
    private static DepartmentDAO instance;
    private static readonly object instanceLock = new object();

    /// <summary>
    /// Gets the singleton instance of the DepartmentDAO.
    /// </summary>
    public static DepartmentDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new DepartmentDAO();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the DepartmentDAO class.
    /// </summary>
    private DepartmentDAO()
    {
        _empManagementDBContext = new EmployeesManagementContext();
        _dbSet = _empManagementDBContext.Set<Department>();
    }

    /// <summary>
    /// Creates a new department in the database.
    /// </summary>
    /// <param name="department">The department object to be created.</param>
    /// <returns>True if the department is successfully created, otherwise false.</returns>
    public bool Create(Department department)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            _dbSet.Add(department);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Retrieves all department from the database.
    /// </summary>
    /// <returns>An IQueryable of all department.</returns>
    public IQueryable<Department> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    /// <summary>
    /// Updates an existing department in the database.
    /// </summary>
    /// <param name="department">The department object to be updated.</param>
    /// <returns>True if the department is successfully updated, otherwise false.</returns>
    public bool Update(Department department)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            var tracker = _empManagementDBContext.Attach(department);
            tracker.State = EntityState.Modified;
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Deletes a department from the database.
    /// </summary>
    /// <param name="department">The department object to be deleted.</param>
    /// <returns>True if the department is successfully deleted, otherwise false.</returns>
    public bool Delete(Department department)
    {
        try
        {
            _dbSet.Remove(department);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }
}
