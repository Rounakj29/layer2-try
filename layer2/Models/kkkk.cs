using layer2.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace layer2.Models
{
    public class kkkk
    {
        layer2Context _dbContext;

        public async Task<User> Create(User _object)
        {
            var obj = await _dbContext.User.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        private readonly layer2Context _context;

        public kkkk(layer2Context context)
        {
            _context = context;
        }

        public Task<List<User>> GetEmployee()
        {
            return  _context.User.ToListAsync();
        }
        public IEnumerable<User> GetDetails
        {
            get
            {

                // var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WingtipToys"].ConnectionString;
                string CS = System.Configuration.ConfigurationManager.ConnectionStrings["layer2Context"].ConnectionString;
                List<User> employees = new List<User>();
                using (SqlConnection con = new SqlConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        User employee = new User();
                        employee.id = Convert.ToInt32(dr["UserId"]);
                        employee.name = dr["Name"].ToString();
                        employee.age = Convert.ToInt32(dr["Age"]);
                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }
        public void AddEmployee(User employee)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["layer2Context"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.name);
                cmd.Parameters.AddWithValue("@Age", employee.age);
                
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEmployee(User employee)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["layer2Context"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", employee.id);
                cmd.Parameters.AddWithValue("@Name", employee.name);
                cmd.Parameters.AddWithValue("@Age", employee.age);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int id)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["layer2Context"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}