using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDAO;

/// <summary>
/// Address DAO for managing Address data in the database.
/// </summary>
/// <author>TienPH</author>
public class AddressDAO
{
    private readonly EmployeesManagementContext _empManagementDBContext;
    private readonly DbSet<Address> _dbSet;
    private static AddressDAO instance;
    private static readonly object instanceLock = new object();

    /// <summary>
    /// Gets the singleton instance of the AddressDAO.
    /// </summary>
    public static AddressDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new AddressDAO();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the AddressDAO class.
    /// </summary>
    private AddressDAO()
    {
        _empManagementDBContext = new EmployeesManagementContext();
        _dbSet = _empManagementDBContext.Set<Address>();
    }

    /// <summary>
    /// Creates a new address in the database.
    /// </summary>
    /// <param name="address">The address object to be created.</param>
    /// <returns>Address if the address is successfully created, otherwise null.</returns>
    public Address? Create(Address address)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            var result = _dbSet.Add(address);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return null;
        }
        return address;
    }

    /// <summary>
    /// Retrieves all address from the database.
    /// </summary>
    /// <returns>An IQueryable of all address.</returns>
    public IQueryable<Address> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    /// <summary>
    /// Updates an existing address in the database.
    /// </summary>
    /// <param name="address">The address object to be updated.</param>
    /// <returns>True if the address is successfully updated, otherwise false.</returns>
    public bool Update(Address address)
    {
        try
        {
            _empManagementDBContext.ChangeTracker.Clear();
            var tracker = _empManagementDBContext.Attach(address);
            tracker.State = EntityState.Modified;
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Deletes a address from the database.
    /// </summary>
    /// <param name="address">The address object to be deleted.</param>
    /// <returns>True if the address is successfully deleted, otherwise false.</returns>
    public bool Delete(Address address)
    {
        try
        {
            _dbSet.Remove(address);
            _empManagementDBContext.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }
}
