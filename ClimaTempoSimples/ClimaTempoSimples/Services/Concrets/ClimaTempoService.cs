using ClimaTempoSimples.Model;
using ClimaTempoSimples.ViewModel;
using System.Collections.Generic;
using ClimaTempoSimples.Repositories;

namespace ClimaTempoSimples.Services
{
    public class ClimaTempoService : IClimaTempoService
    {
        private readonly IClimaTempoRepository _climaTempoRepository = new ClimaTempoRepository();

        public List<PrevisaoClima> ListarCidadesMaisQuentes()
        {
            return _climaTempoRepository.ListarCidadesMaisQuentes();
        }
        public List<PrevisaoClima> ListarCidadesMaisFrias()
        {
            return _climaTempoRepository.ListarCidadesMaisFrias();
        }

        public List<Cidade> ListarCidades()
        {
            return _climaTempoRepository.ListarCidades();
        }

        public List<PrevisaoViewModel> ListarPrevisoesPorCidade(int cidadeId)
        {
            var previsoes = _climaTempoRepository.ListarPrevisoesPorCidade(cidadeId);
            var retorno = new List<PrevisaoViewModel>();

            foreach (var previsao in previsoes)
            {
                var previsaoView = new PrevisaoViewModel()
                {
                    TemperaturaMaxima = previsao.TemperaturaMaxima,
                    TemperaturaMinima = previsao.TemperaturaMinima,
                    DiaPrevisao = BuscarDiaDaSemana((int)previsao.DataPrevisao.DayOfWeek),
                    Clima = previsao.Clima
                };

                retorno.Add(previsaoView);
            }

            return retorno;
        }

        private string BuscarDiaDaSemana(int dia)
        {
            switch (dia)
            {
                case 0:
                    return "Domingo";
                case 1:
                    return "Segunda";
                case 2:
                    return "Terça";
                case 3:
                    return "Quarta";
                case 4:
                    return "Quinta";
                case 5:
                    return "Sexta";
                case 6:
                    return "Sábado";
                default:
                    return "";
            }
        }
    }
}