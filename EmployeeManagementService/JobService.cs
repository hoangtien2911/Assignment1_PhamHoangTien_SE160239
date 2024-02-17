using EmployeeManagementBO.Models;
using EmployeeManagementRepository;

namespace EmployeeManagementService;

/// <summary>
/// Service class for managing job.
/// </summary>
/// <author>TienPH</author>
public class JobService : IJobService
{
    private readonly IJobRepo jobRepo;

    public JobService()
    {
        jobRepo = new JobRepo();
    }

    /// <summary>
    /// Creates a new job in the database.
    /// </summary>
    /// <param name="job">The job object to be created.</param>
    /// <returns>True if the job is successfully created, otherwise false.</returns>
    public bool Create(Job job)
    {
        return jobRepo.Create(job);
    }

    /// <summary>
    /// Retrieves all job from the database.
    /// </summary>
    /// <returns>An IEnumerable of all job.</returns>   
    public IEnumerable<Job> GetAll()
    {
        return jobRepo.GetAll();
    }

    /// <summary>
    /// Updates an existing job in the database.
    /// </summary>
    /// <param name="job">The job object to be updated.</param>
    /// <returns>True if the job is successfully updated, otherwise false.</returns>
    public bool Update(Job job)
    {
        return jobRepo.Update(job);
    }

    /// <summary>
    /// Deletes a job from the database.
    /// </summary>
    /// <param name="job">The job object to be deleted.</param>
    /// <returns>True if the job is successfully deleted, otherwise false.</returns>
    public bool Delete(Job job)
    {
        return jobRepo.Delete(job);
    }
}
