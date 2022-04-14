namespace rapid_news_media_comments_api.Models
{
    public class Comment 
    {
        public long Id { get; set; }
        public long NewsReportId { get; set; }
        public string? Description { get; set; }
        public string? Status {get; set;}
        public string? CreatedBy { get; set;}
        public string? CreatedByUsername { get; set;}
        public DateTime? DateCreated {get; set;}
    }
}