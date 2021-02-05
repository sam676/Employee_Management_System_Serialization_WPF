using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static EmployeeWPF.DataAccessLayer; 
using static EmployeeWPF.EmployeeBusinessLogicLayer;

namespace EmployeeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            employees = new EmployeeRepoCollection();
        }

        //Employee Repo Interface accessors
        IEmployeeRepository employees { get; set; }

        //The Add button adds an employee to the database
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (employees.CreateEmployee( 
                    new Employee() { 
                        Department = DepartmentTextBox.Text, 
                        EmployeeID = Int32.Parse(IDTextBox.Text), 
                        FirstName = FirstNameTextBox.Text, 
                        LastName = LastNameTextBox.Text 
                    }) > -1)
                {

                    MessageBox.Show($"Created Employee ID {IDTextBox.Text}. \n");
                }
                else
                {
                    MessageBox.Show($"Employee ID {IDTextBox.Text} already exists or ID is negative. \n");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //creates a new directory where you enter path from textbox! 
        private void CreateDirectory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(DirectoryTextBox.Text);

                if (directory.Exists)
                {
                    MessageBox.Show("Directory already exists!");
                    return;
                }
                else {
                    MessageBox.Show($"Directory {directory} was created!");
                }

                directory.Create();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //serializes employee
        private void serialize_Click(object sender, RoutedEventArgs e)
        {

            employees = new EmployeeRepoSerialization(DirectoryTextBox.Text);

            try
            {

                if (employees.CreateEmployee(new Employee() { Department = DepartmentTextBox.Text, EmployeeID = Int32.Parse(IDTextBox.Text), FirstName = FirstNameTextBox.Text, LastName = LastNameTextBox.Text }) > -1)
                {

                    MessageBox.Show($"Created Employee ID {IDTextBox.Text}. \n");
                }
                else
                {
                    MessageBox.Show($"Employee ID {IDTextBox.Text} already exists or ID is negative. \n");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        //delete the employee from the database with this button!
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try {

                if (employees.GetEmployeeByID(Int32.Parse(IDTextBox.Text)) != null)
                {
                    employees.DeleteEmployee(new Employee() { Department = DepartmentTextBox.Text, EmployeeID = Int32.Parse(IDTextBox.Text), FirstName = FirstNameTextBox.Text, LastName = LastNameTextBox.Text });
                    MessageBox.Show($"Deleted Employee ID {IDTextBox.Text}");
                }
                else 
                {
                    MessageBox.Show($"Employee ID {IDTextBox.Text} not deleted, can't be found. \n");
                }
            
            } catch(Exception ex) {

                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (employees.GetEmployeeByID(Int32.Parse(IDTextBox.Text)) != null)
                {
                    employees.UpdateEmployee(new Employee() { Department = DepartmentTextBox.Text, EmployeeID = Int32.Parse(IDTextBox.Text), FirstName = FirstNameTextBox.Text, LastName = LastNameTextBox.Text });
                    MessageBox.Show($"Updated Employee ID {IDTextBox.Text}. \n");
                }
                else {

                    MessageBox.Show($"No Employee found with ID {IDTextBox.Text}\n");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetUsingID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee em = employees.GetEmployeeByID(Int32.Parse(IDTextBox.Text));
                if (em != null) {

                   MessageBox.Show($"Recieved {em}. \n");
                }

                else 
                {
                  
                    MessageBox.Show($"No Employee found with ID {IDTextBox.Text}\n");
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Employee> ems = employees.GetAll();
                foreach (Employee em in ems) {
                   
                    MessageBox.Show($"Recieved {em}. \n");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    
    }
}
