using Golestan.Core;

namespace Golestan.Services
{
    public class Authentication
    {
        public User Login(string Email, string Password, RoleEnum role)
        {
            Console.Clear();

            switch (role)
            {
                case RoleEnum.Admin:
                    var admin = DataBase.Admins.FirstOrDefault(x => x.UserName == Email);
                    if (admin != null)
                    {
                        if (admin.CheckPassword(Password))
                            return admin;

                        Console.WriteLine("your password is not correct");
                        return null;
                    }
                    Console.WriteLine("you dont have account!");
                    return null;



                case RoleEnum.Teacher:
                    var teacher = DataBase.TeachersList.FirstOrDefault(x => x.UserName == Email);
                    if (teacher != null)
                    {
                        if (teacher.CheckPassword(Password))
                            return teacher;

                        Console.WriteLine("your password is not correct");
                        return null;
                    }
                    Console.WriteLine("you dont have account!");
                    return null;



                case RoleEnum.Student:
                    var student = DataBase.StudentList.FirstOrDefault(x => x.UserName == Email);
                    if (student != null)
                    {
                        if (student.CheckPassword(Password))
                            return student;

                        Console.WriteLine("your password is not correct");
                        return null;
                    }
                    Console.WriteLine("you dont have account!");
                    return null;



                default:
                    return null;
            }
        }




    }
}
