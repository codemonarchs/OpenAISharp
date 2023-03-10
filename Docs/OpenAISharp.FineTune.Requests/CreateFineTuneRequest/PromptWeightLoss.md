# CreateFineTuneRequest.PromptWeightLoss property

The weight to use for loss on the prompt tokens. This controls how much the model tries to learn to generate the prompt (as compared to the completion which always has a weight of 1.0), and can add a stabilizing effect to training when completions are short. If prompts are extremely long (relative to completions), it may make sense to reduce this weight so as to avoid over-prioritizing learning the prompt.

```csharp
public int? PromptWeightLoss { get; set; }
```

## Remarks

https://beta.openai.com/docs/api-reference/fine-tunes/create#fine-tunes/create-prompt_loss_weight

## See Also

* class [CreateFineTuneRequest](../CreateFineTuneRequest.md)
* namespace [OpenAISharp.FineTune.Requests](../../OpenAISharp.FineTune.md)

<!-- DO NOT EDIT: generated by xmldocmd for OpenAISharp.FineTune.dll -->
