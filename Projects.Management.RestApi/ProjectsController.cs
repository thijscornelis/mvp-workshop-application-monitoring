using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common;
using Projects.Management.Design;
using Projects.Management.RestApi.Contracts;

namespace Projects.Management.RestApi;

[ApiController]
[Route("/api/projects")]
public class ProjectsController(IProjectManagementFacade facade, IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpGet]
    [Route("{id:guid}", Name = "GetProjectById")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var project = await facade.FindProjectByIdAsync(id, cancellationToken);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProjectRequestDto requestDto, CancellationToken cancellationToken)
    {
        await unitOfWork.StartAsync(cancellationToken);
        var response = await facade.CreateProjectAsync(requestDto, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return Created($"/api/projects/{response.Id}", response);
        
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await unitOfWork.StartAsync(cancellationToken);
        await facade.DeleteProjectAsync(id, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return NoContent();
    }
}