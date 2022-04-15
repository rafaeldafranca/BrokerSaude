namespace BrokerService.Domain.Emuns
{
    public static class EntityEnums
    {
        public enum TipoUsuario
        {
            Todos = 0,
            Associado = 1,
            Conveniado = 2,
            Prestador = 3
        }
        public enum StatusManifestacao
        {
            Aberto = 1,
            Fechado = 2,
            Andamento = 3
        }
        public enum RemessaStatus
        {
            Disponivel,
            Processamento,
            Entregue
        }
        public enum PedidoStatus
        {
            Cancelado,
            Aberto,
            Fechado,
            Processamento
        }
        public enum RemessaDistribuicaoStatus
        {
            Aberto,
            Fechado
        }

    }
}
