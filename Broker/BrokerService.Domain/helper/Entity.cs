namespace BrokerService.Domain.helper;

public abstract class Entity
{
    protected string EntityName = string.Empty;

    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAlteracao { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.Now;
    }

}

