namespace GetStanza;

public interface IStanzaClient {
    Guard GetGuard(string guardName, GuardOptions? options);
}
