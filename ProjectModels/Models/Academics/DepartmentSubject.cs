namespace ProjectModels.Models.Academics
{
    public class DepartmentSubject
    {
        public int DepartmentSubjectID { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
