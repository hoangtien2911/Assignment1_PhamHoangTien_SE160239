using EmployeeManagementBO.Models;

namespace EmployeeManagementRepository;

/// <summary>
/// Interface for managing employee in the repository.
/// </summary>
/// <author>TienPH</author>
public interface IEmployeeRepo
{
    /// <summary>
    /// Creates a new employee in the database.
    /// </summary>
    /// <param name="employee">The employee object to be created.</param>
    /// <returns>True if the employee is successfully created, otherwise false.</returns>
    bool Create(Employee employee);

    /// <summary>
    /// Retrieves all employee from the database.
    /// </summary>
    /// <returns>An IEnumerable of all employee.</returns>
    IEnumerable<Employee> GetAll();

    /// <summary>
    /// Retrieves all employee with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all employee.</returns>
    IQueryable<Employee> GetAllInclude();

    /// <summary>
    /// Updates an existing employee in the database.
    /// </summary>
    /// <param name="employee">The employee object to be updated.</param>
    /// <returns>True if the employee is successfully updated, otherwise false.</returns>
    bool Update(Employee employee);

    /// <summary>
    /// Deletes a employee from the database.
    /// </summary>
    /// <param name="employee">The employee object to be deleted.</param>
    /// <returns>True if the employee is successfully deleted, otherwise false.</returns>
    bool Delete(Employee employee);
}
