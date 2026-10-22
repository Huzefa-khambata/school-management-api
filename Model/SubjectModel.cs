namespace HSMS.API.Model
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }

        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
        public string? AssignedTeacher { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
    }
}