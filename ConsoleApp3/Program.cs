namespace ConsoleApp3
    
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conntectionString = @"Data Source = (localdb)\.; Initial Catalog = SchoolLabb1; Integrated Security = True; Pooling = False";
            using (SqlConnection connection = new SqlConnection(conntectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand()) 
                { 
                }
            }
        }
    }
}