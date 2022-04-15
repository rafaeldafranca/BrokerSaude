using BrokerService.Domain.Entities;
using BrokerService.Domain.helper;
using BrokerService.Services.Models;


namespace BrokerService.Services.Adapters
{
    public static class PlanoAdapter
    {
        public static Plano Adapter(this PlanoModel data)
        {
            if (data == null) return null;

            return new Plano(data.Id, data.Produto, data.Descricao, data.Codigo, data.Cns, data.Cobertura, data.Acomodacao);
        }

        public static PlanoModel Adapter(this Plano data)
        {
            if (data == null) return null;

            var result = new PlanoModel()
            {
                Acomodacao = data.Acomodacao,
                Codigo = data.Codigo,
                Cobertura = data.Cobertura,
                Cns = data.Cns,
                Descricao = data.Descricao,
                Produto = data.Produto,
                Id = data.Id
            };

            return result;
        }

        public static PlanoModel Adapter(this PlanoCadastroModel data)
        {
            if (data == null) return null;

            var result = new PlanoModel()
            {
                Acomodacao = data.Acomodacao,
                Codigo = data.Codigo,
                Cobertura = data.Cobertura,
                Cns = data.Cns,
                Descricao = data.Descricao,
                Produto = data.Produto,
                Id = Guid.NewGuid()
            };

            return result;
        }

        public static List<PlanoModel> Adapter(this List<Plano> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }

        public static List<Plano> Adapter(this List<PlanoModel> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }
    }
}
