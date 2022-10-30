using ThalesBack.Data;
using ThalesBack.Entity;

namespace ThalesBack.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeesData context;

        public EmployeeService(EmployeesData context)
        {
            this.context = context;
        }

        public async Task<List<Employee>> GetAll()
        {
            var result = await context.GetAll();
            
            if (result.status == "success")
            {
                foreach (var employee in result.data)
                {
                    employee.employee_salary = CalculateSalary(employee.employee_salary);
                }
                return result.data;
            }
            else
            {
                throw new ArgumentException("An error has occurred", result.message);
            }
            
        }

        public async Task<List<Employee>> GetEmployee(int id)
        {
            var result = await context.GetEmployee(id);
            List<Employee> list = new List<Employee>();

            if (result.status == "success")
            {
                result.data.employee_salary = CalculateSalary(result.data.employee_salary);
                list.Add(result.data);
                return list;
            }
            else
            {
                throw new ArgumentException("An error has occurred", result.message);
            }
        }

        private int CalculateSalary (int salary)
        {
            salary = salary * 12;
            return salary;
        }

    }
}
