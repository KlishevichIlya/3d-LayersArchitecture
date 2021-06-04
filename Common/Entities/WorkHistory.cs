namespace Common.Entities
{
    public class WorkHistory
    {
        public int PreviousDeveloperId{get;set; }
        public Developer Developer { get; set; }
        public int PreviousProjectId { get; set; }
        public Project Project { get; set; }
    }
}
