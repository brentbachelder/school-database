using School.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Support for Web API Controllers
builder.Services.AddControllers();

// Add Dependency Injection
builder.Services.AddTransient<ITeacherAdapter, TeacherAdapter>();
builder.Services.AddTransient<IStudentAdapter, StudentAdapter>();
builder.Services.AddTransient<IExamAdapter, ExamAdapter>();
builder.Services.AddTransient<IReportAdapter, ReportAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Set up mapping for Web API
app.MapControllers();

app.Run();
