using CoreAPi.BAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPi.BAL.Repository
{
  public interface IManageEmployee
    {
        Task<List<EmployeeBAL>> GetEmployee();
        Task<EmployeeTest> GetById(int? id);
        Task<string> AddEmployee(EmployeeBAL entity);
        Task<bool>  Remove(int? id);
    }
}
