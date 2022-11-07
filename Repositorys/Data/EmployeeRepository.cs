using JWTAuthentication.Context;
using JWTAuthentication.Interface;
using JWTAuthentication.Models;

namespace JWTAuthentication.Repositorys.Data
{
    public class EmployeeRepository : IEmployees
    {

        MyContext _dbContext = new MyContext();  
        public EmployeeRepository (MyContext dbContext)
        {
            _dbContext = dbContext;  
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
            }
            catch 
            {

                throw;
            }
        }

        public bool CheckEmployee(int id)
        {
            return _dbContext.Employees.Any(e => e.EmployeeId == id);
        }

        public Employee DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges ();
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch 
            {

                throw;
            }
        }

        public List<Employee> GetEmployeeDetails()
        {
            try
            {
                return _dbContext.Employees.ToList();    
            }
            catch 
            {

                throw;
            }
        }

        public Employee GetEmployeeDetails(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch 
            {

                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch 
            {

                throw;
            }
        }
    }
}
