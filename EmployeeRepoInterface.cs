using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWPF
{
    //interface
    public interface EmployeeRepository
    {

        List<Employee> GetAll();

        Employee GetEmployeeByID(int id);

        void UpdateEmployee(Employee e);

        int CreateEmployee(Employee e);

        void DeleteEmployee(Employee e);

        void DeleteEmployee(int id);





    
    
    
    }
}
