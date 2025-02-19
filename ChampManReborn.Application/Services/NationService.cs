using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class NationService(INationRepository nationRepository) : INationService
{
    public async Task<IEnumerable<Nation>> GetAllNationsAsync()
    {
        return await nationRepository.GetAllAsync();
    }

    public async Task<Nation> GetNationByIdAsync(Guid id)
    {
        return await nationRepository.GetByIdAsync(id);
    }

    public async Task AddNationAsync(Nation nation)
    {
        await nationRepository.AddAsync(nation);
    }

    public async Task UpdateNationAsync(Nation nation)
    {
        await nationRepository.UpdateAsync(nation);
    }

    public async Task DeleteNationAsync(Guid id)
    {
        var nation = await nationRepository.GetByIdAsync(id);
        if (nation != null)
        {
            await nationRepository.DeleteAsync(id);
        }
    }
}