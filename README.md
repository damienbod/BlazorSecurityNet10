# Blazor Security .NET 10

When debugging using Visual studio, it adds 2 scripts which are blocked by default. This is a script attack and should be blocked .

If you would like to allow this in visual Studio debugging, you can use the **#if !DEBUG** to allow the following injected scripts:

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