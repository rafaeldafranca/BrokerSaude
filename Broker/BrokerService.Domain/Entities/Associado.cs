using BrokerService.Domain.helper;

namespace BrokerService.Domain.Entities
{
    public class Associado : Entity
    {
        public string Matricula { get; set; }
        public Guid UsuarioId { get; set; }

        /* EF */
        public virtual Usuario Usuario { get; set; }
        public Associado()
        {

        }

        public Associado(Guid id, Guid usuarioId, string matricula)
        {

            if (id == Guid.Empty)
                id = Guid.NewGuid();
            else
                DataAlteracao = DateTime.Now;

            Id = id;
            Matricula = matricula;
            UsuarioId = usuarioId;
        }
    }
}
