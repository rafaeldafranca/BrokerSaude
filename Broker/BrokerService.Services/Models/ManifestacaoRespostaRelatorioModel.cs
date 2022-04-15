public class ManifestacaoRespostaRelatorioModel
{
    public string Descricao { get; set; }
    public string Autor { get; set; }
    public DateTime Data { get; set; }

    public ManifestacaoRespostaRelatorioModel()
    {

    }
    public ManifestacaoRespostaRelatorioModel(string descricao, string autor, DateTime data)
    {
        Descricao = descricao;
        Autor = autor;
        Data = data;
    }
}