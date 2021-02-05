using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWPF
{
    [Serializable]

    public class Employee
    {

        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department{get; set;}


        //override string method
        public override string ToString()
        {
            return $"Employee {EmployeeID} : {FirstName} {LastName} from {Department}";
        }

        //override equals method
        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                FirstName == employee.FirstName &&
                LastName == employee.LastName &&
                EmployeeID == employee.EmployeeID &&
                Department == employee.Department;
        }

        //override hashcode
        public override int GetHashCode()
        {
            int hashCode = 1858374551;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EmployeeID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Department);
            return hashCode;
        }

    }

}
