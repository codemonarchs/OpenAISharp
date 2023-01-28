using OpenAISharp.Client;
using OpenAISharp.Model;

namespace OpenAISharp.Examples.WindowsFormsNet7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var apiKey = "<your-api-key>";
            var organizationId = "<your-organization-id>";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.openai.com");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            if (!string.IsNullOrWhiteSpace(organizationId))
                httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", organizationId);

            var openAIClient = new OpenAIClient(httpClient);
            var modelService = new ModelService(openAIClient);

            var response = await modelService.ListModelsAsync();
        }
    }
}