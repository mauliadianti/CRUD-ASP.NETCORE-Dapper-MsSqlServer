using EmployeeApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EmployeeApi.Repository
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees(); 
        public Task<Employee>GetEmployee(int EmployeeID);
        public Task DeleteEmployee(int EmployeeID);
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<Employee> UpdateEmployee(int EmployeeID, Employee employee); 
    }

    
}
