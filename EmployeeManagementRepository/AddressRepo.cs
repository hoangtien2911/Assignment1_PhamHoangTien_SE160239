using EmployeeManagementBO.Models;
using EmployeeManagementDAO;

namespace EmployeeManagementRepository;

/// <summary>
/// Repository class for managing address.
/// </summary>
/// <author>TienPH</author>
public class AddressRepo : IAddressRepo
{
    private readonly AddressDAO _dao = AddressDAO.Instance;

    /// <summary>
    /// Creates a new address in the database.
    /// </summary>
    /// <param name="address">The address object to be created.</param>
    /// <returns>Address if the address is successfully created, otherwise null.</returns>
    public Address? Create(Address address)
    {
        return _dao.Create(address);
    }

    /// <summary>
    /// Retrieves all address from the database.
    /// </summary>
    /// <returns>An IEnumerable of all address.</returns>
    public IEnumerable<Address> GetAll()
    {
        return _dao.GetAll().ToList();
    }

    /// <summary>
    /// Retrieves all address with include from the database.
    /// </summary>
    /// <returns>An IQueryable of all address.</returns>
    public IQueryable<Address> GetAllInclude()
    {
        return _dao.GetAll().AsQueryable();
    }

    /// <summary>
    /// Updates an existing address in the database.
    /// </summary>
    /// <param name="address">The address object to be updated.</param>
    /// <returns>True if the address is successfully updated, otherwise false.</returns>
    public bool Update(Address address)
    {
        return _dao.Update(address);
    }

    /// <summary>
    /// Deletes a address from the database.
    /// </summary>
    /// <param name="address">The address object to be deleted.</param>
    /// <returns>True if the address is successfully deleted, otherwise false.</returns>
    public bool Delete(Address address)
    {
        return _dao.Delete(address);
    }
}
