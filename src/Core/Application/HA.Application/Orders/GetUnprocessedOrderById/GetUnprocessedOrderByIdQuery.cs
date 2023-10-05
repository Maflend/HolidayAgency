using FluentResults;
using HA.Application.Orders.GetUnprocessedOrderById.Responce;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Application.Orders.GetUnprocessedOrderById
{
    public record GetUnprocessedOrderByIdQuery(Guid id) : IRequest<Result<List<GetUnprocessedOrderByIdListDto>>>;
}
