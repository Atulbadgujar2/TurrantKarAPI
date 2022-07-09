using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class  CustomerAddressesDTO : BaseDTO
    {
        public int AddressId { get; set; }

        public int CustomerId { get; set; }
    }
}
