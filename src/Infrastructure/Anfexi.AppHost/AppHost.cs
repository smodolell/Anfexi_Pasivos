var builder = DistributedApplication.CreateBuilder(args);

var apiAuth = builder.AddProject<Projects.Anfx_Auth_ApiService>("anfx-auth-apiservice");
var apiSistema = builder.AddProject<Projects.Anfx_Sistema_ApiService>("anfx-sistema-apiservice");
var apiPasivos = builder.AddProject<Projects.Anfx_Pasivos_ApiService>("anfx-pasivos-apiservice");

var frontEnd = builder.AddJavaScriptApp("pasivo-frontend", "..\\..\\Site\\Pasivos_Frontend")
    .WithRunScript("start:aspire")
    .WithHttpEndpoint(targetPort: 4200, name: "http",isProxied:false) // Importante: solo targetPort
    .WithEnvironment("NODE_ENV", "development");


frontEnd.WithReference(apiAuth);
frontEnd.WithReference(apiSistema);
frontEnd.WithReference(apiPasivos);



builder.Build().Run();
