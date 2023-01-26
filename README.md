# OpenAISharp
A <b>.NET Standard 2.1</b> C# class library created to easily interface with the the Open AI API.

##### Supported Versions of .NET and .NET Core
| .NET Core 3.0 | .NET Core 3.1 | .NET 5.0 | .NET 6.0 | .NET 7.0 |
| ------------- | ------------- | -------- | -------- | -------- |

### Getting Started - Web API (.NET/.NET Core)
1. Install the NuGet package from <a href="#">CodeMonarchs.OpenAISharp</a>:
    ```dotnet add package CodeMonarchs.OpenAISharp```
2. Open your `appsettings.json` file and add the following key/value pair:
    ```json
    {
        ...omitted for brevity
        "OpenAI": {
            "ApiKey": "<your-api-key>",
            "OrganizationId": "<your-organization-id>"
        }
    } 
    ```
3. Replace `<your-api-key>` with your <b>Open AI API Key</b> from here: 
   - https://beta.openai.com/account/api-keys
4. Replace `<your-organizatin-key>` with your <b>Open AI Organization Id</b> from here: 
   - https://beta.openai.com/account/org-settings
5. Add <b>required dependencies</b> to the `Program.cs` file:
    ```cs 
    builder.Services.AddHttpClient();
    builder.Services.AddScoped<IOpenAIClient, OpenAIClient>();
    builder.Services.Configure<OpenAIClientOptions>(builder.Configuration.GetSection("OpenAI"));
    ```
    Currently, the `OpenAIClient` class depends on `IHttpClientFactory` so you have to `AddHttpClient()` to your project for the dependencies to resolve properly.
6. Add any the API specifc service classes you want to utilize to the `Program.cs` file:
   ```cs
    builder.Services.AddScoped<ICompletionService, CompletionService>();
    builder.Services.AddScoped<IEditService, EditService>();
    builder.Services.AddScoped<IEmbeddingService, EmbeddingService>();
    builder.Services.AddScoped<IFileService, FileService>();
    builder.Services.AddScoped<IFineTuneService, FineTuneService>();
    builder.Services.AddScoped<IImageService, ImageService>();
    builder.Services.AddScoped<IModelService, ModelService>();
    builder.Services.AddScoped<IModerationService, ModerationService>();
   ```
7. <b>That's it!</b> Now you can consume any of the services in this repository as you normal would with regular old dependency injection.

<i><b>Note: </b>If you add the base package `CodeMonarchs.OpenAISharp` it will include all of the packages listed above. If you are only interested in a particular endpoint (such as the Completion API) from Open AI then just install the package related to that endpoint you're interested in. Example: </i> ```dotnet add package CodeMonarchs.OpenAISharp.Completion```

#### Examples
1. .NET/.NET Core Web API - https://github.com/codemonarchs/OpenAISharp/tree/main/OpenAISharp.Examples.WebApi
2. Blazor WebAssembly - https://github.com/codemonarchs/OpenAISharp/tree/main/OpenAISharp.Examples.BlazorWebAssembly
3. Blazor Server - https://github.com/codemonarchs/OpenAISharp/tree/main/OpenAISharp.Examples.BlazorServer
4. Azure Functions v4 - https://github.com/codemonarchs/OpenAISharp/tree/main/OpenAISharp.Examples.AzureFunctions

#### NuGet Packages
1. `CodeMonarchs.OpenAISharp`
    - <small>Includes all of the below packages.</small>
    - <small><a href="#">NuGet Package</a></small>
2. `CodeMonarchs.OpenAISharp.Completion`
    - <small>Based on the Completions API - (https://beta.openai.com/docs/api-reference/completions)</small>
    - <small><a href="#">NuGet Package</a></small>
3. `CodeMonarchs.OpenAISharp.Edit`
    - <small>Based on the Edit API - (https://beta.openai.com/docs/api-reference/edits)</small>
    - <small><a href="#">NuGet Package</a></small>
4. `CodeMonarchs.OpenAISharp.Embedding`
    - <small>Based on the Embeddings API - (https://beta.openai.com/docs/api-reference/embeddings)</small>
    - <small><a href="#">NuGet Package</a></small>
5. `CodeMonarchs.OpenAISharp.File`
    - <small>Based on the Files API - (https://beta.openai.com/docs/api-reference/files)</small>
    - <small><a href="#">NuGet Package</a></small>
6. `CodeMonarchs.OpenAISharp.FineTune`
    - <small>Based on the FineTunes API - (https://beta.openai.com/docs/api-reference/fine-tunes)</small>
    - <small><a href="#">NuGet Package</a></small>
7. `CodeMonarchs.OpenAISharp.Image`
    - <small>Based on the Images API - (https://beta.openai.com/docs/api-reference/images)</small>
    - <small><a href="#">NuGet Package</a></small>
8. `CodeMonarchs.OpenAISharp.Model`
    - <small>Based on the Models API - (https://beta.openai.com/docs/api-reference/models)</small>
    - <small><a href="#">NuGet Package</a></small>
9. `CodeMonarchs.OpenAISharp.Moderation`
    - <small>Based on the Moderations API - (https://beta.openai.com/docs/api-reference/moderation)</small>
    - <small><a href="#">NuGet Package</a></small>
10. `CodeMonarchs.OpenAISharp.Client`
    - <small>An abstraction layer specific to sending HTTP requests to the Open AI API. You don't need to include this by itself.</small>
    - <small><a href="#">NuGet Package</a></small>
11. `CodeMonarchs.OpenAISharp.Utilities`
    - <small>A utility library that contains an implementation of the <a href="https://beta.openai.com/tokenizer?view=bpe">Tokenizer Tool</a> for GPT-3.</small>
    - <small><a href="#">NuGet Package</a></small>

#### Integration Testing Setup (OpenAISharp.IntegrationTests)
1. Retrieve your `Apikey` and `OrganizationId` from the Open AI Api.
    - https://beta.openai.com/account/api-keys
    - https://beta.openai.com/account/org-settings
2. Run the powershell script located in `OpenAISharp.IntegrationTests` to set environment variables with your `ApiKey` and `OrganizationId` from the Open AI API:
    - ```.\set-openai-credentials.ps1 -ApiKey <your-api-key> -OrganizationId <your-organization-id>```
3. That's it!

<i><b>Note: </b>If you have Visual Studio open while you set these environment variables you need to restart it as Visual Studio does not detect when the environment variables change.</i>
