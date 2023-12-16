using Golestan.Core;
using Golestan.Services;

Authentication authenticationService = new Authentication();
string input;

while (true)
{
    Console.WriteLine("1.Login\n2.Register");
    input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("enter your Email:");
            var userEmail = Console.ReadLine();

            Console.WriteLine("enter your password:");
            var userPassword = Console.ReadLine();

            //show enums:
            Console.WriteLine("enter your Role:");
            foreach (var type in Enum.GetNames(typeof(RoleEnum)))
            {
                Console.WriteLine($"{(int)Enum.Parse(typeof(RoleEnum), type)}.{type}");
            }
            var role = (RoleEnum)Enum.Parse(typeof(RoleEnum), Console.ReadLine());

            DataBase.CurrentUser = authenticationService.Login(userEmail, userPassword, role);

            if (DataBase.CurrentUser != null)
            {
                switch (DataBase.CurrentUser)
                {
                    case Student:
                        //Student st = DataBase.CurrentUser as Student;
                        Student st = (Student)DataBase.CurrentUser;
                        Console.WriteLine($"Hello {st.Name} {st.LastName}");
                        Console.WriteLine("Choose Action:\n1.Change Password\n2.register Course");
                        var studentInput = Console.ReadLine();

                        switch (studentInput)
                        {
                            case "1":
                                ChangePassword();
                                break;


                            case "2":
                                RegisterCourse();
                                break;
                        }
                        break;


                    case Teacher:
                        Teacher te = (Teacher)DataBase.CurrentUser;
                        Console.WriteLine($"Hello {te.Name} {te.LastName}");
                        Console.WriteLine("Choose Action:\n1.Change Password:");
                        Console.ReadLine();
                        ChangePassword();

                        break;


                    case Admin:
                        Admin ad = (Admin)DataBase.CurrentUser;
                        Console.WriteLine($"Hello {ad.Name} {ad.LastName}");
                        Console.WriteLine("Choose Action:\n1.Change Password:");
                        Console.ReadLine();
                        ChangePassword();

                        break;
                }
            }
            break;


        case "2":
            Console.WriteLine("enter your Role for register: (1.admin 2.Teacher 3.student)");
            var roleinput = int.Parse(Console.ReadLine());

            switch (roleinput)
            {
                case 1:
                    Console.Write("enter your name :");
                    var adname = Console.ReadLine();

                    Console.Write("enter your lastname : ");
                    var adLastName = Console.ReadLine();

                    Admin newAdmin = new Admin() {Name=adname,LastName=adLastName };

                    Console.WriteLine("enter your Email: ");
                    newAdmin.UserName = Console.ReadLine();
                    
                    Console.WriteLine("enter your password");
                    newAdmin.SetPassword(Console.ReadLine(), out string Message);

                   // authenticationService.Register(newAdmin);
                    break;

                case 2:
                    break;

                case 3:
                    break;
            }

            break;

    }
}

void ChangePassword()
{
    Console.Write("enter your current password : ");
    var currentPass = Console.ReadLine();

    Console.Write("enter your new password : ");
    var newPass = Console.ReadLine();

    if (DataBase.CurrentUser != null)
    {
        DataBase.CurrentUser.ChangePassword(currentPass ?? "", newPass ?? "", out string msg);

        Console.WriteLine(msg);
    }
}


void RegisterCourse()
{
    Console.WriteLine("please select a course:");
    var student = (Student)(DataBase.CurrentUser ?? new Student() { Name = "ali", LastName = "alie" });
    var studentCourse = student.Courses.Select(x => x.Course).ToList();

    //foreach (var item in DataBase.CourseList.Where(x => !studentCourse.Any(c => c.Id == x.Id)).ToList())
    foreach (var item in DataBase.CourseList.Where(x => studentCourse.All(c => c.Id != x.Id)).ToList())
    {
        Console.WriteLine($"{item.Id} - {item.Name} ({item.Teacher.Name} {item.Teacher.LastName})");
    }

    var courseId = int.Parse(Console.ReadLine());

    var targetCourse = DataBase.CourseList.FirstOrDefault(x => x.Id == courseId);

    if (targetCourse != null)
    {
        student.Courses.Add(new StudentCourse
        {
            Course = targetCourse,
            Grade = null,
            RegisterDate = DateTime.Now
        });
    }
}