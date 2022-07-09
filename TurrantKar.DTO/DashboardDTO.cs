using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class DashboardDTO : BaseDTO
    {

        public int TotalOrders
        {
            get; set;
        }


        public int TotalProducts
        {
            get; set;
        }

        public int TotalCategories
        {
            get; set;
        }

        public int TotalUsers
        {
            get; set;
        }
    }
}
