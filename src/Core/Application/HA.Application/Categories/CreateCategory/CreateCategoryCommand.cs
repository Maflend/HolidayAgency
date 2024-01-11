using HA.ResultDomain;
using MediatR;

namespace HA.Application.Categories.CreateCategory;
public record CreateCategoryCommand(
    string Name,
    decimal PriceOfHourse) : IRequest<Result<Guid>>;
