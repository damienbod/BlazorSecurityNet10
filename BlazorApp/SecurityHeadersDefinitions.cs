namespace BlazorApp;

using Microsoft.AspNetCore.Builder;

public static class SecurityHeadersDefinitions
{
    public static HeaderPolicyCollection GetHeaderPolicyCollection(bool isDev)
    {
        //ArgumentNullException.ThrowIfNull(idpHost);

        var policy = new HeaderPolicyCollection()
            .AddFrameOptionsDeny()
            .AddContentTypeOptionsNoSniff()
            .AddReferrerPolicyStrictOriginWhenCrossOrigin()
            .AddCrossOriginOpenerPolicy(builder => builder.SameOrigin())
            .AddCrossOriginResourcePolicy(builder => builder.SameOrigin())
            .AddCrossOriginEmbedderPolicy(builder => builder.RequireCorp()) 
            .AddContentSecurityPolicy(builder =>
            {
                builder.AddObjectSrc().None();
                builder.AddBlockAllMixedContent();
                builder.AddImgSrc().Self().From("data:");
                builder.AddFormAction().Self(); //.From(idpHost);
                builder.AddFontSrc().Self();
                builder.AddStyleSrc().Self().UnsafeInline();
                builder.AddBaseUri().Self();
                builder.AddFrameAncestors().None();

                builder.AddScriptSrc().WithNonce().UnsafeInline();
            })
            .RemoveServerHeader()
            .AddPermissionsPolicyWithDefaultSecureDirectives();

        if (!isDev)
        {
            // maxage = one year in seconds
            policy.AddStrictTransportSecurityMaxAgeIncludeSubDomains();
        }

        return policy;
    }
}
