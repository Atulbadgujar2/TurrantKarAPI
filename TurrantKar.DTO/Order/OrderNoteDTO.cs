using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class OrderNoteDTO : BaseDTO
    {
        public string Note { get; set; }

        public int OrderId { get; set; }

        public int DownloadId { get; set; }

        public bool DisplayToCustomer { get; set; }
    }
}
