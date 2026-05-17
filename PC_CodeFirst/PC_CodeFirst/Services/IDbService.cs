using PC_CodeFirst.DTOs;

namespace PC_CodeFirst.Services;

public interface IDbService
{
    Task<IEnumerable<GetAllComputersDto>> GetAllComputersAsync();
    Task<GetCompByPcIdDto> GetCompByPcIdAsync(int pcId);
    Task<CreateNewComputerResponseDto> CreateNewComputerAsync(CreateNewComputerDto dto);
    Task UpdateComputerAsync(int id, UpdateComputerByIdDto dto);
    Task DeleteComputerAsync(int id);
}