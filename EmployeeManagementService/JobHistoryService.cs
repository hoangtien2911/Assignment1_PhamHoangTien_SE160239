using EmployeeManagementBO.Models;
using EmployeeManagementRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementService;

/// <summary>
/// Service class for managing job history.
/// </summary>
/// <author>TienPH</author>
public class JobHistoryService : IJobHistoryService
{
    private readonly IJobHistoryRepo jobHistoryRepo;

    public JobHistoryService()
    {
        jobHistoryRepo = new JobHistoryRepo();
    }

    /// <summary>
    /// Creates a new jobHistory in the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be created.</param>
    /// <returns>True if the jobHistory is successfully created, otherwise false.</returns>    
    public bool Create(JobHistory jobHistory)
    {
        return jobHistoryRepo.Create(jobHistory);
    }

    /// <summary>
    /// Retrieves all jobHistory from the database.
    /// </summary>
    /// <returns>An IEnumerable of all jobHistory.</returns>    
    public IEnumerable<JobHistory> GetAll()
    {
        return jobHistoryRepo.GetAll();
    }

    /// <summary>
    /// Retrieves all jobHistory include Job and depa from the database.
    /// </summary>
    /// <param name="employeeId">The employee id to get job histories.</param>
    /// <returns>An IEnumerable of all jobHistory.</returns>
    public IEnumerable<JobHistory> GetAllJobHistoryIncludeJobAndDepartmentByEmployeeId(int employeeId)
    {
        return jobHistoryRepo.GetAllInclude().Include(jh => jh.Job).Include(jh => jh.Department).Where(jh => jh.EmployeeId.Equals(employeeId)).ToList();
    }

    /// <summary>
    /// Updates an existing jobHistory in the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be updated.</param>
    /// <returns>True if the jobHistory is successfully updated, otherwise false.</returns>   
    public bool Update(JobHistory jobHistory)
    {
        return jobHistoryRepo.Update(jobHistory);
    }

    /// <summary>
    /// Deletes a jobHistory from the database.
    /// </summary>
    /// <param name="jobHistory">The jobHistory object to be deleted.</param>
    /// <returns>True if the jobHistory is successfully deleted, otherwise false.</returns>
    public bool Delete(JobHistory jobHistory)
    {
        return jobHistoryRepo.Delete(jobHistory);
    }
}
