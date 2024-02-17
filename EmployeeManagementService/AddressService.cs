using EmployeeManagementBO.Models;
using EmployeeManagementRepository;

namespace EmployeeManagementService;

/// <summary>
/// Service class for managing address.
/// </summary>
/// <author>TienPH</author>
public class AddressService : IAddressService
{
    private readonly IAddressRepo addressRepo;

    public AddressService()
    {
        addressRepo = new AddressRepo();
    }

    /// <summary>
    /// Creates a new address in the database.
    /// </summary>
    /// <param name="address">The address object to be created.</param>
    /// <returns>Address if the address is successfully created, otherwise null.</returns>
    public Address? Create(Address address)
    {
        return addressRepo.Create(address);
    }

    /// <summary>
    /// Retrieves all address from the database.
    /// </summary>
    /// <returns>An IEnumerable of all address.</returns>    
    public IEnumerable<Address> GetAll()
    {
        return addressRepo.GetAll();
    }

    /// <summary>
    /// Updates an existing address in the database.
    /// </summary>
    /// <param name="address">The address object to be updated.</param>
    /// <returns>True if the address is successfully updated, otherwise false.</returns>
    public bool Update(Address address)
    {
        return addressRepo.Update(address);
    }

    /// <summary>
    /// Deletes a address from the database.
    /// </summary>
    /// <param name="address">The address object to be deleted.</param>
    /// <returns>True if the address is successfully deleted, otherwise false.</returns>
    public bool Delete(Address address)
    {
        return addressRepo.Delete(address);
    }
}
