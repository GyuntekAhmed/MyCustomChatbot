using Microsoft.Data.SqlClient;

public class DatabaseHelper
{
	private string connectionString = "Server=.;Database=SisTechnologyDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;";

	public List<(string Question, string Answer)> GetFAQs()
	{
		var faqs = new List<(string Question, string Answer)>();

		using (SqlConnection connection = new SqlConnection(connectionString))
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
