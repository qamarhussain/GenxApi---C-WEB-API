using GENXAPI.Repisitory.Model;

namespace GENXAPI.Api.Models
{
    public class JobExecutedViewListModel
    {
        public ExecutedJob executedJob { get; set; }
        public Tender tender { get; set; }
    }
}