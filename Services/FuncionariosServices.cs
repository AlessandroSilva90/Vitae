using Core_Providentia_vitae.Models;
using Core_Providentia_vitae.Data;
using Microsoft.EntityFrameworkCore;
using Core_Providentia_vitae.DTO.Shared;
using Core_Providentia_vitae.Models.RH;
using Core_Providentia_vitae.DTO.RH;
using Core_Providentia_vitae.Data.RH;
using AutoMapper;

namespace Core_Providentia_vitae.Services;

public class FuncionariosService
{
    private readonly MssqlContext _context;
    private readonly RhContext _rhContext;
    private readonly IMapper _mapper;

    public FuncionariosService(MssqlContext context, RhContext rhcontext, IMapper mapper)
    {
        _context = context;
        _rhContext = rhcontext;
        _mapper = mapper;
    }

    // VERSÃO ANTIGA SEM DTO

    // public async Task<List<Epg>> GetFuncionariosAsync(int limite = 10)
    // {
    //     return await _context.Epg
    //         .OrderBy(e => e.Nome)
    //         .Take(limite)
    //         .ToListAsync();
    // }

    // RETORNAR FUNCIONARIOS COM DTO
    public async Task<List<GetFuncionariosDTO>> GetFuncionariosAsync01(int limite = 10)
    {
        var query = await _context.Epg
            .AsNoTracking()
            .Select(f => new
            {
                Funcionario = f,
                UltimaSep = f.Sep
                    .OrderByDescending(s => s.Data)
                    .FirstOrDefault()
            })
            .Select(x => new GetFuncionariosDTO
            {
                Id = x.Funcionario.Codigo,
                Nome = x.Funcionario.Nome,
                Setor = x.UltimaSep != null ? x.UltimaSep.Lot.Nome : "Sem Setor"
            })
            .OrderBy(e => e.Nome)
            .Take(limite)
            .ToListAsync();

        return query;
    }


    public async Task<(List<GetFuncionariosDTO> Funcionarios, int TotalCount, int TotalPages)> GetFuncionariosAsync(
    int page = 1,
    int pageSize = 10)
    {
        // CODIGO PARA UM FILTRO
        // if (!string.IsNullOrEmpty(codigoFiltro))
        // {
        //     // 👇 Completa com zeros à esquerda para ter 6 caracteres
        //     var codigoComZeros = codigoFiltro.PadLeft(6, '0');
        //     query = query.Where(ff => ff.Id == codigoComZeros);
        // }

        var query = _context.Epg
            .Where(f => f.Sep.Any(ff => ff.EstCodigo == "0001" && ff.EmpCodigo == "0003" && f.DtRescisao == null))
            .AsNoTracking()
            .Select(f => new GetFuncionariosDTO
            {
                Id = f.Codigo,
                Nome = f.Nome,
                Setor = f.Sep
                    .OrderByDescending(s => s.Data)
                    .Select(s => s.Lot.Nome)
                    .FirstOrDefault() ?? "Sem Setor"
            })
            .OrderBy(e => e.Nome);

        
        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        if (totalPages == 0) page = 0;
        else if (page < 1) page = 1;
        else if (page > totalPages) page = totalPages;

        var funcionarios = totalCount > 0
            ? await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync()
            : new List<GetFuncionariosDTO>();

        return (funcionarios, totalCount, totalPages);
    }

    public async Task<GetFuncionariosDTO?> GetFuncionariosCrachaAsync(string cracha)
    {
        if (string.IsNullOrEmpty(cracha))
            return null;


        var codigoComZeros = cracha.PadLeft(6, '0');

        return await _context.Epg
            .Where(f => f.Codigo == codigoComZeros)
            .Select(f => new GetFuncionariosDTO
            {
                Id = f.Codigo,
                Nome = f.Nome,
                Setor = f.Sep
                    .OrderByDescending(s => s.Data)
                    .Select(s => s.Lot.Nome)
                    .FirstOrDefault() ?? "Sem Setor"
            })
            .FirstOrDefaultAsync();
    }



    // TROCA DE PLANTÃO DOS FUNCIONÁRIOS
    public async Task<TrocaPlantao> CreateTrocaPlantao(CreateTrocaPlantaoDTO trocaPlantaoDTO)
    {

        var plantao = new TrocaPlantao
        {
            CdSolicitante = trocaPlantaoDTO.Solicitante,
            CdSubstituto = trocaPlantaoDTO.Substituto,
            DtPlantaoOriginal = trocaPlantaoDTO.PlantaoOriginal,
            HrEntradaPlantaoOriginal = trocaPlantaoDTO.EntradaPlantaoOriginal,
            HrSaidaPlantaoOriginal = trocaPlantaoDTO.SaidaPlantaoOriginal,
            DtPlantaoTroca = trocaPlantaoDTO.PlantaoTroca,
            HrEntradaPlantaoTroca = trocaPlantaoDTO.EntradaPlantaoTroca,
            HrSaidaPlantaoTroca = trocaPlantaoDTO.SaidaPlantaoTroca,
            MotivoTroca = trocaPlantaoDTO.MotivoTroca,
            SnAceito = trocaPlantaoDTO.Status,
        };

        _rhContext.TrocaPlantaos.Add(plantao);

        try
        {
            await _rhContext.SaveChangesAsync();
            return plantao;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            throw;
        }
    }


    public async Task<GetTrocaPlantoesDTO?> GetPlantaoById(int id)
    {
        var troca = await _rhContext.TrocaPlantaos
        .Where(t => t.Id == id)
        .Select(t => new GetTrocaPlantoesDTO
        {
            Id = t.Id,
            CdSolicitante = t.CdSolicitante,
            CdSubstituto = t.CdSubstituto,
            DtSolicitacao = t.DtPlantaoOriginal,
            DtSubstituicao = t.DtPlantaoTroca,
            EntradaPlantaoOriginal = t.HrEntradaPlantaoOriginal,
            SaidaPlantaoOriginal = t.HrSaidaPlantaoOriginal,
            EntradaPlantaoTroca = t.HrEntradaPlantaoTroca,
            SaidaPlantaoTroca = t.HrSaidaPlantaoTroca

        })
        .AsNoTracking()
        .FirstOrDefaultAsync();

        // 2. Verifica se encontrou a troca
        if (troca == null)
            return null; // Retorna null se não encontrou

        try
        {
            // 3. Busca informações dos funcionários (em paralelo para performance)
            var solicitante = await GetFuncionariosCrachaAsync(troca.CdSolicitante.ToString());
            var substituto = await GetFuncionariosCrachaAsync(troca.CdSubstituto.ToString());

            // Console.WriteLine($"Solicitante: {solicitante?.Nome}");
            // Console.WriteLine($"Substituto: {substituto?.Nome}");

            // 4. Adiciona informações ao DTO
            troca.NomeSolicitante = solicitante?.Nome ?? "Não encontrado";
            troca.SetorSolicitante = solicitante?.Setor ?? "Sem setor";

            troca.NomeSubstituto = substituto?.Nome ?? "Não encontrado";
            troca.SetorSubstituto = substituto?.Setor ?? "Sem setor";
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            // Define valores padrão para não quebrar
            troca.NomeSolicitante = "Erro ao buscar";
            troca.NomeSubstituto = "Erro ao buscar";
        }

        return troca;
    }


    public async Task<TrocaPlantao> UpdateTrocaPlantaoAsync(int id, UpdateTrocaPlantaoDTO dto)
    {
        var troca = await _rhContext.TrocaPlantaos.FindAsync(id);
        if (troca == null) throw new Exception("Troca não encontrada");

        // Atualiza somente os campos que foram enviados
        if (dto.CdSolicitante.HasValue && dto.CdSolicitante.Value >= 0)
            troca.CdSolicitante = dto.CdSolicitante.Value;

        if (dto.CdSubstituto.HasValue && dto.CdSubstituto.Value >= 0)
            troca.CdSubstituto = dto.CdSubstituto.Value;

        if (dto.DtPlantaoOriginal.HasValue)
            troca.DtPlantaoOriginal = dto.DtPlantaoOriginal.Value;

        if (dto.HrEntradaPlantaoOriginal.HasValue)
            troca.HrEntradaPlantaoOriginal = dto.HrEntradaPlantaoOriginal.Value;

        if (dto.HrSaidaPlantaoOriginal.HasValue)
            troca.HrSaidaPlantaoOriginal = dto.HrSaidaPlantaoOriginal.Value;

        if (dto.DtPlantaoTroca.HasValue)
            troca.DtPlantaoTroca = dto.DtPlantaoTroca.Value;

        if (dto.HrEntradaPlantaoTroca.HasValue)
            troca.HrEntradaPlantaoTroca = dto.HrEntradaPlantaoTroca.Value;

        if (dto.HrSaidaPlantaoTroca.HasValue)
            troca.HrSaidaPlantaoTroca = dto.HrSaidaPlantaoTroca.Value;

        if (!string.IsNullOrWhiteSpace(dto.MotivoTroca))
            troca.MotivoTroca = dto.MotivoTroca;

        if (!string.IsNullOrWhiteSpace(dto.SnAceito))
            troca.SnAceito = dto.SnAceito;


        await _rhContext.SaveChangesAsync();
        return troca;
    }




}