using DataReadersStudent.Model;
using Microsoft.Data.SqlClient;

namespace DataReadersStudent.Service
{
    public class StudentService:IStudent
    {
        private readonly IConfiguration _configuration;
        public string connectionString {  get; set; }

        public StudentService(IConfiguration config)
        {
            _configuration= config;
            connectionString = _configuration["ConnectionStrings:DefaultConnection"];

        }
        public IEnumerable<Student> GetAllStudents()
        {
            List<Student>students=new List<Student>();
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from student", connection);
                SqlDataReader sdr=command.ExecuteReader();
                while (sdr.Read())
                {
                    Student std=new Student();
                    std.Id = Convert.ToInt32(sdr["id"]);
                    std.Name = sdr["name"].ToString();
                    std.Mark = Convert.ToInt32(sdr["mark"]);
                    std.Status = sdr["status"].ToString();
                    students.Add(std);
                }
                return students;
               

            }
        }
        public Student GetStudent(int id)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"select * from student where id={id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                Student std= new Student();
                while(reader.Read())
                {
                    std.Id = Convert.ToInt32(reader["id"]);
                    std.Name = reader["name"].ToString();
                    std.Mark = Convert.ToInt32(reader["mark"]);
                    std.Status = reader["status"].ToString();
                }
                return std;
            }
        }
        public void AddStudent(Student student)
        {
            using(SqlConnection connection =new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into student(name,mark,status) values(@val1,@val2,@val3)", connection);
                command.Parameters.AddWithValue("val1", student.Name);
                command.Parameters.AddWithValue("val2", student.Mark);
                command.Parameters.AddWithValue("val3",student.Status);
                command.ExecuteNonQuery();
            }
        }
        public void UpdateStudent(int id,Student student)
        {
            using(SqlConnection connection=new SqlConnection (connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("update student set name=@name,mark=@mark,status=@status where id=@id", connection);
                command.Parameters.AddWithValue("name", student.Name);
                command.Parameters.AddWithValue("mark", student.Mark);
                command.Parameters.AddWithValue("status", student.Status);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteStudent(int id)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from student where id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
