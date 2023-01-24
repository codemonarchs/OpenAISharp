using OpenAISharp.Utilities.Constants;
using System.Collections.Generic;

namespace OpenAISharp.Utilities
{
    public static class ModelUtility
    {
        private static Dictionary<DefaultModels, string> DefaultModels = new Dictionary<DefaultModels, string>
        {
            { Constants.DefaultModels.Babbage, DefaultModelNames.Babbage },
            { Constants.DefaultModels.Ada, DefaultModelNames.Ada },
            { Constants.DefaultModels.Davinci, DefaultModelNames.Davinci },
            { Constants.DefaultModels.TextDavinci001, DefaultModelNames.TextDavinci001 },
            { Constants.DefaultModels.CurieInstructBeta, DefaultModelNames.CurieInstructBeta },
            { Constants.DefaultModels.TextDavinci003, DefaultModelNames.TextDavinci003 },
            { Constants.DefaultModels.CodeCushman001, DefaultModelNames.CodeCushman001 },
            { Constants.DefaultModels.CodeDavinci002, DefaultModelNames.CodeDavinci002 },
            { Constants.DefaultModels.TextAda001, DefaultModelNames.TextAda001 },
            { Constants.DefaultModels.TextDavinci002, DefaultModelNames.TextDavinci002 },
            { Constants.DefaultModels.TextCurie001, DefaultModelNames.TextCurie001 },
            { Constants.DefaultModels.DavinciInstructBeta, DefaultModelNames.DavinciInstructBeta },
            { Constants.DefaultModels.TextBabbage, DefaultModelNames.TextBabbage },
        };

        /// <summary>
        /// Gets the model id from the default models available in the Open AI API.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetModelName(DefaultModels model) => DefaultModels[model];
    }
}
