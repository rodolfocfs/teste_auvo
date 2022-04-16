using ClimaTempoSimples.Model;
using System.Collections.Generic;

namespace ClimaTempoSimples.Repositories
{
    public interface IClimaTempoRepository
    {
        List<PrevisaoClima> ListarCidadesMaisQuentes();
        List<PrevisaoClima> ListarCidadesMaisFrias();
        List<Cidade> ListarCidades();
        List<PrevisaoClima> ListarPrevisoesPorCidade(int cidadeId);
    }
}