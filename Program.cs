using ChatbotWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services to the container
builder.Services.AddRazorPages();                     // For Index.cshtml
builder.Services.AddHttpClient();                     // For making backend requests
builder.Services.AddControllers();                    // For API controllers
builder.Services.AddSingleton<MongoService>();        // For MongoDB access

var app = builder.Build();

// ✅ Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();                                     // Enforce HTTPS in production
}

app.UseHttpsRedirection();                             // Redirect HTTP to HTTPS
app.UseStaticFiles();                                  // Enable wwwroot content
app.UseRouting();
app.UseAuthorization();                                // Needed if you add auth later

// ✅ Map endpoints
app.MapRazorPages();                                   // .cshtml pages
app.MapControllers();                                  // [ApiController] endpoints

app.Run();
