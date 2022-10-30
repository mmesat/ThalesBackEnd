namespace ThalesBack.Entity
{
    public class ResponseEmployees
    {
        public string status { get; set; }
        public List<Employee> data { get; set; }
        public string message { get; set; }

    }
}
