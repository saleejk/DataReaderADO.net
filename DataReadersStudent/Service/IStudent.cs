using DataReadersStudent.Model;

namespace DataReadersStudent.Service
{
    public interface IStudent
    {
        IEnumerable<Student> GetAllStudents();
        public Student GetStudent(int id);
        public void AddStudent(Student students);
        public void UpdateStudent(int id,Student student);
        public void DeleteStudent(int id);
    }
}
