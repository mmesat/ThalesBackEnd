using ThalesBack.Entity;

namespace ThalesBack.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<List<Employee>> GetEmployee(int id);
    }
}
