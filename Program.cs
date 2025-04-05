using BuscaCepApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ViaCepService>(); 

var app = builder.Build();

// Configurações de pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ← Ativa arquivos estáticos como CSS, JS, imagens etc.

app.UseRouting();

app.UseAuthorization();

// Define a rota padrão
app.MapControllerRoute(
    name: "default",
      pattern: "{controller=Cep}/{action=Index}/{id?}");

app.Run();
