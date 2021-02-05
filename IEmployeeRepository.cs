using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWPF
{
    public interface IEmployeeRepository
    {
        //create a list of all the Employees
        List<Employee> GetAll();

        //Get an employee by their ID 
        Employee GetEmployeeByID(int id);

        //update Employee info
        void UpdateEmployee(Employee e);

        //Create a new Employee
        int CreateEmployee(Employee e);

        //Delete an Employee by Employee object
        void DeleteEmployee(Employee e);

        //Delete an Employee by Employee id #
        void DeleteEmployee(int id);
    }
}
