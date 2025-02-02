using TextWeb;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

// Add services to the container.
// NOTICE: builder.Services.AddRazorPages();

var app = builder.Build();

app.MapHub<TextHub>("/TextHub");
app.Run();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment()) {
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();
