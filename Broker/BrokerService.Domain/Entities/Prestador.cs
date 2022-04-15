using BrokerService.Domain.helper;

namespace BrokerService.Domain.Entities
{
    public class Prestador : Entity
    {
        public string Conselho { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid EspecialidadeId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Especialidade Especialidade { get; set; }

        public Prestador()
        {

        }

        public Prestador(Guid id, Guid usuarioId, string conselho, Guid especialidadeId)
        {

            if (id == Guid.Empty)
                id = Guid.NewGuid();
            else
                DataAlteracao = DateTime.Now;



            Id = id;
            Conselho = conselho;
            UsuarioId = usuarioId;
            EspecialidadeId = especialidadeId;
        }

    }
}
