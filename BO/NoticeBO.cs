namespace HSMS.API.BO
{
    public class NoticeBO
    {
        public int NoticeId { get; set; }

        public string? NoticeTitle { get; set; }
        public string? NoticeDescription { get; set; }
        public string? NoticeCategory { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? TargetAudience { get; set; }
        public string? Status { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}