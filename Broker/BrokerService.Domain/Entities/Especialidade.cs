using BrokerService.Domain.helper;

namespace BrokerService.Domain.Entities
{
    public class Especialidade : Entity
    {
        public string Descricao { get; set; }

        public Especialidade()
        {

        }
        public Especialidade(Guid id, string descricao)
        {
            if (id == Guid.Empty)
                id = Guid.NewGuid();
            else
                DataAlteracao = DateTime.Now;

            Id = id;
            Descricao = descricao;
        }
    }
}
