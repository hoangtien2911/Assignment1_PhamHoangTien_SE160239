

using EmployeeManagementBO.Models;
using EmployeeManagementDAO;

namespace EmployeeManagementRepository;

/// <summary>
/// Repository class for managing department.
/// </summary>
/// <author>TienPH</author>
public class DepartmentRepo : IDepartmentRepo
{
    private readonly DepartmentDAO _dao = DepartmentDAO.Instance;

    /// <summary>
    /// Creates a new department in the database.
    /// </summary>
    /// <param name="department">The department object to be created.</param>
    /// <returns>True if the department is successfully created, otherwise false.</returns>
    public bool Create(Department department)
    {
        return _dao.Create(department);
    }

    /// <summary>
    /// Retrieves all department from the database.
    /// </summary>
    /// <returns>An IEnumerable of all department.</returns>
    public IEnumerable<Department> GetAll()
    {
        return _dao.GetAll().ToList();
    }

    /// <summary>
    /// Retrieves all department with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all department.</returns>
    public IQueryable<Department> GetAllInclude()
    {
        return _dao.GetAll().AsQueryable();
    }

    /// <summary>
    /// Updates an existing department in the database.
    /// </summary>
    /// <param name="department">The department object to be updated.</param>
    /// <returns>True if the department is successfully updated, otherwise false.</returns>
    public bool Update(Department department)
    {
        return _dao.Update(department);
    }

    /// <summary>
    /// Deletes a department from the database.
    /// </summary>
    /// <param name="department">The department object to be deleted.</param>
    /// <returns>True if the department is successfully deleted, otherwise false.</returns>
    public bool Delete(Department department)
    {
        return _dao.Delete(department);
    }
}
