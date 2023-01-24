using OpenAISharp.Utilities;
using OpenAISharp.Utilities.Constants;

namespace OpenAISharp.UnitTests
{
    public class ModelUtilityTests
    {
        public static IEnumerable<object[]> ModelTestData()
        {
            yield return new object[] { DefaultModels.Babbage, DefaultModelNames.Babbage };
            yield return new object[] { DefaultModels.Ada, DefaultModelNames.Ada };
            yield return new object[] { DefaultModels.Davinci, DefaultModelNames.Davinci };
            yield return new object[] { DefaultModels.TextDavinci001, DefaultModelNames.TextDavinci001 };
            yield return new object[] { DefaultModels.CurieInstructBeta, DefaultModelNames.CurieInstructBeta };
            yield return new object[] { DefaultModels.TextDavinci003, DefaultModelNames.TextDavinci003 };
            yield return new object[] { DefaultModels.CodeCushman001, DefaultModelNames.CodeCushman001 };
            yield return new object[] { DefaultModels.CodeDavinci002, DefaultModelNames.CodeDavinci002 };
            yield return new object[] { DefaultModels.TextAda001, DefaultModelNames.TextAda001 };
            yield return new object[] { DefaultModels.TextDavinci002, DefaultModelNames.TextDavinci002 };
            yield return new object[] { DefaultModels.TextCurie001, DefaultModelNames.TextCurie001 };
            yield return new object[] { DefaultModels.DavinciInstructBeta, DefaultModelNames.DavinciInstructBeta };
            yield return new object[] { DefaultModels.TextBabbage, DefaultModelNames.TextBabbage };
        }

        [Theory]
        [MemberData(nameof(ModelTestData))]
        public void WhenGettingModelNameByEnumShouldReturnExpectedName(DefaultModels model, string expectedName)
            => Assert.Equal(expectedName, ModelUtility.GetModelName(model));
    }
}