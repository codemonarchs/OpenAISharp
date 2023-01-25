param 
(
    [Parameter(Mandatory = $true)]
    [string] $ApiKey,
    
    [Parameter(Mandatory = $true)]
    [string] $OrganizationId
)

[Environment]::SetEnvironmentVariable("OpenAIOptions:ApiKey", $ApiKey, "User")
[Environment]::SetEnvironmentVariable("OpenAIOptions:OrganizationId", $OrganizationId, "User")
