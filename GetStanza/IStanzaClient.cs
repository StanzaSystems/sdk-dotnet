namespace GetStanza;

public interface IStanzaClient
{
    IGuard GetGuard(string guardName, GuardOptions? options);
}
