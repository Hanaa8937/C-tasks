using System;
using System.Collections.Generic;

List<IMiddleware> pipeline = new List<IMiddleware>
{
    new LoggingMiddleware(),
    new CorsMiddleware(),
    new LanguageMiddleware(),
    new AuthMiddleware()
};

Router router = new Router();

Console.WriteLine("=== MINI HTTP SERVER ===");
Console.Write("Enter method (GET/POST/PUT/DELETE): ");
string method = (Console.ReadLine() ?? "GET").ToUpper();

Console.Write("Enter path: ");
string path = Console.ReadLine() ?? "";

Console.Write("Query params (e.g. ?lang=en) or blank: ");
string queryString = Console.ReadLine() ?? "";

Console.Write("Token (leave blank or enter one): ");
string token = Console.ReadLine() ?? "";

HttpRequest request = new HttpRequest
{
    Method = method,
    Path = path
};

// Parse query string like "?lang=en&brand=BMW" into the dictionary
if (queryString.StartsWith("?"))
{
    queryString = queryString.Substring(1);
}
foreach (string pair in queryString.Split('&', StringSplitOptions.RemoveEmptyEntries))
{
    string[] parts = pair.Split('=');
    if (parts.Length == 2)
    {
        request.QueryParams[parts[0]] = parts[1];
    }
}

if (!string.IsNullOrEmpty(token))
{
    request.Headers["Authorization"] = $"Bearer {token}";
}

Console.WriteLine($"\n[REQUEST] {request.Method} {request.Path}{(queryString.Length > 0 ? "?" + queryString : "")}");

HttpResponse response = new HttpResponse();
bool continuePipeline = true;

foreach (IMiddleware middleware in pipeline)
{
    continuePipeline = middleware.Handle(request, response);
    if (!continuePipeline)
    {
        break; // AuthMiddleware said stop
    }
}

if (continuePipeline)
{
    response = router.Route(request);
}

Console.WriteLine($"\n[RESPONSE] {response.StatusCode}");
Console.WriteLine(response.Body);