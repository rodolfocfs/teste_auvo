using ClimaTempoSimples.Model;
using System.Collections.Generic;
using ClimaTempoSimples.ViewModel;

namespace ClimaTempoSimples.Services
{
    public interface IClimaTempoService
    {
        List<PrevisaoClima> ListarCidadesMaisQuentes();
        List<PrevisaoClima> ListarCidadesMaisFrias();
        List<Cidade> ListarCidades();
        List<PrevisaoViewModel> ListarPrevisoesPorCidade(int cidadeId);
    }
}