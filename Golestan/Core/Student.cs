namespace Golestan.Core
{
    public class Student : User
    {
        public Student()
        {
            Courses = new List<StudentCourse>();
        }

        public int Age { get; set; }
        public List<StudentCourse> Courses { get; set; }


        public override bool SetPassword(string NewPass, out string message)
        {
            message = string.Empty;

            if (NewPass.Length < 8)
            {
                message = "password is less than 8";
                return false;
            }

            password = NewPass;
            message = "password was set";
            return true;
        }

        public override bool ChangePassword(string CurrentPass, string NewPass, out string Message)
        {
            if (!CheckPassword(CurrentPass))
            {
                Message = "your password is incorrect";
                return false;
            }

            if (CurrentPass == NewPass)
            {
                Message = "your new password must be Different";
                return false;
            }

            SetPassword(NewPass, out Message);
            return true;
        }
    }
}