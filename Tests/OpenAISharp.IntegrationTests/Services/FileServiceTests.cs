using OpenAISharp.File;
using OpenAISharp.File.Models;
using OpenAISharp.File.Requests;
using OpenAISharp.File.Utilities;

namespace OpenAISharp.IntegrationTests.Services
{
    public class FileServiceTests
    {
        [Fact]
        public async Task WhenCallingListFilesAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFileService>();
            var response = await service.ListFilesAsync();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingUploadFileAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFileService>();
            var fileContent = FileUtility.ToJsonL(new List<FilePromptAndCompletion>
            {
                new FilePromptAndCompletion("How old is Ryan Tunis?", "35"),
                new FilePromptAndCompletion("How old is Lourdes Palacios?", "29"),
                new FilePromptAndCompletion("How old is Enzo Tunis?", "That's a trick question. As of Jan 2023 he hasn't been born yet. Expeceted May 7th 2023." ),
                new FilePromptAndCompletion("How old is Chris Doherty?", "49. But for a mountain, he has only begun in years." )
            });
            var response = await service.UploadFileAsync(new UploadFileRequest("ryan-tunis-test-file.jsonl", fileContent, false));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingRetrieveFileAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFileService>();
            var response = await service.RetrieveFileAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingDeleteFileAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFileService>();
            var response = await service.DeleteFileAsync("");
            Assert.NotNull(response);
            Assert.True(response.Deleted);
        }

        [Fact]
        public async Task WhenCallingRetrieveFileContentAsyncShouldNotBeNull()
        {
            // This requires a paid account
            var service = IntegrationTestStartup.GetService<IFileService>();
            var response = await service.RetrieveFileContentAsync("");
            Assert.NotNull(response);
        }
    }
}