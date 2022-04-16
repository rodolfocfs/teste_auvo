namespace ClimaTempoSimples.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClimaTempoSimples.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<ClimaTempoSimples.DAL.ClimaTempoSimplesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ClimaTempoSimples.DAL.ClimaTempoSimplesContext context)
        {
            var estados = new List<Estado>
            {
                new Estado { UF = "GO",   Nome = "Goiás",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Goiânia", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "SP",   Nome = "São Paulo",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "São Paulo", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "AC",   Nome = "Acre",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Rio Branco", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "AL",   Nome = "Alagoas",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Maceió", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "AP",   Nome = "Amapá" },

                new Estado { UF = "AM",   Nome = "Amazonas",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Manaus", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "BA",   Nome = "Bahia",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Salvador", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "CE",   Nome = "Ceará",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Fortaleza", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "DF",   Nome = "Distrito Federal",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Brasília", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "ES",   Nome = "Espirito Santo",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Vitória", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "MA",   Nome = "Maranhão",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "São Luis", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "MT",   Nome = "Mato Grosso",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Cuiabá", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "MS",   Nome = "Mato Grosso do Sul",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Campo Grande", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "MG",   Nome = "Minas Gerais",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Belo Horizonte", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "PA",   Nome = "Pará",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Belém", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },
                new Estado { UF = "PB",   Nome = "Paraíba" },

                new Estado { UF = "PR",   Nome = "Paraná" },

                new Estado { UF = "PE",   Nome = "Pernambuco" },

                new Estado { UF = "PI",   Nome = "Piauí" },

                new Estado { UF = "RJ",   Nome = "Rio de Janeiro",
                    Cidades = new List<Cidade>{
                        new Cidade {Nome = "Rio de Janeiro", Previsoes = GerarPrevisoesAleatorias()}
                    }
                },

                new Estado { UF = "RN",   Nome = "Rio Grande do Norte" },

                new Estado { UF = "RS",   Nome = "Rio Grande do Sul" },

                new Estado { UF = "RO",   Nome = "Rondônia" },

                new Estado { UF = "RR",   Nome = "Roraima" },

                new Estado { UF = "SC",   Nome = "Santa Catarina" },

                new Estado { UF = "SE",   Nome = "Sergipe" },

                new Estado { UF = "TO",   Nome = "Tocantins" }

            };

            estados.ForEach(s => context.Estados.AddOrUpdate(p => p.UF, s));
            context.SaveChanges();

        }

        private List<PrevisaoClima> GerarPrevisoesAleatorias()
        {
            int quantidade = 10;
            List<PrevisaoClima> retorno = new List<PrevisaoClima>();

            string[] climas = new string[5] { EnumClima.Chuvoso, EnumClima.Ensoladado, EnumClima.Nevoeiro, EnumClima.Nublado, EnumClima.ParcialmanteNublado };

            for (int i = 0; i < quantidade; i++)
            {
                Random numeroAleatorio = new Random();
                decimal temperaturaMinima = numeroAleatorio.Next(20, 45) + (decimal)numeroAleatorio.NextDouble();
                decimal temperaturaMaxima = numeroAleatorio.Next(-10, 19) + (decimal)numeroAleatorio.NextDouble();

                var previsao = new PrevisaoClima
                {
                    Clima = climas[numeroAleatorio.Next(0, 4)],
                    TemperaturaMaxima = temperaturaMinima,
                    TemperaturaMinima = temperaturaMaxima,
                    DataPrevisao = DateTime.Now.AddDays(i)
                };

                retorno.Add(previsao);
            }

            return retorno;

        }

    }
}
