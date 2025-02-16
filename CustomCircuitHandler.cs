using Microsoft.AspNetCore.Components.Server.Circuits;

public class CustomCircuitHandler : CircuitHandler
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly AppState _appState;
  private readonly ILogger<CustomCircuitHandler> _logger;

  public CustomCircuitHandler(IHttpContextAccessor httpContextAccessor, AppState appState, ILogger<CustomCircuitHandler> logger)
  {
    _httpContextAccessor = httpContextAccessor;
    _appState = appState;
    _logger = logger;
  }

  public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
    if (ipAddress != null)
    {
      _appState.SaveIPAddress(circuit.Id, ipAddress);
      _logger.LogInformation($"Circuit {circuit.Id} connected with IP {ipAddress}");
    }
    return Task.CompletedTask;
  }

  public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    _logger.LogInformation($"Circuit {circuit.Id} disconnected");
    return Task.CompletedTask;
  }
}
