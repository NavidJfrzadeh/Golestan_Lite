namespace Golestan.Core
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public int Unit { get; set; }
    }
}
