using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class MyCustomMiddleware
{
    private readonly RequestDelegate _next;

    public MyCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Logic to be executed before the next middleware in the pipeline
        Console.WriteLine("Executing custom middleware before the next middleware");

        // Call the next middleware in the pipeline
        await _next(context);

        // Logic to be executed after the next middleware in the pipeline
        Console.WriteLine("Executing custom middleware after the next middleware");
    }
}
