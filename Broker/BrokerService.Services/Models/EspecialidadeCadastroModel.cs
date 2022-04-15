namespace BrokerService.Services.Models
{
    public class EspecialidadeCadastroModel
    {
        public string Descricao { get; set; }
        public EspecialidadeCadastroModel()
        {

        }
        public EspecialidadeCadastroModel(string descricao)
        {
            Descricao = descricao;
        }
    }
}
