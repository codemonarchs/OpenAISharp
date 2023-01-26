# OpenAISharp
A <b>.NET Standard 2.1</b> C# class library created to easily interface with the the Open AI API.

##### Supported Versions of .NET and .NET Core
| .NET Core 3.0 | .NET Core 3.1 | .NET 5.0 | .NET 6.0 | .NET 7.0 |
| ------------- | ------------- | -------- | -------- | -------- |

### Getting Started - Web API (.NET/.NET Core)
1. Install the NuGet package from <a href="#">CodeMonarchs.OpenAISharp</a>:
    - ```dotnet add package CodeMonarchs.OpenAISharp```
2. Grab your `ApiKey` and `OrganizationId`  from Open AI:
    - https://beta.openai.com/account/api-keys
    - https://beta.openai.com/account/org-settings (optional)
3. Open your `appsettings.json` (or wherever your specific use case stores <a href="https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0">configuration settings</a>) and add the following key/value pair:
    ```json
    {
        "OpenAI:ApiKey": "<your-api-key>",
        "OpenAI:OrganizationId": "<your-organization-id>"
    } 
    ```
4. Register the dependencies in your `Program.cs` file:
    ```cs 
    // Include OpenAISharp.Extensions library to access the .AddOpenAI(...) extension method
    using OpenAISharp.Extensions;

    var builder = WebApplication.CreateBuilder(args);

    // Add OpenAISharp Dependencies and Configuration
    var apiKey = builder.Configuration["OpenAI:ApiKey"];
    var organizationId = builder.Configuration["OpenAI:OrganizationId"];
    builder.Services.AddOpenAI(apiKey, organizationId);
    ```
7. <b>That's it!</b> Now you can consume any of the services in this repository as you normally would with regular old dependency injection. See example project links below if you need help.

### Usage
Below is a run down of all of the services within this library and a sample of how to use them. All required parameters are set via the constructor in each of the request objects.
#### CompletionService
```cs
// Create Completion
var request = new CreateCompletionRequest("model-name") { Prompt = "Say this is cool" };
var response = await service.CreateCompletionAsync(request);
```

#### EditService
```cs
// Create Edit
var request = new CreateEditRequest(KnownModelNames.TextDavinciEdit001, "Translate this to Spanish") { Input = "Hey" };
var response = await service.CreateEditAsync(request);
```

#### EmbeddingService
```cs
// Create Embedding
var request = new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, "The car was super fast and...");
var response = await service.CreateEmbeddingAsync(request);
```

#### FileService
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

#### FineTuneService
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

#### ImageService
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

#### ModelService
```cs
// List Models
var response = await service.ListModelsAsync();
```
```cs
// Retrieve Model
var response = await service.RetrieveModelAsync(KnownModelNames.Ada);
```

#### ModerationService
```cs
// List Models
var request = new CreateModerationRequest("is this a bad word");
var response = await service.CreateModerationAsync(request);
```

#### Examples
https://github.com/codemonarchs/OpenAISharp/tree/main/Examples

#### Libraries
1. `CodeMonarchs.OpenAISharp`
    - Meta package that includes all of the below libraries.
2. `CodeMonarchs.OpenAISharp.Completion`
    - Completions API - (https://beta.openai.com/docs/api-reference/completions)
3. `CodeMonarchs.OpenAISharp.Edit`
    - Edit API - (https://beta.openai.com/docs/api-reference/edits)
4. `CodeMonarchs.OpenAISharp.Embedding`
    - Embeddings API - (https://beta.openai.com/docs/api-reference/embeddings)
5. `CodeMonarchs.OpenAISharp.File`
    - Files API - (https://beta.openai.com/docs/api-reference/files)
6. `CodeMonarchs.OpenAISharp.FineTune`
    - FineTunes API - (https://beta.openai.com/docs/api-reference/fine-tunes)
7. `CodeMonarchs.OpenAISharp.Image`
    - Images API - (https://beta.openai.com/docs/api-reference/images)
8. `CodeMonarchs.OpenAISharp.Model`
    - Models API - (https://beta.openai.com/docs/api-reference/models)
9. `CodeMonarchs.OpenAISharp.Moderation`
    - Moderations API - (https://beta.openai.com/docs/api-reference/moderation)
10. `CodeMonarchs.OpenAISharp.Client`
    - An abstraction layer specific to sending HTTP requests to the Open AI API. You don't need to include this by itself.
11. `CodeMonarchs.OpenAISharp.Utilities`
    - A utility library that contains an implementation of the <a href="https://beta.openai.com/tokenizer?view=bpe">Tokenizer Tool</a> for GPT-3.

#### Integration Testing Setup For Contributers (OpenAISharp.IntegrationTests)
1. Retrieve your `Apikey` and `OrganizationId` from the Open AI API.
    - https://beta.openai.com/account/api-keys
    - https://beta.openai.com/account/org-settings
2. Run the powershell script located in `OpenAISharp.IntegrationTests` to set environment variables with your `ApiKey` and `OrganizationId` from the Open AI API:
    - ```.\set-openai-credentials.ps1 -ApiKey <your-api-key> -OrganizationId <your-organization-id>```
3. That's it!

<i><b>Note: </b>If you have Visual Studio open while you set these environment variables you need to restart it as Visual Studio does not detect when the environment variables change.</i>
