//using HA.Api.Dtos;
//using HA.Domain.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace HA.Api.Controllers.User;

//[Route("api/categories")]
//[ApiController]
//public class CategoryController : ControllerBase
//{
//    public CategoryController()
//    {

//    }

//    [HttpGet]
//    public IReadOnlyList<GetCategoryDto> GetCategories()
//    {
//        return DataStorage.Categories.Select(c => new GetCategoryDto()
//        {
//            Id = c.Id,
//            Name = c.Name
//        }).ToList();
//    }

//    [HttpGet("{id}/orders")]
//    public IReadOnlyList<GetNewOrderDto> GetOrders([FromRoute] Guid id)
//    {
//        return DataStorage.Orders
//            .Where(o => o.CategoryId == id)
//            .Select(order => new GetNewOrderDto()
//            {
//                Id = id,
//                EventDate = order.EventDate,
//                State = order.State,
//                CountHourse = order.CountHours,
//                Address = order.Address,
//                Category = new OrderCategoryDto()
//                {
//                    Id = order.CategoryId,
//                    Name = order.Category.Name
//                },
//                Client = new OrderClientDto()
//                {
//                    Id = order.ClientId,
//                    FullName = order.Client.FullName,
//                    Phone = order.Client.Phone
//                }
//            })
//            .ToList();
//    }

//    [HttpPost]
//    public void CreateCategory(CreateCategoryDto createCategoryDto)
//    {
//        DataStorage.Categories.Add(new Category()
//        {
//            Id = new Guid(),
//            Name = createCategoryDto.Name
//        });
//    }
//}
