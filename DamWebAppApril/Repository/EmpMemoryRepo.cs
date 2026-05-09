using DamWebAppApril.Models;

namespace DamWebAppApril.Repository
{
    public class EmpMemoryRepo : IEmployeeRepository
    {
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>() { 
                new Employee(){ Id=11,Name="ahmed"},
                new Employee(){ Id=12,Name="Sara"},
            };
        }

        public Employee GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
