using OpenAISharp.Client;
using OpenAISharp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenAISharp.Examples.WindowsFormsNetCore31
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var apiKey = Environment.GetEnvironmentVariable("OpenAI:ApiKey"); // "<your-api-key>";
            var organizationId = Environment.GetEnvironmentVariable("OpenAI:OrganizationId"); // "<your-organization-id>";

            //var apiKey = "<your-api-key>";
            //var organizationId = "<your-organization-id>";

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
