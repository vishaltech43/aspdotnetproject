namespace EmployeeManagement.Models
{
    public class EmployeeBusinessLayer
    {
        private static List<Employee> employees = new List<Employee>();

        public static List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public static void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public static List<Employee> DeleteEmployee(int id)
        {
            Employee employee = employees.Find(s => s.EmployeeId == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return employees;
        }

        public static void DeleteEmployee2(List<int> ids)
        {
            if (ids == null || !ids.Any())
                return;



            employees.RemoveAll(e => ids.Contains(e.EmployeeId));
        }


        //check available 
        public static List<Employee> Filter(string jobTitle, string employeeType, string salaryOrder, string dateOrder)
        {
            List<Employee> filteredList = employees;

            if (jobTitle != null)
            {
                filteredList = filteredList.FindAll(e => e.JobTitle == jobTitle);
            }

            if (employeeType != null)
            {
                filteredList = filteredList.FindAll(e => e.EmployeeType == employeeType);
            }

            if (dateOrder != null)
            {
                if (dateOrder == "asc")
                {
                    filteredList.Sort((e1, e2) => e1.DateOfJoining.CompareTo(e2.DateOfJoining));
                }
                else if (dateOrder == "desc")
                {
                    filteredList.Sort((e1, e2) => e2.DateOfJoining.CompareTo(e1.DateOfJoining));
                }
            }

            if (salaryOrder != null)
            {
                if (salaryOrder == "asc")
                {
                    filteredList.Sort((e1, e2) => e1.Salary.CompareTo(e2.Salary));
                }
                else if (salaryOrder == "desc")
                {
                    filteredList.Sort((e1, e2) => e2.Salary.CompareTo(e1.Salary));
                }
            }

            return filteredList;
        }
    }
}
