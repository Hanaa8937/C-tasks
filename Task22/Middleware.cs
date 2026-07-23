using System;

public interface IMiddleware
{
    // Returns true if the pipeline should continue, false if it should stop here
    bool Handle(HttpRequest request, HttpResponse response);
}

public class LoggingMiddleware : IMiddleware
{
    public bool Handle(HttpRequest request, HttpResponse response)
    {
        Console.WriteLine($"[LOG] LoggingMiddleware → [{DateTime.Now:HH:mm:ss}] {request.Method} {request.Path}");
        return true;
    }
}

public class CorsMiddleware : IMiddleware
{
    public bool Handle(HttpRequest request, HttpResponse response)
    {
        response.Headers["Access-Control-Allow-Origin"] = "*";
        Console.WriteLine("[CORS] CorsMiddleware → Headers added");
        return true;
    }
}

public class LanguageMiddleware : IMiddleware
{
    public bool Handle(HttpRequest request, HttpResponse response)
    {
        if (request.QueryParams.ContainsKey("lang"))
        {
            request.Language = request.QueryParams["lang"];
        }
        Console.WriteLine($"[LANG] LanguageMiddleware → Language: {request.Language}");
        return true;
    }
}

public class AuthMiddleware : IMiddleware
{
    private static readonly string[] ProtectedMethods = { "POST", "PUT", "DELETE" };

    public bool Handle(HttpRequest request, HttpResponse response)
    {
        bool needsAuth = Array.Exists(ProtectedMethods, m => m == request.Method);
        if (!needsAuth)
        {
            return true;
        }

        if (!request.Headers.ContainsKey("Authorization") || string.IsNullOrEmpty(request.Headers["Authorization"]))
        {
            Console.WriteLine("[AUTH] AuthMiddleware → No token found!");
            response.StatusCode = 401;
            response.Body = "{ \"error\": \"You must be logged in to access this endpoint\" }";
            return false; // stop the pipeline here
        }

        Console.WriteLine("[AUTH] AuthMiddleware → Token OK");
        return true;
    }
}