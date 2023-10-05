using HA.Domain.Categories;
using HA.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Application.Orders.GetUnprocessedOrderById.Responce
{
    public class GetUnprocessedOrderByIdListDto
    {

        public Guid Id { get; set; }

        public DateTime EventDate { get; set; }

        public string Address { get; set; }

        public double CountHours { get; set; }

        public int CountPeople { get; set; }

        public string CategoryName { get; set; }

        public ClientInfoDto Client { get; set; }
    }
}
