namespace Model
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GroupID { get; set; } 

        public Grupa? Group { get; set; }
    }
}