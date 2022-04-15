namespace BrokerService.Services.Models
{
    public class EspecialidadeModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public EspecialidadeModel()
        {

        }
        public EspecialidadeModel(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }
    }
}
