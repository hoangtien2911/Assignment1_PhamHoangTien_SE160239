

using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementRepository;

/// <summary>
/// Interface for managing job history in the repository.
/// </summary>
/// <author>TienPH</author>
public interface IJobHistoryRepo
{
    /// <summary>
    /// Creates a new jobHistory in the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be created.</param>
    /// <returns>True if the jobHistory is successfully created, otherwise false.</returns>
    bool Create(JobHistory jobHistory);

    /// <summary>
    /// Retrieves all jobHistory from the database.
    /// </summary>
    /// <returns>An IEnumerable of all jobHistory.</returns>
    IEnumerable<JobHistory> GetAll();

    /// <summary>
    /// Retrieves all jobHistory with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all jobHistory.</returns>
    IQueryable<JobHistory> GetAllInclude();

    /// <summary>
    /// Updates an existing jobHistory in the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be updated.</param>
    /// <returns>True if the jobHistory is successfully updated, otherwise false.</returns>
    bool Update(JobHistory jobHistory);

    /// <summary>
    /// Deletes a jobHistory from the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be deleted.</param>
    /// <returns>True if the jobHistory is successfully deleted, otherwise false.</returns>
    bool Delete(JobHistory jobHistory);
}
