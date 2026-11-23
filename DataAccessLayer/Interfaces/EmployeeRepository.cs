using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository //implementing the interace, meaning we have to implement all of the methods that exist in it
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        //Implement GetEmployeesAsync method from our IEmployeeRepository interface
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        //Adding the employee to my Employees dbset, and then saving the changes
        //The employee being passed in, is coming from the business logic layer
        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id); //returns the employee from my Employees DbSet that has a matching ID
        }
        public async Task GetDetailsAsync(Employee employeeWithDetails)
        {
            var employee = await _context.Employees.FindAsync(employeeWithDetails.Id);
        }
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Position = employee.Position;
                existingEmployee.Salary = employee.Salary;
                await _context.SaveChangesAsync();
            }
            else
            {
                await Console.Out.WriteLineAsync("Not Found");
            }
        }
    }
}
