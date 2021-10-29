using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUT
{
    public interface ICustomerRepository
    {
        string GetNameById(long id);
    }

    public class MySQLCustomerRepository : ICustomerRepository
    {
        public string GetNameById(long id)
        {
            // search MySQL database and return 
            return null;
        }
    }

    public class Grettings
    {
        private ICustomerRepository _rep;
        public Grettings(ICustomerRepository rep)
        {
            this._rep = rep;
        }

        public string PrepareGrettings(long id)
        {
            return "Hello " + this._rep.GetNameById(id);
        }
    }
}
