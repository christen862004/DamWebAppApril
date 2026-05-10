using DamWebAppApril.Models;

namespace DamWebAppApril.Repository
{
    //DIP
    public class EmployeeRepository : IEmployeeRepository
    {
        //CRUD :Create - Read - Upadte - Delete ++
        ITIContext context;
        public EmployeeRepository(ITIContext _ctx)
        {
            context =_ctx;// new ITIContext();//use pameterless - parmeter constructor
        }
        public void Add(Employee entity)
        {
            context.Employees.Add(entity);
        }

        public void Delete(int id)
        {
            Employee emp= GetByID(id);
            context.Employees.Remove(emp);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetByID(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            //context.Update(entity);
            Employee empDb = GetByID(entity.Id);
            empDb.Salary = entity.Salary;
            empDb.Name = entity.Name;
            empDb.ImageURl = entity.ImageURl;
            empDb.DepartmentID = entity.DepartmentID;
        }
    }
}
