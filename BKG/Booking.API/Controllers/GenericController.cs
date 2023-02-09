using AutoMapper;
using Booking.BLL.Abstractions;
using Booking.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenericController<TModel, TViewModel> : ControllerBase
    where TModel : BaseModel
    where TViewModel : class
{
    protected IGenericService<TModel> GenericService;
    protected IMapper Mapper;

    public GenericController(IGenericService<TModel> genericService,
        IMapper mapper)
    {
        GenericService = genericService;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var models = await GenericService.GetAllAsync();

        return Ok(models);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var model = await GenericService.GetByIdAsync(id);
        var viewModel = Mapper.Map<TModel, TViewModel>(model);

        return Ok(viewModel);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(TViewModel viewModel)
    {
        var model = Mapper.Map<TViewModel, TModel>(viewModel);
        await GenericService.AddAsync(model);

        return Ok(viewModel);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(Guid id, TViewModel viewModel)
    {
        var model = Mapper.Map<TViewModel, TModel>(viewModel);
        model.Id = id;
        await GenericService.UpdateAsync(model);

        return Ok(viewModel);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await GenericService.DeleteAsync(id);

        return Ok();
    }
}