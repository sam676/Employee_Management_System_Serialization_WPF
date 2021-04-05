using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

//////This is the Serialization Version of the Data Access Layer ///////


namespace EmployeeWPF
{
    //DataAccessLayer
    public partial class DataAccessLayer
    {

        /////////////////////////////serialization//////////////////////////////////////

        public class EmployeeRepoSerialization : IEmployeeRepository
        {


            //serialize this list of employees
            public EmployeeRepoSerialization() : this("/employees") { }

            //create directory if it doesnt already exisit
            public EmployeeRepoSerialization(string dirPath)
            {

                Dir = new DirectoryInfo(dirPath);

                if (!Dir.Exists)     
                {
                    Dir.Create();
                }

            }

            //directory accessors
            DirectoryInfo Dir { get; set; }

            //Open/create file and Create Employee - Serialization
            public int CreateEmployee(Employee e)
            {
                using (FileStream fs = new FileStream($"{Dir.FullName}/{e.EmployeeID}.bin", FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fs, e);
                }

                return e.EmployeeID;
            }

            //Delete Employee by ID
            public void DeleteEmployee(int id)
            {

                foreach (var f in Dir.GetFiles(id + ".bin"))
                {
                    f.Delete();
                }

            }


            //Delete Employee object
            public void DeleteEmployee(Employee e)
            {
                DeleteEmployee(e.EmployeeID);
            }

            //get all of the employee objects and store them in a list
            public List<Employee> GetAll()
            {
                List<Employee> result = new List<Employee>();
                BinaryFormatter b = new BinaryFormatter();
                foreach (FileInfo f in Dir.GetFiles("*.bin"))
                {
                    using (FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read)) 
                    {
                        //deserialization
                        result.Add(b.Deserialize(fs) as Employee);

                    }
                }

                return result;
            }

            //get employee by their ID #
            public Employee GetEmployeeByID(int id)
            {
                string path = $"{Dir.FullName}/{id}.bin";

                if (File.Exists(path))
                {
                    using (FileStream fs = new FileStream($"{Dir.FullName}/{id}.bin", FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter b = new BinaryFormatter();
                        //deserialization
                        return b.Deserialize(fs) as Employee;
                    }
                }
                else 
                { 
                    return null; 
                }

            }

            //update employee info
            public void UpdateEmployee(Employee e)
            {
                CreateEmployee(e);
            }

        }

    }
}