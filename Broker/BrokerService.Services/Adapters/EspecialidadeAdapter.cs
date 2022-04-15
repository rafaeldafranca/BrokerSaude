using BrokerService.Domain.Entities;
using BrokerService.Services.Models;


namespace BrokerService.Services.Adapters
{
    public static class EspecialidadeAdapter
    {
        public static Especialidade Adapter(this EspecialidadeModel data)
        {
            if (data == null) return null;

            return new Especialidade(data.Id, data.Descricao);
        }

        public static EspecialidadeModel Adapter(this Especialidade data)
        {
            if (data == null) return null;

            var result = new EspecialidadeModel()
            {
                Id = data.Id,
                Descricao = data.Descricao
            };

            return result;
        }

        public static EspecialidadeModel Adapter(this EspecialidadeCadastroModel data)
        {
            if (data == null) return null;

            var result = new EspecialidadeModel()
            {
                Descricao = data.Descricao
            };

            return result;
        }

        public static List<EspecialidadeModel> Adapter(this List<Especialidade> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }

        public static List<Especialidade> Adapter(this List<EspecialidadeModel> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }
    }
}
