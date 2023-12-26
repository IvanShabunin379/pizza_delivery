using AutoMapper;

using PizzaDelivery.BL;
using PizzaDelivery.BL.Pizzas.Entities;

using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.WebAPI.Controllers.Entities.Pizzas;
namespace Service.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzasController(IProvider<PizzaModel, PizzasModelFilter> provider, IManager<PizzaModel, CreatePizzaModel> manager, IMapper mapper, ILogger logger) : ControllerBase
{
    private readonly IProvider<PizzaModel, PizzasModelFilter> _provider = provider;
    private readonly IManager<PizzaModel, CreatePizzaModel> _manager = manager;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger _logger = logger;

    [HttpGet]
    public IActionResult GetAllPizzas()
    {
        var pizzas = _provider.Get();

        return Ok(new PizzasListResponse()
        {
            Pizzas = pizzas.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredPizzas([FromQuery] PizzasFilter filter)
    {
        var pizzas = _provider.Get(_mapper.Map<PizzasModelFilter>(filter));

        return Ok(new PizzasListResponse()
        {
            Pizzas = pizzas.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetPizzaInfo([FromRoute] Guid id)
    {
        try
        {
            var pizza = _provider.GetInfo(id);

            return Ok(pizza);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreatePizza([FromBody] CreatePizzaRequest request)
    {
        try
        {
            var pizza = _manager.Create(_mapper.Map<CreatePizzaModel>(request));

            return Ok(pizza);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdatePizzaInfo([FromRoute] Guid id, UpdatePizzaRequest request)
    {
        try
        {
            var pizza = _provider.GetInfo(id);

            if (pizza is null)
            {
                return NotFound($"Pizza with ID {id} not found.");
            }

            _mapper.Map(request, pizza);

            var updatedPizza = _manager.Update(id, pizza);

            return Ok(updatedPizza);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeletePizza([FromRoute] Guid id)
    {
        try
        {
            var pizza = _provider.GetInfo(id);

            if (pizza is null)
            {
                return NotFound($"Pizza with ID {id} not found.");
            }

            _manager.Delete(id);

            return Ok($"Pizza with ID {id} deleted successfully.");
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());

            return BadRequest(ex.Message);
        }
    }
}