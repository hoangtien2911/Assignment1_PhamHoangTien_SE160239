

using EmployeeManagementBO.Models;
using EmployeeManagementDAO;

namespace EmployeeManagementRepository;

/// <summary>
/// Repository class for managing employee.
/// </summary>
/// <author>TienPH</author>
public class EmployeeRepo : IEmployeeRepo
{
    private readonly EmployeeDAO _dao = EmployeeDAO.Instance;

    /// <summary>
    /// Creates a new employee in the database.
    /// </summary>
    /// <param name="employee">The employee object to be created.</param>
    /// <returns>True if the employee is successfully created, otherwise false.</returns>
    public bool Create(Employee employee)
    {
        return _dao.Create(employee);
    }

    /// <summary>
    /// Retrieves all employee from the database.
    /// </summary>
    /// <returns>An IEnumerable of all employee.</returns>
    public IEnumerable<Employee> GetAll()
    {
        return _dao.GetAll().ToList();
    }

    /// <summary>
    /// Retrieves all employee with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all employee.</returns>
    public IQueryable<Employee> GetAllInclude()
    {
        return _dao.GetAll().AsQueryable();
    }

    /// <summary>
    /// Updates an existing employee in the database.
    /// </summary>
    /// <param name="employee">The employee object to be updated.</param>
    /// <returns>True if the employee is successfully updated, otherwise false.</returns>
    public bool Update(Employee employee)
    {
        return _dao.Update(employee);
    }

    /// <summary>
    /// Deletes a employee from the database.
    /// </summary>
    /// <param name="employee">The employee object to be deleted.</param>
    /// <returns>True if the employee is successfully deleted, otherwise false.</returns>
    public bool Delete(Employee employee)
    {
        return _dao.Delete(employee);
    }
}
