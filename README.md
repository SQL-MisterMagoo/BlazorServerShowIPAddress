
## Getting Client IP Address in Blazor

This solution demonstrates two ways to get the client IP Address and display it in Blazor components:

1. **Using `IHttpContextAccessor` in `App.razor`**:
   - The `IHttpContextAccessor` is injected into the `App.razor` component to access the client's IP address directly from the HTTP context.
   - The IP address is then passed to the `Routes` component as a parameter and then shared via a CascadingValue to all children.

2. **Using a Custom `ICircuitHandler` and `AppState` Service**:
   - A custom `ICircuitHandler` implementation (`CustomCircuitHandler`) is created to handle circuit connections and disconnections.
   - The `CustomCircuitHandler` uses `IHttpContextAccessor` to get the client's IP address and stores it in a scoped `AppState` service along with the circuit ID.
   - The `Home.razor` component injects the `AppState` service and retrieves the IP address and circuit ID to display them on the screen.
   - This will only work if web sockets are enabled.
	
[Sample](https://blazorip-bah4f8e7avdpfycs.northeurope-01.azurewebsites.net/) published on Azure Web app (free tier)

