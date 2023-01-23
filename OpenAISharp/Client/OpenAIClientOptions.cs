namespace OpenAISharp.Client
{
    /// <summary>
    /// Configuration settings for the Open AI API.
    /// </summary>
    public class OpenAIClientOptions
    {
        /// <summary>
        /// Your API key from Open AI.
        /// </summary>
        /// <remarks>https://beta.openai.com/account/api-keys</remarks>
        public string? ApiKey { get; set; } 

        /// <summary>
        /// Your Organization ID from Open AI.
        /// </summary>
        /// <remarks>https://beta.openai.com/account/org-settings</remarks>
        public string? OrganizationId { get; set; } 
    }
}
