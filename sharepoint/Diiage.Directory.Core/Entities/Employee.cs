using System;

#nullable disable

namespace Diiage.Directory.Core.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string DirectoryId { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public DateTime StartDate { get; set; }
        public string Position { get; set; }
        public string PositionLevel { get; set; }
        public int AnnualGrossIncome { get; set; }
        public string Email { get; set; }
        public string PersonalEmail { get; set; }
        public string Phone { get; set; }
        public string PersonalPhone { get; set; }
        public DateTime BirthDate { get; set; }
        public Address PersonalAddress { get; set; }
        public Address Address { get; set; }
        public string Comments { get; set; }
    }
}
