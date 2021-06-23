using System;
namespace ApplicationCore.Models.Request
{
    public class PurchaseRequestModel
    {
        public PurchaseRequestModel()
        {
            PurchaseDateTime = DateTime.Now;
            PurchaseNumber = Guid.NewGuid();
        }

        public int UserId { get; set; }
        public int MovieId { get; set; }
        public Guid? PurchaseNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? PurchaseDateTime { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public decimal? Price { get; set; }
    }
}
