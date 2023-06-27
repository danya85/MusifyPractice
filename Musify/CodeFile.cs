
//Add swagger documentation

/*
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Endpoints", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
                {
                        new OpenApiSecurityScheme
                        {
                                Reference = new OpenApiReference
                                {
                                        Type=ReferenceType.SecurityScheme,
                                        Id="Bearer"
                                }
                        },
                        new string[]{}
                }
        });
});
*/

// Configure Token Options
/*

"TokenOptions": {
		"Audience": "EndpointsClients",
		"Issuer": "PluralsightApiBestPractices",
		"AccessTokenExpiration": 300,
		"Secret": "very_long_but_insecure_token_here_be_sure_to_use_env_var"
	},

builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

*/