using Microsoft.EntityFrameworkCore;
using PC_CodeFirst.Data;
using PC_CodeFirst.DTOs;
using PC_CodeFirst.Entities;
using PC_CodeFirst.Exceptions;

namespace PC_CodeFirst.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetAllComputersDto>> GetAllComputersAsync()
    {
        var result = await _dbContext.Pcs
            .Select(x => new GetAllComputersDto
            {
                Id = x.Id,
                Name = x.Name,
                Weight = x.Weight,
                Warranty = x.Warranty,
                CreatedAt = x.CreatedAt,
                Stock = x.Stock
            }).ToListAsync();

        return result;
    }

    public async Task<GetCompByPcIdDto> GetCompByPcIdAsync(int pcId)
    {
        var result = await _dbContext.Pcs
            .Where(x => x.Id == pcId)
            .Select(x => new GetCompByPcIdDto
            {
                Id = x.Id,
                Name = x.Name,
                Weight = x.Weight,
                Warranty = x.Warranty,
                CreatedAt = x.CreatedAt,
                Stock = x.Stock,
                Components = x.PcComponents
                    .Select(xc => new GetComponentListDetailsDto
                    {
                        Amount = xc.Amount,
                        Component = new GetComponentDetailsDto
                        {
                            Code = xc.Component.Code,
                            Name = xc.Component.Name,
                            Description = xc.Component.Description,
                            Manufacturer = new GetManufacturerDetailsDto
                            {
                                Id = xc.Component.ComponentManufacturer.Id,
                                Abbreviation = xc.Component.ComponentManufacturer.Abbreviation,
                                FullName = xc.Component.ComponentManufacturer.FullName,
                                FoundationDate = xc.Component.ComponentManufacturer.FoundationDate
                            },
                            Type = new GetTypeDetailsDto
                            {
                                Id = xc.Component.ComponentType.Id,
                                Abbreviation = xc.Component.ComponentType.Abbreviation,
                                Name = xc.Component.ComponentType.Name
                            }
                        }
                    }).ToList()
            }).FirstOrDefaultAsync();

        if (result == null)
        {
            throw new NotFoundException("Nie znaleziono komputera o podanym ID");
        }

        return result;
    }

    public async Task<CreateNewComputerResponseDto> CreateNewComputerAsync(CreateNewComputerDto dto)
    {
        var create = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        await _dbContext.AddAsync(create);
        await _dbContext.SaveChangesAsync();

        var result = new CreateNewComputerResponseDto
        {
            Id = create.Id,
            Name = create.Name,
            Weight = create.Weight,
            Warranty = create.Warranty,
            CreatedAt = create.CreatedAt,
            Stock = create.Stock
        };

        return result;
    }

    public async Task UpdateComputerAsync(int id, UpdateComputerByIdDto dto)
    {
        var result = await _dbContext.Pcs.FirstOrDefaultAsync(x => x.Id == id);

        if (result == null)
        {
            throw new NotFoundException("Nie znaleziono komputera o podanym ID");
        }

        result.Name = dto.Name;
        result.Weight = dto.Weight;
        result.Warranty = dto.Warranty;
        result.CreatedAt = dto.CreatedAt;
        result.Stock = dto.Stock;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteComputerAsync(int id)
    {
        // var result = await _dbContext.Pcs.FirstOrDefaultAsync(x => x.Id == id);
        //
        // if (result == null)
        // {
        //     throw new NotFoundException("Nie znaleziono komputera o podanym ID");
        // }
        //
        // _dbContext.Pcs.Remove(result);
        // await _dbContext.SaveChangesAsync();

        // lub 

        var rowsDeleted = await _dbContext.Pcs.Where(x => x.Id == id).ExecuteDeleteAsync();

        if (rowsDeleted == 0)
        {
            throw new NotFoundException("Nie znaleziono komputera o podanym ID");
        }
    }
}