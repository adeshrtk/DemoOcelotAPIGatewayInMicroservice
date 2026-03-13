# Demo Ocelot API Gateway in Microservice Solution

Overview
- This solution demonstrates a simple microservice setup with an API Gateway implemented using Ocelot.
- Projects:
  - `Gateway` — API Gateway (Ocelot) that routes requests to downstream services.
  - `Identity` — Minimal service exposing a `GET /api/user` endpoint.
  - `Weather` — Minimal service exposing a `GET /api/weatherforecast` endpoint.
- Target framework: .NET 10.

Project ports (launch settings)
- Gateway
  - HTTP: `http://localhost:5182`
  - HTTPS: `https://localhost:7000`
- Identity
  - HTTP: `http://localhost:7001`
  - HTTPS: `https://localhost:7283`
- Weather
  - HTTP: `http://localhost:7002`
  - HTTPS: `https://localhost:7165`

Routing (configured in `Gateway/ocelot.json`)
- Upstream `GET|POST|PUT|DELETE|OPTIONS /api/user` -> Downstream `http://localhost:7001/api/user`
- Upstream `GET|POST|PUT|DELETE|OPTIONS /api/weatherforecast` -> Downstream `http://localhost:7002/api/weatherforecast`
- Global configuration sets `BaseUrl` to the gateway HTTPS address `https://localhost:7000`.

How to run
- In Visual Studio (recommended):
  1. Open the solution in Visual Studio.
  2. Set multiple startup projects (Gateway, Identity, Weather) or start them individually.
  3. Run the solution. Each service will start on the ports listed above (see launch settings).

- From the command line:
  - Start each project folder with `dotnet run` (ensure you choose the correct profile or URL if needed).

Test the gateway
- Use the gateway to call downstream services (recommended to use the gateway's HTTPS URL):
  - Get users: `curl -k https://localhost:7000/api/user`
  - Get weather forecasts: `curl -k https://localhost:7000/api/weatherforecast`
- The gateway will forward requests to the appropriate downstream service based on `ocelot.json`.

Notes
- If you change `Gateway/ocelot.json`, restart the Gateway project to pick up changes.
- For development TLS with self-signed certificates, `-k` is used in `curl` to ignore certificate verification.
- To extend routing (path templates, authentication, headers, load balancing, etc.), modify `ocelot.json` and add required packages/configuration in `Gateway`.

Contact / Next steps
- To add authentication or secure routes, integrate Identity tokens and configure Ocelot authentication options in the `Gateway` project.
