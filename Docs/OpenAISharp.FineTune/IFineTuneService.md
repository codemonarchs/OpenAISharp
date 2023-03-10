# IFineTuneService interface

Manage fine-tuning jobs to tailor a model to your specific training data.

```csharp
public interface IFineTuneService
```

## Members

| name | description |
| --- | --- |
| [CancelFineTuneAsync](IFineTuneService/CancelFineTuneAsync.md)(…) | Immediately cancel a fine-tune job. |
| [CreateFineTuneAsync](IFineTuneService/CreateFineTuneAsync.md)(…) | Creates a job that fine-tunes a specified model from a given dataset. Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete. |
| [DeleteFineTuneModelAsync](IFineTuneService/DeleteFineTuneModelAsync.md)(…) | Delete a fine-tuned model. You must have the Owner role in your organization. |
| [ListFineTuneEventsAsync](IFineTuneService/ListFineTuneEventsAsync.md)(…) | Get fine-grained status updates for a fine-tune job. |
| [ListFineTunesAsync](IFineTuneService/ListFineTunesAsync.md)() | List your organization's fine-tuning jobs. |
| [RetrieveFineTuneAsync](IFineTuneService/RetrieveFineTuneAsync.md)(…) | Gets info about the fine-tune job. |

## Remarks

https://beta.openai.com/docs/api-reference/fine-tunes

## See Also

* namespace [OpenAISharp.FineTune](../OpenAISharp.FineTune.md)

<!-- DO NOT EDIT: generated by xmldocmd for OpenAISharp.FineTune.dll -->
