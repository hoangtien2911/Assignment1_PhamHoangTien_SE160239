using EmployeeManagementBO.Models;

namespace EmployeeManagementService;

/// <summary>
/// Interface for managing job history in the service layer.
/// </summary>
/// <author>TienPH</author>
public interface IJobHistoryService
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
    /// Retrieves all jobHistory include Job and depa from the database.
    /// </summary>
    /// <param name="employeeId">The employee id to get job histories.</param>
    /// <returns>An IEnumerable of all jobHistory.</returns>
    IEnumerable<JobHistory> GetAllJobHistoryIncludeJobAndDepartmentByEmployeeId(int employeeId);

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
