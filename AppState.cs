public class AppState
{
    private readonly Dictionary<string, string> _ipAddresses = new();

    public void SaveIPAddress(string circuitId, string ipAddress)
    {
        _ipAddresses[circuitId] = ipAddress;
    }

    public string GetIPAddress(string circuitId)
    {
        return _ipAddresses.TryGetValue(circuitId, out var ipAddress) ? ipAddress : null;
    }
    public (string circuitId,string ipAddress)? GetIPAddress()
    {
      if (_ipAddresses.Count == 0)
        return null;

    return (_ipAddresses.Keys.First(), _ipAddresses.Values.First());
    }
}
