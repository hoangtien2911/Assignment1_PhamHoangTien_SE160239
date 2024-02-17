using EmployeeManagementBO.Models;
using EmployeeManagementRepository;

namespace EmployeeManagementService;

/// <summary>
/// Service class for managing department.
/// </summary>
/// <author>TienPH</author>
public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepo departmentRepo;

    public DepartmentService()
    {
        departmentRepo = new DepartmentRepo();
    }

    /// <summary>
    /// Creates a new department in the database.
    /// </summary>
    /// <param name="department">The department object to be created.</param>
    /// <returns>True if the department is successfully created, otherwise false.</returns>    
    public bool Create(Department department)
    {
        return departmentRepo.Create(department);
    }

    /// <summary>
    /// Retrieves all department from the database.
    /// </summary>
    /// <returns>An IEnumerable of all department.</returns>    
    public IEnumerable<Department> GetAll()
    {
        return departmentRepo.GetAll();
    }


    /// <summary>
    /// Updates an existing department in the database.
    /// </summary>
    /// <param name="department">The department object to be updated.</param>
    /// <returns>True if the department is successfully updated, otherwise false.</returns>
    public bool Update(Department department)
    {
        return departmentRepo.Update(department);
    }

    /// <summary>
    /// Deletes a department from the database.
    /// </summary>
    /// <param name="department">The department object to be deleted.</param>
    /// <returns>True if the department is successfully deleted, otherwise false.</returns>
    public bool Delete(Department department)
    {
        return departmentRepo.Delete(department);
    }
}
