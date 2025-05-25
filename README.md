# Blazor Security .NET 10

Add the `NetEscapades.AspNetCore.SecurityHeaders` NuGet package to your Blazor Server project to add security headers to your application. This package provides a middleware that can be configured to set various HTTP headers to enhance the security of your Blazor application.

```xml
<PackageReference Include="NetEscapades.AspNetCore.SecurityHeaders" Version="1.1.0" />
```

Define the security headers policy in the code and add it the the middleware.

Update the _Imports.razor file:

```xml
@using NetEscapades.AspNetCore.SecurityHeaders
```

Applied the headers in the UI:
```xml
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />

    <link rel="stylesheet" href="@Assets["lib/bootstrap/dist/css/bootstrap.min.css"]" nonce="@Nonce" />
    <link rel="stylesheet" href="@Assets["app.css"]" nonce="@Nonce" />
    <link rel="stylesheet" href="@Assets["BlazorApp.styles.css"]" nonce="@Nonce" />

    <ImportMap AdditionalAttributes="@(new Dictionary<string, object>() { { "nonce", Nonce ?? "" } })" />

    <link rel="icon" type="image/png" href="favicon.png" />
    <HeadOutlet />
</head>

<body>
    <Routes />
    <ReconnectModal />
    <script src="@Assets["_framework/blazor.web.js"]" nonce="@Nonce"></script>
</body>

</html>
@code
{
    public string? Nonce => HttpContextAccessor?.HttpContext?.GetNonce();
    [Inject] private IHttpContextAccessor? HttpContextAccessor { get; set; }
}
```


When debugging using Visual Studio, it adds 2 scripts which are blocked by default. This is a script attack and should be blocked .

If you would like to allow this in Visual Studio debugging, you can use the **#if !DEBUG** to allow the following injected scripts:

```xml

<!-- Visual Studio Browser Link -->
<script type="text/javascript" src="/_vs/browserLink" async="async" id="__browserLink_initializationData" 
data-requestId="fd739be01c8a45888c54af56a3c3f479" 
data-requestMappingFromServer="false" 
data-connectUrl="http://localhost:51725/6869c90f017d4a4ca18b914bd51ac7b6/browserLink"></script>
<!-- End Browser Link -->

<script src="/_framework/aspnetcore-browser-refresh.js"></script>

```

## Links

https://github.com/damienbod/BlazorServerOidc