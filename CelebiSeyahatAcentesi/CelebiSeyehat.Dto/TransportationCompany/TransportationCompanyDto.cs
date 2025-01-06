using CelebiSeyehat.Dto.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.TransportationCompany
{
    public class TransportationCompanyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TransportationType { get; set; }
        public DateTime? CreatedTime { get; set; } 


        public List<TicketDto> Tickets { get; set; }        
    }
}
