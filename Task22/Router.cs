using System;

public class Router
{
    public HttpResponse Route(HttpRequest request)
    {
        HttpResponse response = new HttpResponse();

        if (request.Path == "/api/vehicles" && request.Method == "GET")
        {
            response.StatusCode = 200;
            response.Body = "[ { \"id\": \"bmw-x5\", \"brand\": \"BMW\" }, { \"id\": \"mercedes-e200\", \"brand\": \"Mercedes\" } ]";
            Console.WriteLine("[ROUTE] VehicleController.GetAll()");
        }
        else if (request.Path.StartsWith("/api/vehicles/") && request.Method == "PUT")
        {
            string id = request.Path.Replace("/api/vehicles/", "");
            response.StatusCode = 200;
            response.Body = $"{{ \"message\": \"Vehicle {id} updated\" }}";
            Console.WriteLine($"[ROUTE] VehicleController.Update({id})");
        }
        else if (request.Path == "/api/leads" && request.Method == "GET")
        {
            response.StatusCode = 200;
            response.Body = "[ { \"id\": \"L-0001\", \"name\": \"Ahmet Yilmaz\" } ]";
            Console.WriteLine("[ROUTE] LeadController.GetAll()");
        }
        else if (request.Path == "/api/leads" && request.Method == "POST")
        {
            response.StatusCode = 201;
            response.Body = "{ \"message\": \"Lead created\" }";
            Console.WriteLine("[ROUTE] LeadController.Create()");
        }
        else if (request.Path.StartsWith("/api/leads/") && request.Method == "PUT")
        {
            string id = request.Path.Replace("/api/leads/", "");
            response.StatusCode = 200;
            response.Body = $"{{ \"message\": \"Lead {id} updated\" }}";
            Console.WriteLine($"[ROUTE] LeadController.Update({id})");
        }
        else if (request.Path == "/api/auth/login" && request.Method == "POST")
        {
            response.StatusCode = 200;
            response.Body = "{ \"token\": \"abc123\" }";
            Console.WriteLine("[ROUTE] AuthController.Login()");
        }
        else
        {
            response.StatusCode = 404;
            response.Body = "{ \"error\": \"Endpoint not found\" }";
            Console.WriteLine("[ROUTE] No matching route");
        }

        return response;
    }
}