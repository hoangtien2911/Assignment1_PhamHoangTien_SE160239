using EmployeeManagementBO.Models;

namespace EmployeeManagementService;

/// <summary>
/// Interface for managing address in the service layer.
/// </summary>
/// <author>TienPH</author>
public interface IAddressService
{
    /// <summary>
    /// Creates a new address in the database.
    /// </summary>
    /// <param name="address">The address object to be created.</param>
    /// <returns>Address if the address is successfully created, otherwise null.</returns>
    Address? Create(Address address);

    /// <summary>
    /// Retrieves all address from the database.
    /// </summary>
    /// <returns>An IEnumerable of all address.</returns>
    IEnumerable<Address> GetAll();

    /// <summary>
    /// Updates an existing address in the database.
    /// </summary>
    /// <param name="address">The address object to be updated.</param>
    /// <returns>True if the address is successfully updated, otherwise false.</returns>
    bool Update(Address address);

    /// <summary>
    /// Deletes a address from the database.
    /// </summary>
    /// <param name="address">The address object to be deleted.</param>
    /// <returns>True if the address is successfully deleted, otherwise false.</returns>
    bool Delete(Address address);
}
