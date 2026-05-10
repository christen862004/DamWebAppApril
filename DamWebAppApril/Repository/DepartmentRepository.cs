using DamWebAppApril.Models;

namespace DamWebAppApril.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext context;
        public DepartmentRepository(ITIContext _ctx)
        {
            context = _ctx;// new ITIContext();
        }
        //CRUD
        public void Add(Department entity)
        {
            context.Departments.Add(entity);
        }

        public void Delete(int id)
        {
            Department dept = GetByID(id);
            context.Departments.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Department entity)
        {
            Department deptDb=GetByID(entity.Id);
            deptDb.Name = entity.Name;
            deptDb.ManagerName = entity.ManagerName;
        }
    }
}
