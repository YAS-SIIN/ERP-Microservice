namespace ERP.Infra.Messaging
{
    public interface IBus
    {
        void Publish(string message);
    }

}