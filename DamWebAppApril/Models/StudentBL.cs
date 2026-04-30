namespace DamWebAppApril.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>() { 
                new Student(){ Id=1,Name="Ahmed",ImageURl="m.png",Address="alex"},
                new Student(){ Id=2,Name="Mohamd",ImageURl="m.png",Address="alex"},
                new Student(){ Id=3,Name="Samar",ImageURl="2.jpg",Address="alex"},
            };
        }

        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetByID(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
