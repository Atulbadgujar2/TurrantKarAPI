using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class  ReturnRequestDTO : BaseDTO
    {
        public string ReasonForReturn { get; set; }
        public string RequestedAction { get; set; }
        public int CustomerId { get; set; }
        public string CustomNumber { get; set; }
        public int StoreId { get; set; }
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public string CustomerComments { get; set; }
        public int UploadedFileId { get; set; }
        public string StaffNotes { get; set; }
        public int ReturnRequestStatusId { get; set; }
    }
}
