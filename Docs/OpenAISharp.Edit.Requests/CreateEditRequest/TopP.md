# CreateEditRequest.TopP property

An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend altering this or temperature but not both.

```csharp
public double? TopP { get; set; }
```

## Remarks

https://beta.openai.com/docs/api-reference/edits/create#edits/create-top_p

## See Also

* class [CreateEditRequest](../CreateEditRequest.md)
* namespace [OpenAISharp.Edit.Requests](../../OpenAISharp.Edit.md)

<!-- DO NOT EDIT: generated by xmldocmd for OpenAISharp.Edit.dll -->
