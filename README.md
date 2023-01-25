# OpenAISharp
WIP: C# wrapper library for the Open AI API.

##### Work In Progress
1. Deploy as NuGet packages.
2. Set up CI/CD pipeline.
3. Write documentation.

## Integration Testing Setup (OpenAISharp.IntegrationTests)
1. Retrieve your `Apikey` and `OrganizationId` from the Open AI Api.
    - https://beta.openai.com/account/api-keys
    - https://beta.openai.com/account/org-settings
2. Run the powershell script located in `OpenAISharp.IntegrationTests` to set environment variables with your `ApiKey` and `OrganizationId` from the Open AI API:
    - ```.\set-openai-credentials.ps1 -ApiKey <your-api-key> -OrganizationId <your-organization-id>```
3. That's it!

Note: If you have Visual Studio open while you set these environment variables you need to restart it as Visual Studio does not detect when the environment variables change.