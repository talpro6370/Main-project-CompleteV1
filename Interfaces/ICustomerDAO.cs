using MainProject.DAO;
using System.Collections.Generic;

namespace MainProject
{
    public interface ICustomerDAO: IBasicDB<Customer>
    {
        Customer GetCustomerByUserame(string name);
        List<long> GetAllCustomerID();
    }
}