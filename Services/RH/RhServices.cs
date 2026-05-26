using Core_Providentia_vitae.Data;
using Core_Providentia_vitae.Data.RH;
using Core_Providentia_vitae.DTO.RH;
using Core_Providentia_vitae.Models;
using Core_Providentia_vitae.Models.RH;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;


namespace Core_Providentia_vitae.Services.RH;


public class RhServices
{
    private readonly MssqlContext _context;
    private readonly RhContext _rhcontext;

    public RhServices(MssqlContext context, RhContext rhcontext)
    {
        _context = context;
        _rhcontext = rhcontext;
    }

    // public async Task<List<Car>> GetAllCargos()
    // {
    //     return await _context.Cargos.ToListAsync();
    // }

    public async Task<(List<Car> Cargos, int TotalCount, int TotalPages)> GetAllCargos(
    int page = 1,
    int pageSize = 10)
    {
        var totalCount = await _context.Cargos.CountAsync();

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);


        if (page < 1) page = 1;
        if (page > totalPages && totalPages > 0) page = totalPages;

        var skip = (page - 1) * pageSize;

        var cargos = await _context.Cargos
            .OrderBy(c => c.EmpCodigo)
            .ThenBy(c => c.Codigo)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        return (cargos, totalCount, totalPages);
    }

    public async Task<(List<Lot> Setor, int TotalCount, int TotalPages)> GetSetores(
    // string? codigo = null,
    string? nome = null,
    int page = 1,
    int pageSize = 10
    )
    {
        var query = _context.Setores.AsQueryable();

        // if (!string.IsNullOrEmpty(codigo))
        //     query = query.Where(x => NormalizarLot(x.Codigo) == NormalizarLot(codigo));

        if (!string.IsNullOrEmpty(nome))
            query = query.Where(x => x.Nome.Contains(nome));

        var totalCount = await query.CountAsync();

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        if (page < 1) page = 1;
        if (page > totalPages && totalPages > 0) page = totalPages;

        var skip = (page - 1) * pageSize;

        var setores = await query.Skip(skip)
            .Take(pageSize).ToListAsync();

        // var query = query.Where(u => u.Nome.Contains(termo));

        return (setores, totalCount, totalPages);
    }

    public async Task<bool> DeleteTrocaPlantao(int i)
    {
        var troca = await _rhcontext.TrocaPlantaos.FindAsync(i);

        if (troca == null)
        {
            return false;
        }

        _rhcontext.TrocaPlantaos.Remove(troca);

        await _rhcontext.SaveChangesAsync();
        return true;
    }


    // A PARTIR DAQUI É O VINCULO  DE COORDENADOR A SETOR E COORDENADOR A FUNCIONÁRIOS

    public async Task<List<CoordenadorSetor>> VincularCoordSetorAsync(CreateVinculoCoordenadorSetorDTO coord)
{
    var vinculos = new List<CoordenadorSetor>();
    
    foreach (var cdSetor in coord.CdSetor)
    {
        var vinculo = new CoordenadorSetor
        {
            CdCoordenador = coord.CdCoordenador,
            CdSetor = cdSetor
        };
        
        _rhcontext.CoordenadorSetors.Add(vinculo);
        vinculos.Add(vinculo);
    }
    
    try
    {
        await _rhcontext.SaveChangesAsync();
        return vinculos;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
        Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
        throw;
    }
}

    public async Task<GetVinculoCoordenadorSetorDTO?> GetCoordenadorSetorAsync(int crachaCoordenador)
    {
        var coordenador = await _rhcontext.CoordenadorSetors
        .Where(s => s.CdCoordenador == crachaCoordenador.ToString())
        .Select(s => new GetVinculoCoordenadorSetorDTO
        {
            Id = s.Id,
            CdCoordenador = s.CdCoordenador,
            CdSetor = s.CdSetor
        }).AsNoTracking()
        .FirstOrDefaultAsync();

        if (coordenador == null || string.IsNullOrEmpty(coordenador.CdSetor))
            return coordenador;

        var cdSetorNormalizado = coordenador.CdSetor.TrimStart('0');


        var setor = await _context.Setores
          .Where(i => i.Codigo != null &&
                   (EF.Functions.Like(i.Codigo, coordenador.CdSetor) ||
                    EF.Functions.Like(i.Codigo, cdSetorNormalizado) ||
                    EF.Functions.Like(i.Codigo, "%" + cdSetorNormalizado)))
        .Select(s => s.Nome)
        .FirstOrDefaultAsync();

        if (setor != null)
        {
            coordenador.NmSetor = setor;
        }

        if (coordenador == null || coordenador.CdCoordenador == null)
            return coordenador;

        var codigoComZeros = coordenador.CdCoordenador.ToString().PadLeft(6, '0');

        var nome = await _context.Epg
        .Where(n => n.Codigo == codigoComZeros)
        .Select(n => n.Nome)
        .FirstOrDefaultAsync();

        if (nome != null)
        {
            coordenador.NmCoordenador = nome;
        }

        return coordenador;

    }

    public async Task<bool> DeleteCoordenadorSetorAsync(int id)
    {
        var coordenador = await _rhcontext.CoordenadorSetors.FindAsync(id);

        if (coordenador == null)
        {
            return false;
        }

        _rhcontext.CoordenadorSetors.Remove(coordenador);

        await _rhcontext.SaveChangesAsync();
        return true;

    }

    private string NormalizarLot(string? codigo)
    {
        if (string.IsNullOrEmpty(codigo))
            return string.Empty;

        // Remove zeros à esquerda e espaços
        return codigo.Trim().TrimStart('0');
    }




}