param 
(
    [Parameter(Mandatory = $true)]
    [string] $ApiKey,
    
    [Parameter(Mandatory = $true)]
    [string] $OrganizationId
)

[Environment]::SetEnvironmentVariable("OpenAI:ApiKey", $ApiKey, "User")
[Environment]::SetEnvironmentVariable("OpenAI:OrganizationId", $OrganizationId, "User")