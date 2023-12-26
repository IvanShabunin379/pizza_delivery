using AutoMapper;

using PizzaDelivery.BL;
using PizzaDelivery.BL.Orders.Entities;

using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.WebAPI.Controllers.Entities.Orders;
namespace Service.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(IProvider<OrderModel, OrdersModelFilter> provider, IManager<OrderModel, CreateOrderModel> manager, IMapper mapper, ILogger logger) : ControllerBase
{
    private readonly IProvider<OrderModel, OrdersModelFilter> _provider = provider;
    private readonly IManager<OrderModel, CreateOrderModel> _manager = manager;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger _logger = logger;

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var orders = _provider.Get();

        return Ok(new OrdersListResponse()
        {
            Orders = orders.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredOrders([FromQuery] OrdersFilter filter)
    {
        var orders = _provider.Get(_mapper.Map<OrdersModelFilter>(filter));

        return Ok(new OrdersListResponse()
        {
            Orders = orders.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetOrderInfo([FromRoute] Guid id)
    {
        try
        {
            var order = _provider.GetInfo(id);

            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            var order = _manager.Create(_mapper.Map<CreateOrderModel>(request));

            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateOrderInfo([FromRoute] Guid id, UpdateOrderRequest request)
    {
        try
        {
            var order = _provider.GetInfo(id);

            if (order is null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            _mapper.Map(request, order);

            var updatedOrder = _manager.Update(id, order);

            return Ok(updatedOrder);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteOrder([FromRoute] Guid id)
    {
        try
        {
            var order = _provider.GetInfo(id);

            if (order is null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            _manager.Delete(id);

            return Ok($"Order with ID {id} deleted successfully.");
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }
}