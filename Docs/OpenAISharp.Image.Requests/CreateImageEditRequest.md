# CreateImageEditRequest class

Creates an edited or extended image given an original image and a prompt.

```csharp
public class CreateImageEditRequest
```

## Public Members

| name | description |
| --- | --- |
| [CreateImageEditRequest](CreateImageEditRequest/CreateImageEditRequest.md)(…) |  |
| [Image](CreateImageEditRequest/Image.md) { get; } | The image to edit. Must be a valid PNG file, less than 4MB, and square. If mask is not provided, image must have transparency, which will be used as the mask. |
| [ImageContent](CreateImageEditRequest/ImageContent.md) { get; } | The actual image content or a path to the image file. |
| [Mask](CreateImageEditRequest/Mask.md) { get; set; } | An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where image should be edited. Must be a valid PNG file, less than 4MB, and have the same dimensions as image. |
| [MaskContent](CreateImageEditRequest/MaskContent.md) { get; set; } | The actual mask content or a path to the mask image file. |
| [N](CreateImageEditRequest/N.md) { get; set; } | The number of images to generate. Must be between 1 and 10. |
| [Prompt](CreateImageEditRequest/Prompt.md) { get; } | A text description of the desired image(s). The maximum length is 1000 characters. |
| [ResponseFormat](CreateImageEditRequest/ResponseFormat.md) { get; set; } | The format in which the generated images are returned. Must be one of url or b64_json. |
| [Size](CreateImageEditRequest/Size.md) { get; set; } | The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024. |
| [UseImageFilePath](CreateImageEditRequest/UseImageFilePath.md) { get; } | A flag to determine whether to get image data from a file path or if the data is already included. |
| [UseMaskFilePath](CreateImageEditRequest/UseMaskFilePath.md) { get; set; } | A flag to determine whether to get mask image data from a file path or if the data is already included. |
| [User](CreateImageEditRequest/User.md) { get; set; } | A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. |

## Remarks

Used with [`CreateImageEditAsync`](../OpenAISharp.Image/IImageService/CreateImageEditAsync.md).

## See Also

* namespace [OpenAISharp.Image.Requests](../OpenAISharp.Image.md)

<!-- DO NOT EDIT: generated by xmldocmd for OpenAISharp.Image.dll -->
