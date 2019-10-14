namespace ProjectModels.Models.Academics
{
    public class Transcript
    {
        public int TranscriptID { get; set; }

        public int ChildID { get; set; }
        public Child Child { get; set; }

        public int AcademicTermID { get; set; }
        public AcademicTerm AcademicTerm { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public double ClassScore { get; set; }
        public double ExamScore { get; set; }

        /// Derived fields
        /// 
        public double TotalScore => ClassScore + ExamScore;
        public string Grade
        {
            // TODO - work on transcript grade
            get
            {
                if (100 >= TotalScore || TotalScore >= 80)
                    return "A";
                else if (79 >= TotalScore || TotalScore >= 70)
                    return "B";
                else
                    return "F";
            }
        }
        public string Remark
        {
            // TODO - work on remark of grade
            get
            {
                switch (Grade)
                {
                    case "A":
                        return "Excellent";
                    default:
                        return "";
                }
            }
        }
    }
}
