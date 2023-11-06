using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using static HttpProgramming.ManualStaticServer.ManualStaticServer;

namespace HttpProgramming.ManualStaticServer;

public partial class ManualStaticServer
{
    private readonly int _portNumber;
    private readonly string _basePath;

    public ManualStaticServer(int portNumber, string basePath)
    {
        _portNumber = portNumber;
        _basePath = basePath;
    }

    public async Task Listen()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add($"http://localhost:{_portNumber}/");

        listener.Start();

        Console.WriteLine($"Server is listening at port {_portNumber}...");
        try
        {
            while (true)
            {
                var context = await listener.GetContextAsync();

                Console.WriteLine("Server got request...");

                await HandleRequest(context);
            }
        }
        catch
        {
            listener.Stop();
        }
    }

    private async Task HandleRequest(HttpListenerContext httpListenerContext)
    {
        var request = httpListenerContext.Request;
        var response = httpListenerContext.Response;

        var requestMethod = request.HttpMethod;
        var requestUrl = request.Url?.AbsolutePath ?? string.Empty;
        var requestBody = await GetRequestBody(request);

        var (responseString, responseStatusCode) = GetAppropriateResponseForRequest(
            requestUrl: requestUrl,
            requestMethod: requestMethod,
            requestBody: requestBody);

        var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

        response.ContentLength64 = buffer.Length;
        response.StatusCode = (int)responseStatusCode;

        var output = response.OutputStream;
        await output.WriteAsync(buffer);

        output.Close();
    }

    private (string responseData, HttpStatusCode) GetAppropriateResponseForRequest(
        string requestUrl,
        string requestMethod,
        string requestBody)
    {
        try
        {
            string fullPath = Path.Combine(_basePath, requestUrl.Substring(1));
            using var streamReader = new StreamReader(fullPath);

            switch (requestMethod)
            {
                case "GET":
                    string responseData = streamReader.ReadToEnd();
                    return (responseData, HttpStatusCode.OK);

                default:
                    return ("File not found", HttpStatusCode.NotFound);
            }
        }
        catch (Exception e)
        {
            return (e.Message, HttpStatusCode.InternalServerError);
        }
    }
   
    private static async Task<string> GetRequestBody(HttpListenerRequest request)
    {
        if (!request.HasEntityBody)
            return string.Empty;

        var body = request.InputStream;
        var encoding = request.ContentEncoding;
        var reader = new StreamReader(body, encoding);

        var requestBodyString = await reader.ReadToEndAsync();

        return requestBodyString;
    }
}