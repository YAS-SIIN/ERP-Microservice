namespace ERP.Core.Messages;

public interface IMessage<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
}
