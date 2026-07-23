using System.Collections.Generic;

public class HttpRequest
{
    public string Method = "";
    public string Path = "";
    public Dictionary<string, string> QueryParams = new Dictionary<string, string>();
    public string Body = "";
    public Dictionary<string, string> Headers = new Dictionary<string, string>();
    public string Language = "en"; // filled in by LanguageMiddleware
}

public class HttpResponse
{
    public int StatusCode = 200;
    public string Body = "";
    public Dictionary<string, string> Headers = new Dictionary<string, string>();
}