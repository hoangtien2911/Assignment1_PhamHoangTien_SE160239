using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementDAO;

/// <summary>
/// JobHistory DAO for managing job history data in the database.
/// </summary>
/// <author>TienPH</author>
public class JobHistoryDAO
{

    private readonly EmployeesManagementContext _empManagementDBContext;
    private readonly DbSet<JobHistory> _dbSet;
    private static JobHistoryDAO instance;
    private static readonly object instanceLock = new object();

    /// <summary>
    /// Gets the singleton instance of the JobDAO.
    /// </summary>
    public static JobHistoryDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new JobHistoryDAO();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the JobHistoryDAO class.
    /// </summary>
    private JobHistoryDAO()
    {
        _empManagementDBContext = new EmployeesManagementContext();
        _dbSet = _empManagementDBContext.Set<JobHistory>();
    }

    /// <summary>
    /// Creates a new jobHistory in the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be created.</param>
    /// <returns>True if the jobHistory is successfully created, otherwise false.</returns>
    public bool Create(JobHistory jobHistory)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            _dbSet.Add(jobHistory);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Retrieves all jobHistory from the database.
    /// </summary>
    /// <returns>An IQueryable of all jobHistory.</returns>
    public IQueryable<JobHistory> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    /// <summary>
    /// Updates an existing jobHistory in the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be updated.</param>
    /// <returns>True if the jobHistory is successfully updated, otherwise false.</returns>
    public bool Update(JobHistory jobHistory)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            var tracker = _empManagementDBContext.Attach(jobHistory);
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
    /// Deletes a jobHistory from the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be deleted.</param>
    /// <returns>True if the jobHistory is successfully deleted, otherwise false.</returns>
    public bool Delete(JobHistory jobHistory)
    {
        try
        {
            _dbSet.Remove(jobHistory);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }
}
