using Dapper;
using EmployeeApi.Context;
using EmployeeApi.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository 
    {
        private readonly DapperContext _context; 

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var sp = "[dbo].[Sp.GetEmployees]";

            using(var connection = _context.CreateConnection())
            {
                var getData = await connection.QueryAsync<Employee>(sp, commandType: CommandType.StoredProcedure);
                return getData.ToList(); 
            }
        }
        public async Task<Employee> GetEmployee(int EmployeeID)
        {
            var sp = "[dbo].[Sp.GetEmployee]";
            var parameter = new DynamicParameters();
            parameter.Add("EmployeeID", EmployeeID, DbType.Int32, ParameterDirection.Input); 

            using (var connection = _context.CreateConnection())
            {
                var getData = await connection.QuerySingleOrDefaultAsync<Employee>(sp, parameter, commandType: CommandType.StoredProcedure);
                return getData;
            }
        }

        public async Task DeleteEmployee(int EmployeeID)
        {
            var sp = "[dbo].[Sp.DeleteEmployee]";
            var parameter = new DynamicParameters();
            parameter.Add("EmployeeID", EmployeeID, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var data = await connection.ExecuteAsync(sp, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        { 
            var sp = "[dbo].[Sp.CreateEmployee]";
            var parameter = new DynamicParameters();
            parameter.Add("EmployeeName", employee.EmployeeName);
            parameter.Add("EmployeeAddress", employee.EmployeeAddress);
            parameter.Add("PhoneNumber", employee.PhoneNumber);

            using (var connection = _context.CreateConnection())
            {
                var getData = await connection.QuerySingleOrDefaultAsync<Employee>(sp, parameter, commandType: CommandType.StoredProcedure);
                var data = new Employee
                {
                    EmployeeID = getData.EmployeeID,
                    EmployeeName = getData.EmployeeName,
                    EmployeeAddress = getData.EmployeeAddress,
                    PhoneNumber = getData.PhoneNumber
                };
                return data;
            }
        }

        public async Task<Employee> UpdateEmployee(int EmployeeID, Employee employee)
        {
            var sp = "[dbo].[Sp.UpdateEmployee]";
            var parameter = new DynamicParameters();
            parameter.Add("EmployeeID", EmployeeID, DbType.Int32);
            parameter.Add("EmployeeName", employee.EmployeeName);
            parameter.Add("EmployeeAddress", employee.EmployeeAddress);
            parameter.Add("PhoneNumber", employee.PhoneNumber);

            using (var connection = _context.CreateConnection())
            {
                var getData = await connection.QuerySingleOrDefaultAsync<Employee>(sp, parameter, commandType: CommandType.StoredProcedure);
                var data = new Employee
                {
                    EmployeeID = getData.EmployeeID, 
                    EmployeeName = getData.EmployeeName,
                    EmployeeAddress = getData.EmployeeAddress,
                    PhoneNumber = getData.PhoneNumber
                };
                return data; 
            }

        }
    }
}
