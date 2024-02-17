
using EmployeeManagementBO.Models;
using EmployeeManagementDAO;

namespace EmployeeManagementRepository;


/// <summary>
/// Repository class for managing job.
/// </summary>
/// <author>TienPH</author>
public class JobRepo : IJobRepo
{
    private readonly JobDAO _dao = JobDAO.Instance;

    /// <summary>
    /// Creates a new job in the database.
    /// </summary>
    /// <param name="job">The job object to be created.</param>
    /// <returns>True if the job is successfully created, otherwise false.</returns>
    public bool Create(Job job)
    {
        return _dao.Create(job);
    }

    /// <summary>
    /// Retrieves all job from the database.
    /// </summary>
    /// <returns>An IEnumerable of all job.</returns>
    public IEnumerable<Job> GetAll()
    {
        return _dao.GetAll().ToList();
    }

    /// <summary>
    /// Retrieves all job with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all job.</returns>
    public IQueryable<Job> GetAllInclude()
    {
        return _dao.GetAll().AsQueryable();
    }

    /// <summary>
    /// Updates an existing job in the database.
    /// </summary>
    /// <param name="job">The job object to be updated.</param>
    /// <returns>True if the job is successfully updated, otherwise false.</returns>
    public bool Update(Job job)
    {
        return _dao.Update(job);
    }

    /// <summary>
    /// Deletes a job from the database.
    /// </summary>
    /// <param name="job">The job object to be deleted.</param>
    /// <returns>True if the job is successfully deleted, otherwise false.</returns>
    public bool Delete(Job job)
    {
        return _dao.Delete(job);
    }
}
