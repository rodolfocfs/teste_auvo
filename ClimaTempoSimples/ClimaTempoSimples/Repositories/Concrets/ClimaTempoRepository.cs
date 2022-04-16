using ClimaTempoSimples.Model;
using System.Collections.Generic;
using ClimaTempoSimples.DAL;
using System.Linq;
using System;
using System.Data.Entity;

namespace ClimaTempoSimples.Repositories
{
    public class ClimaTempoRepository : IClimaTempoRepository
    {
        private readonly ClimaTempoSimplesContext _context = new ClimaTempoSimplesContext();

        public List<PrevisaoClima> ListarCidadesMaisQuentes()
        {
            var retorno = new List<PrevisaoClima>();
            var dataAtual = DateTime.Now.Date;

            var primeira = _context.Previsoes
                .Where(p => DbFunctions.TruncateTime(p.DataPrevisao) == dataAtual)
                .OrderByDescending(p => p.TemperaturaMaxima).FirstOrDefault();

            retorno.Add(primeira);

            var segunda = _context.Previsoes
                .Where(p => p.CidadeId != primeira.CidadeId)
                .Where(p => DbFunctions.TruncateTime(p.DataPrevisao) == dataAtual)
                .OrderByDescending(p => p.TemperaturaMaxima).FirstOrDefault();

            retorno.Add(segunda);

            var terceira = _context.Previsoes
                .Where(p => p.CidadeId != primeira.CidadeId && p.CidadeId != segunda.CidadeId)
                .Where(p => DbFunctions.TruncateTime(p.DataPrevisao) == dataAtual)
                .OrderByDescending(p => p.TemperaturaMaxima).FirstOrDefault();

            retorno.Add(terceira);

            return retorno;

        }
        public List<PrevisaoClima> ListarCidadesMaisFrias()
        {
            var retorno = new List<PrevisaoClima>();
            var dataAtual = DateTime.Now.Date;

            var primeira = _context.Previsoes.OrderBy(p => p.TemperaturaMinima)
                .Where(p => DbFunctions.TruncateTime(p.DataPrevisao) == dataAtual)
                .FirstOrDefault();

            retorno.Add(primeira);

            var segunda = _context.Previsoes
                .Where(p => p.CidadeId != primeira.CidadeId)
                .Where(p => DbFunctions.TruncateTime(p.DataPrevisao) == dataAtual)
                .OrderBy(p => p.TemperaturaMinima).FirstOrDefault();

            retorno.Add(segunda);

            var terceira = _context.Previsoes
                .Where(p => p.CidadeId != primeira.CidadeId && p.CidadeId != segunda.CidadeId)
                .Where(p => DbFunctions.TruncateTime(p.DataPrevisao) == dataAtual)
                .OrderBy(p => p.TemperaturaMinima).FirstOrDefault();

            retorno.Add(terceira);

            return retorno;
        }

        public List<Cidade> ListarCidades()
            => _context.Cidades.OrderBy(c => c.Nome).ToList();

        public List<PrevisaoClima> ListarPrevisoesPorCidade(int cidadeId)
        {
            var dataSeteDias = DateTime.Now.Date.AddDays(7);
            var dataAtual = DateTime.Now.Date;

            return _context.Previsoes
                .Where(p => p.CidadeId == cidadeId)
                .Where(p => DbFunctions.TruncateTime(p.DataPrevisao) < dataSeteDias && DbFunctions.TruncateTime(p.DataPrevisao) >= dataAtual)
                .OrderBy(p => p.DataPrevisao).ToList();
        }

    }
}