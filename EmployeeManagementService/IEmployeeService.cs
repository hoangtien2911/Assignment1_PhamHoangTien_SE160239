using EmployeeManagementBO.Models;

namespace EmployeeManagementService;

/// <summary>
/// Interface for managing employee in the service layer.
/// </summary>
/// <author>TienPH</author>
public interface IEmployeeService
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
    /// Retrieves all employee include account address department job and history from the database.
    /// </summary>
    /// <returns>An IEnumerable of all employee.</returns>
    IEnumerable<Employee> GetAllIncludeAccountAddressDepartmentJobAndHistory();

    /// <summary>
    /// Retrieves all employee by email include account department job from the database.
    /// </summary>
    /// <param name="email">The email to search for in employee records.</param>
    /// <returns>An IEnumerable of all employee.</returns>
    IEnumerable<Employee> GetAllByEmailIncludeAccountDepartmentJob(string email);

    /// <summary>
    /// Retrieves all employee by name include account department job from the database.
    /// </summary>
    /// <param name="name">The name to search for in account records.</param>
    /// <returns>An IEnumerable of all employee.</returns>
    IEnumerable<Employee> GetAllByNameIncludeAccountDepartmentJob(string name);

    /// <summary>
    /// Get employee by username from the database.
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <returns>An employee, otherwise null</returns>       
    Employee? GetEmployeeByUserName(string username);

    /// <summary>
    /// Get employee by username include job and department information from the database.
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <returns>An employee.</returns>
    Employee? GetEmployeeByUserNameIncludeJobAndDepartment(string username);

    /// <summary>
    /// Get employee by username include account job and department information from the database.
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <returns>An employee.</returns>
    Employee GetEmployeeByUserNameIncludeAccountJobAndDepartment(string username);

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
