using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Followers { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public DateTime DateOfStartWorking { get; set; }
        public int? CurrentProjectId { get; set; }
        public Project CurrentProject { get; set; }  
        public List<WorkHistory> PreviousProjects { get; set; }
    }
}
