# OpenAISharp
A **.NET Standard 2.1** C# class library created to easily interface with the the Open AI API.

Supported Versions of .NET and .NET Core

| .NET Core 3.1 | .NET 6.0 | .NET 7.0 |
| ------------- | -------- | -------- |

**Note:** Technically any framework that can support .NET Standard 2.1 can support this library (including .NET Core 3.0, .NET 5) but we've only included examples for the above.

## Support
This library is maintained in my own free time. If you'd like to buy me a coffee I would be eternally grateful for your support.
https://ko-fi.com/codemonarchs

## Getting Started
1. Install the NuGet package from [CodeMonarchs.OpenAISharp](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp/#show-readme-container):
    - ```dotnet add package CodeMonarchs.OpenAISharp```
2. Grab your `ApiKey` and `OrganizationId`  from Open AI:
    - [https://beta.openai.com/account/api-keys](https://beta.openai.com/account/api-keys)
    - [https://beta.openai.com/account/org-settings](https://beta.openai.com/account/org-settings) (optional)
3. Open your `appsettings.json` (or wherever your specific use case stores [configuration settings](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0)) and add the following key/value pair:
    ```json
    {
        "OpenAI:ApiKey": "<your-api-key>",
        "OpenAI:OrganizationId": "<your-organization-id>"
    } 
    ```
4. Register the dependencies in your `Program.cs` file:
    ```cs 
    // If using an individual package on its own or just the OpenAISharp library you can register the services and client like this:
    // This is useful if you want to customize the HttpClient with your own handlers or if you only want to register a limited set of services.
    var builder = WebApplication.CreateBuilder(args);

    var apiKey = builder.Configuration["OpenAI:ApiKey"];
    var organizationId = builder.Configuration["OpenAI:OrganizationId"];

    services.AddHttpClient<IOpenAIClient, OpenAIClient>(client =>
    {
        client.BaseAddress = new Uri("https://api.openai.com");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        if (!string.IsNullOrWhiteSpace(organizationId))
            client.DefaultRequestHeaders.Add("OpenAI-Organization", organizationId);
    });

    services.AddTransient<ICompletionService, CompletionService>();
    services.AddTransient<IEditService, EditService>();
    services.AddTransient<IEmbeddingService, EmbeddingService>();
    services.AddTransient<IFileService, FileService>();
    services.AddTransient<IFineTuneService, FineTuneService>();
    services.AddTransient<IImageService, ImageService>();
    services.AddTransient<IModelService, ModelService>();
    services.AddTransient<IModerationService, ModerationService>();

    // If you want to use the OpenAISharp.Extensions library you can register them like below (this will register all of the above for you in one line):
    // Include OpenAISharp.Extensions library to access the .AddOpenAI(...) extension method
    using OpenAISharp.Extensions;

    var builder = WebApplication.CreateBuilder(args);

    var apiKey = builder.Configuration["OpenAI:ApiKey"];
    var organizationId = builder.Configuration["OpenAI:OrganizationId"];

    builder.Services.AddOpenAI(apiKey, organizationId);
    ```
5. Consume any of the services in your controller via dependency injection:
    ```csharp
    using Microsoft.AspNetCore.Mvc;
    using OpenAISharp.Model;
    using OpenAISharp.Model.Responses;

    namespace OpenAISharp.Examples.WebApiNet7.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class ExampleController : ControllerBase
        {
            private readonly IModelService _modelService;

            public ExampleController(IModelService modelService)
            {
                _modelService = modelService;
            }

            [HttpGet]
            public async Task<ListModelsResponse> GetAsync()
                => await _modelService.ListModelsAsync();
        }
    }
    ```
6. **That's it!** See example project links below if you need help for another type of project.

## Basic Usage
Below is a run down of all of the services within this library and a sample of how to use them. All required parameters are set via the constructor in each of the request objects.

### CompletionService
```cs
// Create Completion
var request = new CreateCompletionRequest("model-name") { Prompt = "Say this is cool" };
var response = await service.CreateCompletionAsync(request);
```

### EditService
```cs
// Create Edit
var request = new CreateEditRequest(KnownModelNames.TextDavinciEdit001, "Translate this to Spanish") { Input = "Hey" };
var response = await service.CreateEditAsync(request);
```

### EmbeddingService
```cs
// Create Embedding
var request = new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, "The car was super fast and...");
var response = await service.CreateEmbeddingAsync(request);
```

### FileService
```cs
// List Files
var response = await service.ListFilesAsync();
```

```cs
// Upload File (JsonL string in memory)
var fileContent = FileUtility.ToJsonL(new List<FilePromptAndCompletion>
{
    new FilePromptAndCompletion("How old is Ryan Tunis?", "35"),
    new FilePromptAndCompletion("How old is Lourdes Palacios?", "29"),
    new FilePromptAndCompletion("How old is Enzo Tunis?", "That's a trick question. As of Jan 2023 he hasn't been born yet. Expeceted May 7th 2023." ),
    new FilePromptAndCompletion("How old is Chris Doherty?", "49. But for a mountain, he has only begun in years." )
});
var response = await service.UploadFileAsync(new UploadFileRequest("test-file.jsonl", fileContent, false));
```

```cs
// Upload File (JsonL from file)
var response = await service.UploadFileAsync(new UploadFileRequest("test-file.jsonl", @"C:\path\to\file.jsonl", true));
```

```cs
// Retrieve File
var response = await service.RetrieveFileAsync("file-id");
```

```cs
// Delete File
var response = await service.DeleteFileAsync("file-id");
```

```cs
// Retrieve File Content
var response = await service.RetrieveFileContentAsync("file-id");
```

### FineTuneService
```cs
// List FineTunes
var response = await service.ListFineTunesAsync();
```

```cs
// Create FineTunes
var request = new CreateFineTuneRequest("file-id");
var response = await service.CreateFineTuneAsync(request);
```

```cs
// Retrieve FineTune
var response = await service.RetrieveFineTuneAsync("fine-tune-id");
```

```cs
// Cancel FineTune
var response = await service.CancelFineTuneAsync("fine-tune-id");
```

```cs
// Delete FineTune Model
var response = await service.DeleteFineTuneModelAsync("model-id");
```

```cs
// List FineTune Events
var response = await service.ListFineTuneEventsAsync("fine-tune-id");
```

### ImageService
```cs
// Create Image
var request = new CreateImageRequest("Draw Etzio from Assassin's Creed");
var response = await service.CreateImageAsync(request);
```

```cs
// Create Image Edit
var request = new CreateImageEditRequest("test_image_rgba.png", @"C:\path\to\image.png", "Make me something random.", true);
var response = await service.CreateImageEditAsync(request);
```

```cs
// Create Image Variation
var request = new CreateImageVariationRequest("test_image_rgba.png",  @"C:\path\to\image.png", true);
var response = await service.CreateImageVariationAsync(request);
```

### ModelService
```cs
// List Models
var response = await service.ListModelsAsync();
```

```cs
// Retrieve Model
var response = await service.RetrieveModelAsync(KnownModelNames.Ada);
```

### ModerationService
```cs
// List Models
var request = new CreateModerationRequest("is this a bad word");
var response = await service.CreateModerationAsync(request);
```

## API Definitions
To view the API for this library you can check the Docs here (scroll down past the mega list of files):
https://github.com/codemonarchs/OpenAISharp/tree/main/Docs

## Error Handling
Currently there is no documentation on the Open AI API that tells you what type of object is returned on an unsuccessful response. So, until there is, rather than try to guess at what each type of response object is that comes back from the Open AI API, if there is no successful status code in the response of the API call we throw an exception. 

The exception is as follows:
```csharp
public class OpenAIClientException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public OpenAIClientException(HttpStatusCode httpStatusCode, string message) : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }
}
```
In the `OpenAISharp.Client` library that makes these requests, all we are doing is if there is a non successful status code we are just reading the response object as a string and putting that entire response inside the `Message` property of the exception. So in essence, you get the exact response that Open AI will return if your request is unsuccessful. It's just that it isn't in the form of a concrete object yet. This way, you can handle unsuccessful responses (for now) by catching the exception and doing what you need to do in your application like this:
```csharp
try
{
    var response = await service.ListModelsAsync();
}
catch (OpenAIClientException ex)
{
    /// handle errors appropriately
}
```

Until there is more fleshed out documentation on the type of responses that can come back from unsuccessful requests this is what we've come up with. We imagine once the API gets out of beta there will be more documentation on what those responses could be and we will adjust this library appropriately to match what their API states.

## Examples
Current examples include the following:
| Example             | .NET Core 3.1 | .NET 6 | .NET 7 |
| :------------------ | :-----------: | :----: | :----: |
| Blazor Server       |      No       |   No   |  Yes   |
| Blazor WebAssembly  |      No       |   No   |  Yes   |
| Console Application |      Yes      |  Yes   |  Yes   |
| Azure Functions     |      Yes      |  Yes   |  Yes   |
| ASP.NET Web API     |      Yes      |  Yes   |  Yes   |
| Windows Forms       |      Yes      |  Yes   |  Yes   |
| WPF                 |      Yes      |  Yes   |  Yes   |

https://github.com/codemonarchs/OpenAISharp/tree/main/Examples

## Libraries
1. [CodeMonarchs.OpenAISharp]()
    - Meta package that includes all of the below libraries.
2. [CodeMonarchs.OpenAISharp.Completion](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Completion/)
    - Completions API - (https://beta.openai.com/docs/api-reference/completions)
3. [CodeMonarchs.OpenAISharp.Edit](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Edit/)
    - Edit API - (https://beta.openai.com/docs/api-reference/edits)
4. [CodeMonarchs.OpenAISharp.Embedding](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Embedding/)
    - Embeddings API - (https://beta.openai.com/docs/api-reference/embeddings)
5. [CodeMonarchs.OpenAISharp.File](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.File/)
    - Files API - (https://beta.openai.com/docs/api-reference/files)
6. [CodeMonarchs.OpenAISharp.FineTune](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.FineTune/)
    - FineTunes API - (https://beta.openai.com/docs/api-reference/fine-tunes)
7. [CodeMonarchs.OpenAISharp.Image](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Image/)
    - Images API - (https://beta.openai.com/docs/api-reference/images)
8. [CodeMonarchs.OpenAISharp.Model](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Model/)
    - Models API - (https://beta.openai.com/docs/api-reference/models)
9. [CodeMonarchs.OpenAISharp.Moderation](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Moderation/)
    - Moderations API - (https://beta.openai.com/docs/api-reference/moderation)
10. [CodeMonarchs.OpenAISharp.Client](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Client/)
    - An abstraction layer specific to sending HTTP requests to the Open AI API. You don't need to include this by itself.
11. [CodeMonarchs.OpenAISharp.Utilities](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Utilities/)
    - A utility library that contains an implementation of the [Tokenizer Tool](https://beta.openai.com/tokenizer?view=bpe) for GPT-3.
12. [CodeMonarchs.OpenAISharp.Extensions](https://www.nuget.org/packages/CodeMonarchs.OpenAISharp.Extensions)
    - Extension methods for registering the OpenAIClient and services.

## Integration Testing Setup For Contributers (OpenAISharp.IntegrationTests)
1. Retrieve your `Apikey` and `OrganizationId` from the Open AI API.
    - https://beta.openai.com/account/api-keys
    - https://beta.openai.com/account/org-settings
2. Run the powershell script located in `OpenAISharp.IntegrationTests` to set environment variables with your `ApiKey` and `OrganizationId` from the Open AI API:
    - ```.\set-openai-credentials.ps1 -ApiKey <your-api-key> -OrganizationId <your-organization-id>```
3. That's it!

**Note:** If you have Visual Studio open while you set these environment variables you need to restart it as Visual Studio does not detect when the environment variables change.
