using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementDAO;

/// <summary>
/// Job DAO for managing Job data in the database.
/// </summary>
/// <author>TienPH</author>
public class JobDAO
{
    private readonly EmployeesManagementContext _empManagementDBContext;
    private readonly DbSet<Job> _dbSet;
    private static JobDAO instance;
    private static readonly object instanceLock = new object();

    /// <summary>
    /// Gets the singleton instance of the JobDAO.
    /// </summary>
    public static JobDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new JobDAO();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the JobDAO class.
    /// </summary>
    private JobDAO()
    {
        _empManagementDBContext = new EmployeesManagementContext();
        _dbSet = _empManagementDBContext.Set<Job>();
    }

    /// <summary>
    /// Creates a new job in the database.
    /// </summary>
    /// <param name="job">The job object to be created.</param>
    /// <returns>True if the job is successfully created, otherwise false.</returns>
    public bool Create(Job job)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            _dbSet.Add(job);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Retrieves all job from the database.
    /// </summary>
    /// <returns>An IQueryable of all job.</returns>
    public IQueryable<Job> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    /// <summary>
    /// Updates an existing job in the database.
    /// </summary>
    /// <param name="job">The job object to be updated.</param>
    /// <returns>True if the job is successfully updated, otherwise false.</returns>
    public bool Update(Job job)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            var tracker = _empManagementDBContext.Attach(job);
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
    /// Deletes a job from the database.
    /// </summary>
    /// <param name="job">The job object to be deleted.</param>
    /// <returns>True if the job is successfully deleted, otherwise false.</returns>
    public bool Delete(Job job)
    {
        try
        {
            _dbSet.Remove(job);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }
}
