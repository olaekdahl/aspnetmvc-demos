using AdventureWorks.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Models.DAL
{
    public class DataAccess
    {
        private AdventureWorksContext ctx;
        public DataAccess()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            ctx = new AdventureWorksContext();
        }
        public List<Product> GetProducts()
        {
            return ctx.Products.ToList();
        }

        public List<Product> Search(string product)
        {
            return ctx.Search(product).ToList();
        }

        public void AddEmployee(EmployeeViewModel e)
        {
            ctx.AddEmployee(e.NationalIDNumber, 
                e.LoginID, e.FirstName, 
                e.LastName, 
                e.JobTitle, 
                e.BirthDate, 
                e.MaritalStatus, 
                e.Gender, e.HireDate, 
                e.SalariedFlag, 
                e.VacationHours, 
                e.SickLeaveHours);
        }



        public List<Person> GetEmployees()
        {
            return ctx.People.Where(e => e.PersonType.Equals("EM")).OrderBy(e => e.FirstName).ToList();
        }

        public Product GetProduct(int id)
        {
            return ctx.Products.Find(id);
        }

        public byte[] GetPhoto(int pid)
        {
            return ctx.GetPhoto(pid).FirstOrDefault();
        }
    }
}
