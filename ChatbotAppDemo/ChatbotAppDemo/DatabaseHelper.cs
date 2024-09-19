using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DatabaseHelper
{
	private readonly string _connectionString;

	public DatabaseHelper(IConfiguration configuration)
	{
		_connectionString = configuration.GetConnectionString("DefaultConnection");
	}

	public List<(string Question, string Answer)> GetFAQs()
	{
		var faqs = new List<(string Question, string Answer)>();

		using (SqlConnection connection = new SqlConnection(_connectionString))
		{
			connection.Open();
			string query = "SELECT Question, Answer FROM FAQ";
			SqlCommand command = new SqlCommand(query, connection);
			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				faqs.Add((reader["Question"].ToString(), reader["Answer"].ToString()));
			}
		}

		return faqs;
	}
}

