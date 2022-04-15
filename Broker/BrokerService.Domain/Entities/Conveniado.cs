using BrokerService.Domain.helper;

namespace BrokerService.Domain.Entities
{
    public class Conveniado : Entity
    {
        public Guid PlanoId { get; set; }
        public Guid UsuarioId { get; set; }

        /* EF */
        public virtual Usuario Usuario { get; set; }
        public virtual Plano Plano { get; set; }
        public Conveniado()
        {

        }
        public Conveniado(Guid id, Guid usuarioId, Guid planoId)
        {

            if (id == Guid.Empty)
                id = Guid.NewGuid();
            else
                DataAlteracao = DateTime.Now;

            Id = id;
            PlanoId = planoId;
            UsuarioId = usuarioId;
        }

    }
}