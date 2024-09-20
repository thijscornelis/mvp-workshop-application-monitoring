using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common;
using Tasks.Management.Design;
using Tasks.Management.RestApi.Contracts;

namespace Tasks.Management.RestApi;

[ApiController]
[Route("/api/tasks")]
public class TasksController(ITaskManagementFacade facade, IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpGet]
    [Route("{id:guid}", Name = "GetById")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await facade.FindTaskByIdAsync(id, cancellationToken);
        return response is null ? NotFound() : Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTaskRequestDto requestDto, CancellationToken cancellationToken)
    {
        await unitOfWork.StartAsync(cancellationToken);
        var response = await facade.CreateTaskAsync(requestDto, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken); 
        return Created($"/api/tasks/{response.Id}", response);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await unitOfWork.StartAsync(cancellationToken);
        await facade.DeleteTaskAsync(id, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return NoContent();
    }
}