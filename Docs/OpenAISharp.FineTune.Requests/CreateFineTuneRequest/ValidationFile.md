# CreateFineTuneRequest.ValidationFile property

The ID of an uploaded file that contains validation data. If you provide this file, the data is used to generate validation metrics periodically during fine-tuning. These metrics can be viewed in the fine-tuning results file.Your train and validation data should be mutually exclusive. Your dataset must be formatted as a JSONL file, where each validation example is a JSON object with the keys "prompt" and "completion". Additionally, you must upload your file with the purpose fine-tune. See the fine-tuning guide for more details.

```csharp
public string? ValidationFile { get; set; }
```

## Remarks

https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-validation_file

## See Also

* class [CreateFineTuneRequest](../CreateFineTuneRequest.md)
* namespace [OpenAISharp.FineTune.Requests](../../OpenAISharp.FineTune.md)

<!-- DO NOT EDIT: generated by xmldocmd for OpenAISharp.FineTune.dll -->
