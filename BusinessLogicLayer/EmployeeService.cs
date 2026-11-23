using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            //business logic would be written here 
            return await _employeeRepository.GetEmployeesAsync();
        }
        //This employee being passed in is coming from my controller in the application layer
        //...and I am writing business logic on this employee before passing it in to my DAL
        //.........which is where the changes are being executed on my DbSet which goes to the database
        public async Task AddEmployeeAsync(Employee employee)
        {
            //write your logic
            //.. for example, we want the budget for each employee to be 250,000
            if (employee.Salary <= 250000)
            {
                await _employeeRepository.AddEmployeeAsync(employee);
            }
            else
            {
                //
            }
        }
        //This id being passed in is coming from my controller
        //...then we pass it into the method in our DAL to get the specific employee from the database
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task GetDetailsAsync(Employee employee)
        {
            await _employeeRepository.GetDetailsAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            //write your logic
            //.. for example, we want the budget for each employee to be 250,000
            if (employee.Salary <= 250000)
            {
                await _employeeRepository.UpdateEmployeeAsync(employee);
            }
            else
            {
                //
            }
        }
    }
}
