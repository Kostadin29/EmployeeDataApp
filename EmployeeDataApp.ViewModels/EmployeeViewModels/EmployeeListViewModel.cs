using System.ComponentModel;

namespace EmployeeDataApp.ViewModels.EmployeeViewModels
{
    public class EmployeeListViewModel
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;
        public double Salary { get; set; }

        [DisplayName("Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
