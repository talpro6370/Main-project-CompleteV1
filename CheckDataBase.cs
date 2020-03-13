using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DAO;
namespace MainProject
{
    public class CheckDataBase
    {
        public bool DataBaseStatus()
        {
            AirLineDAOMSSQL alDAO = new AirLineDAOMSSQL();
            CountryDAOMSSQL cDAO = new CountryDAOMSSQL();
            CustomerDAOMSSQL custDAO = new CustomerDAOMSSQL();
            if (alDAO.GetAll().Count() == 0&& cDAO.GetAll().Count() == 0 && custDAO.GetAll().Count() == 0)
                return true;
            return false;
        }
    }
}
