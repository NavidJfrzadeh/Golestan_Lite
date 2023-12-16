using Golestan.Core;

namespace Golestan.Core
{
    public static class DataBase
    {
        public static List<Course> CourseList { get; set; }
        public static List<Teacher> TeachersList { get; set; }
        public static List<Student> StudentList { get; set; }
        public static List<Admin> Admins { get; set; }
        public static User? CurrentUser { get; set; }


        static DataBase()
        {
            CourseList = new List<Course>()
            {
                new Course{Id=1,Name="DS",Teacher=TeachersList.ElementAt(0),Unit=3},
                new Course{Id=2,Name="OS",Teacher=TeachersList.ElementAt(0),Unit=3},
                new Course{Id=3,Name="DB",Teacher=TeachersList.ElementAt(1),Unit=2}
            };



            //teachers
            TeachersList = new List<Teacher>()
            {
                new Teacher{Id=1001,Name="Mahmood",LastName="savarian",UserName="savarian@",Role=RoleEnum.Teacher},
                new Teacher{Id=1002,Name="Rasool",LastName="Yekta",UserName="yekta@",Role = RoleEnum.Teacher}
            };
            TeachersList.ElementAt(0).SetPassword("123456", out string message);
            TeachersList.ElementAt(1).SetPassword("123456", out string Message);



            //students
            StudentList = new List<Student>()
            {
                new Student{Id=100,Name = "navid", LastName = "Jafarzadeh",Age=22,UserName="navid@",Role=RoleEnum.Student,
                    Courses={new StudentCourse{Course=CourseList[0],Grade=17.5m,RegisterDate=DateTime.Now},
                    new StudentCourse{Course=CourseList[1],Grade=15m,RegisterDate=DateTime.Now}
                    }
                },

                new Student{Id=100,Name = "reza", LastName = "rezaii",Age=20,UserName="reza@",Role=RoleEnum.Student,
                    Courses={new StudentCourse{Course=CourseList[1],Grade=15.5m,RegisterDate=DateTime.Now},
                    new StudentCourse{Course=CourseList[2],Grade=18.5m,RegisterDate=DateTime.Now}
                    }
                }
            };
            StudentList.ElementAt(0).SetPassword("123456", out string Message1);
            StudentList.ElementAt(1).SetPassword("1234567", out string Message2);



            //admins
            Admins = new List<Admin>
            {
               new Admin{Id=10,Name="admin",LastName="admin",UserName="admin@",Role=RoleEnum.Admin}
            };
            Admins.ElementAt(0).SetPassword("123", out string msg);
        }
    }
}
