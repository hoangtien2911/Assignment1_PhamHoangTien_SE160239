

using EmployeeManagementBO.Models;
using EmployeeManagementDAO;

namespace EmployeeManagementRepository;

/// <summary>
/// Repository class for managing job history.
/// </summary>
/// <author>TienPH</author>
public class JobHistoryRepo : IJobHistoryRepo
{

    private readonly JobHistoryDAO _dao = JobHistoryDAO.Instance;

    /// <summary>
    /// Creates a new jobHistory in the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be created.</param>
    /// <returns>True if the jobHistory is successfully created, otherwise false.</returns>
    public bool Create(JobHistory jobHistory)
    {
        return _dao.Create(jobHistory);
    }

    /// <summary>
    /// Retrieves all jobHistory from the database.
    /// </summary>
    /// <returns>An IEnumerable of all jobHistory.</returns>
    public IEnumerable<JobHistory> GetAll()
    {
        return _dao.GetAll().ToList();
    }

    /// <summary>
    /// Retrieves all jobHistory from the database.
    /// </summary>
    /// <returns>An IQueryable of all jobHistory.</returns>
    public IQueryable<JobHistory> GetAllInclude()
    {
        return _dao.GetAll().AsQueryable();
    }

    /// <summary>
    /// Updates an existing jobHistory in the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be updated.</param>
    /// <returns>True if the jobHistory is successfully updated, otherwise false.</returns>
    public bool Update(JobHistory jobHistory)
    {
        return _dao.Update(jobHistory);
    }

    /// <summary>
    /// Deletes a jobHistory from the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be deleted.</param>
    /// <returns>True if the jobHistory is successfully deleted, otherwise false.</returns>
    public bool Delete(JobHistory jobHistory)
    {
        return _dao.Delete(jobHistory);
    }

}
