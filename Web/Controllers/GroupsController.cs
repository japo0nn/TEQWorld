using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/groups")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly IGroupRepository _repository;

    public GroupsController(IGroupRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("get-all")]
    public async Task<Result<List<ItemsGroup>>> GetAllGroups()
    {
        var groups = await _repository.GetAllAsync();

        return Result<List<ItemsGroup>>.Success(groups);
    }

    [HttpGet("{id}")]
    public async Task<Result<ItemsGroup>> GetById(Guid id)
    {
        var group = await _repository.GetByIdAsync(id);

        if (group == null)
            return Result<ItemsGroup>.Failure(["Группа с указанным идентификатором не найдена"]);

        return Result<ItemsGroup>.Success(group);
    }
}
