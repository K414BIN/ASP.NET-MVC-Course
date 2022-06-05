using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(container =>
    { 
        container.RegisterAssemblyModules(typeof(Program));
  
        var config = new ConfigurationBuilder()
                       .AddXmlFile("autofac.config.xml",false,false)
                       .AddJsonFile("autofac.config.json", false, false)
                       .Build();
        container.RegisterModule(new ConfigurationModule(config));

    });

var services = builder.Services;
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();
//services.AddDbContext<OrdersDB>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseStaticFiles();

app.UseRouting();

/*
app.UseHttpsRedirection();
app.UseAuthorization();
*/

app.MapDefaultControllerRoute();
    
app.Run();
