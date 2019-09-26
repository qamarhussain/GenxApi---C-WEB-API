using System;

namespace GENXAPI.Api.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public Guid GuId { get; set; }
        public string FileName { get; set; }
        public string FileUploadedName { get; set; }
        public int JobId { get; set; }
        public int CustomerId { get; set; }
        public int ContractId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
