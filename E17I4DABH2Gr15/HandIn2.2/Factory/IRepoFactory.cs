using HandIn2._2.Repositories;

namespace HandIn2._2.Factory
{
    public interface IRepoFactory
    {
        IContactRepo ContactRepo { get; }
        IAddressRepo AddressRepo { get; }
    }
}