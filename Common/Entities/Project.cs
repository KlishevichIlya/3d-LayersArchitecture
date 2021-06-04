using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DateOfStartProject { get; set; }
        public List<Developer> CurrentDevelopers { get; set; }
        public List<WorkHistory> PreviousDevelopers { get; set; }
    }
}
