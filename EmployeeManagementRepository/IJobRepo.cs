using EmployeeManagementBO.Models;

namespace EmployeeManagementRepository;

/// <summary>
/// Interface for managing job in the repository.
/// </summary>
/// <author>TienPH</author>
public interface IJobRepo
{
    /// <summary>
    /// Creates a new job in the database.
    /// </summary>
    /// <param name="job">The job object to be created.</param>
    /// <returns>True if the job is successfully created, otherwise false.</returns>
    bool Create(Job job);

    /// <summary>
    /// Retrieves all job from the database.
    /// </summary>
    /// <returns>An IEnumerable of all job.</returns>
    IEnumerable<Job> GetAll();

    /// <summary>
    /// Retrieves all job with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all job.</returns>
    IQueryable<Job> GetAllInclude();

    /// <summary>
    /// Updates an existing job in the database.
    /// </summary>
    /// <param name="job">The job object to be updated.</param>
    /// <returns>True if the job is successfully updated, otherwise false.</returns>
    bool Update(Job job);

    /// <summary>
    /// Deletes a job from the database.
    /// </summary>
    /// <param name="job">The job object to be deleted.</param>
    /// <returns>True if the job is successfully deleted, otherwise false.</returns>
    bool Delete(Job job);
}
