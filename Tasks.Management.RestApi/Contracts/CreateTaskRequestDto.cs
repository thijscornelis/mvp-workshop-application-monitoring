using Tasks.Management.Contracts;

namespace Tasks.Management.RestApi.Contracts;

public record CreateTaskRequestDto(Guid ProjectId, string Name)
{
    public static implicit operator CreateTaskRequest(CreateTaskRequestDto dto)
    {
        return new CreateTaskRequest(dto.ProjectId, dto.Name);
    }
}