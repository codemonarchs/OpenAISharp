using OpenAISharp.Client;
using OpenAISharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenAISharp.Examples.WpfNet6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
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
