namespace API_test_1
{
    public class Constants
    {
        public static string Host = "localhost";
        public static string Username = "postgres";
        public static string Password = "123"; 
        public static string DatabaseName = "postgres";
        public static string Connect => $"Host={Host};Username={Username};Password={Password};Database={DatabaseName}";
    }
}
