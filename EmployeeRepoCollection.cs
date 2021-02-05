using System.Collections.Generic;
using System.Linq;

//////This is the Regular Version of the Data Access Layer (non serilization)  ///////


namespace EmployeeWPF
{

    public partial class DataAccessLayer
    {
        //EmployeeRepoCollection class implements EmployeeRepository interface
        public class EmployeeRepoCollection : IEmployeeRepository
        {

            //EmployeeRepoCollection constructor
            public EmployeeRepoCollection()
            {
                Employees = new List<Employee>();

            }

            //create a list of Employees
            List<Employee> Employees { get; set; }


            //Get all employees
            public List<Employee> GetAll()
            {
                return Employees;
            }

            //get employee by ID
            public Employee GetEmployeeByID(int id)
            {
                return Employees.Find(e => e.EmployeeID == id);
            }

            //update employee
            public void UpdateEmployee(Employee e)
            {
                Employee original = Employees.Find(ef => ef.EmployeeID == e.EmployeeID);

                //try catch block here!!!!

                //First test to confirm employee obj is still there
                if (original != null)
                {
                    int index = Employees.IndexOf(original);
                    Employees.Remove(original);
                    Employees.Insert(index, e);
                }
                else
                {
                    CreateEmployee(e);
                }
            }

            //Create Employee
            public int CreateEmployee(Employee e)
            {
                if (Employees.Where(em => em.EmployeeID == e.EmployeeID).Count() == 0)
                {

                    Employees.Add(e);
                    return Employees.FindLastIndex(x => x.Equals(e));

                }
                else
                {
                    return -1;
                }
            }

            //Delete Employee by Employee object
            public void DeleteEmployee(Employee e)
            {

                Employees.Remove(e);

            }

            //Delete Employee by Employee ID

            public void DeleteEmployee(int id)
            {

                Employees = Employees.Where(e => e.EmployeeID != id) as List<Employee>;

            }

        }

    }
}