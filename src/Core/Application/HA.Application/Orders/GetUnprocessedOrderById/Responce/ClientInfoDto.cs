﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Application.Orders.GetUnprocessedOrderById.Responce
{
    public class ClientInfoDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Patronymic { get; set; }

        public string Phone { get; set; }
    }
}