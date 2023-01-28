using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Requests
{
    /// <summary>
    /// Creates a job that fine-tunes a specified model from a given dataset. Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
    /// </summary>
    /// <remarks>Used with <see cref="IFineTuneService.CreateFineTuneAsync"/>.</remarks>
    public class CreateFineTuneRequest
    {
        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="trainingFile"></param>
        public CreateFineTuneRequest(string trainingFile)
        {
            TrainingFile = trainingFile;
        }

        /// <summary>
        /// The ID of an uploaded file that contains training data. See upload file for how to upload a file.
        /// Your dataset must be formatted as a JSONL file, where each training example is a JSON object with the keys "prompt" and "completion". 
        /// Additionally, you must upload your file with the purpose fine-tune. See the fine-tuning guide for more details.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-training_file</remarks>
        [JsonPropertyName("training_file")]
        public string TrainingFile { get; }

        /// <summary>
        /// The ID of an uploaded file that contains validation data.
        /// If you provide this file, the data is used to generate validation metrics periodically during fine-tuning.
        /// These metrics can be viewed in the fine-tuning results file.Your train and validation data should be mutually exclusive.
        /// Your dataset must be formatted as a JSONL file, where each validation example is a JSON object with the keys "prompt" and "completion". 
        /// Additionally, you must upload your file with the purpose fine-tune. See the fine-tuning guide for more details.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-validation_file</remarks>
        [JsonPropertyName("validation_file")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ValidationFile { get; set; }

        /// <summary>
        /// The name of the base model to fine-tune. You can select one of "ada", "babbage", "curie", "davinci", or a fine-tuned model created after 2022-04-21. To learn more about these models, see the Models documentation.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-model</remarks>
        [JsonPropertyName("model")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Model { get; set; }

        /// <summary>
        /// The number of epochs to train the model for. An epoch refers to one full cycle through the training dataset.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-n_epochs</remarks>
        [JsonPropertyName("n_epochs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? NEpochs { get; set; }

        /// <summary>
        /// The batch size to use for training. The batch size is the number of training examples used to train a single forward and backward pass.
        /// By default, the batch size will be dynamically configured to be ~0.2% of the number of examples in the training set, capped at 256 - in general, we've found that larger batch sizes tend to work better for larger datasets.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-batch_size</remarks>
        [JsonPropertyName("batch_size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BatchSize { get; set; }

        /// <summary>
        /// The learning rate multiplier to use for training. The fine-tuning learning rate is the original learning rate used for pretraining multiplied by this value.
        /// By default, the learning rate multiplier is the 0.05, 0.1, or 0.2 depending on final batch_size(larger learning rates tend to perform better with larger batch sizes). 
        /// We recommend experimenting with values in the range 0.02 to 0.2 to see what produces the best results.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-learning_rate_multiplier</remarks>
        [JsonPropertyName("learning_rate_multiplier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? LearningRateMultiplier { get; set; }

        /// <summary>
        /// The weight to use for loss on the prompt tokens. 
        /// This controls how much the model tries to learn to generate the prompt (as compared to the completion which always has a weight of 1.0), and can add a stabilizing effect to training when completions are short.
        /// If prompts are extremely long (relative to completions), it may make sense to reduce this weight so as to avoid over-prioritizing learning the prompt.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-prompt_loss_weight</remarks>
        [JsonPropertyName("prompt_loss_weight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PromptWeightLoss { get; set; }

        /// <summary>
        /// If set, we calculate classification-specific metrics such as accuracy and F-1 score using the validation set at the end of every epoch. 
        /// These metrics can be viewed in the results file. In order to compute classification metrics, you must provide a validation_file.
        /// Additionally, you must specify classification_n_classes for multiclass classification or classification_positive_class for binary classification.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-compute_classification_metrics</remarks>
        [JsonPropertyName("compute_classification_metrics")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ComputeClassificationMetrics { get; set; }

        /// <summary>
        /// The number of classes in a classification task.
        /// This parameter is required for multiclass classification.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-classification_n_classes</remarks>
        [JsonPropertyName("classification_n_classes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ClassificationNClasses { get; set; }

        /// <summary>
        /// The positive class in binary classification.
        /// This parameter is needed to generate precision, recall, and F1 metrics when doing binary classification.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-classification_n_classes</remarks>
        [JsonPropertyName("classification_positive_class")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ClassificationPositiveClass { get; set; }

        /// <summary>
        /// If this is provided, we calculate F-beta scores at the specified beta values. 
        /// The F-beta score is a generalization of F-1 score. This is only used for binary classification.
        /// With a beta of 1 (i.e.the F-1 score), precision and recall are given the same weight.
        /// A larger beta score puts more weight on recall and less on precision. A smaller beta score puts more weight on precision and less on recall.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-classification_betas</remarks>
        [JsonPropertyName("classification_betas")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<object?>? ClassificationBetas { get; set; }

        /// <summary>
        /// A string of up to 40 characters that will be added to your fine-tuned model name.
        /// For example, a suffix of "custom-model-name" would produce a model name like ada:ft-your-org:custom-model-name-2022-02-15-04-21-04.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-suffix</remarks>
        [JsonPropertyName("suffix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Suffix { get; set; }
    }
}

