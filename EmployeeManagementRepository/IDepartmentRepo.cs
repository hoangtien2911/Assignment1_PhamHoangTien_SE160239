using EmployeeManagementBO.Models;

namespace EmployeeManagementRepository;

/// <summary>
/// Interface for managing department in the repository.
/// </summary>
/// <author>TienPH</author>
public interface IDepartmentRepo
{
    /// <summary>
    /// Creates a new department in the database.
    /// </summary>
    /// <param name="department">The department object to be created.</param>
    /// <returns>True if the department is successfully created, otherwise false.</returns>
    bool Create(Department department);

    /// <summary>
    /// Retrieves all department from the database.
    /// </summary>
    /// <returns>An IQueryable of all department.</returns>
    IEnumerable<Department> GetAll();

    /// <summary>
    /// Retrieves all department with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all department.</returns>
    IQueryable<Department> GetAllInclude();

    /// <summary>
    /// Updates an existing department in the database.
    /// </summary>
    /// <param name="department">The department object to be updated.</param>
    /// <returns>True if the department is successfully updated, otherwise false.</returns>
    bool Update(Department department);

    /// <summary>
    /// Deletes a department from the database.
    /// </summary>
    /// <param name="department">The department object to be deleted.</param>
    /// <returns>True if the department is successfully deleted, otherwise false.</returns>
    bool Delete(Department department);
}
