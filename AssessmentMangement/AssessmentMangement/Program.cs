using AssessmentMangement.DataContext;
using AssessmentMangement.Infrastructure.Filters;
using AssessmentMangement.Mapper;
using AssessmentMangement.Repository.Employees;
using AssessmentMangement.Repository;
using AssessmentMangement.Services.Employees;
using AssessmentMangement.Entites.ClassAssessments;
using AssessmentMangement.Repository.ClassAssessments;
using AssessmentMangement.Services.ClassAssessments;
using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Repository.ClassStudentAssessments;
using AssessmentMangement.Services.ClassStudentAssessments;
using AssessmentMangement.Entites.ClassStudentAssessmentResources;
using AssessmentMangement.Repository.ClassStudentAssessmentResources;
using AssessmentMangement.Services.ClassStudentAssessmentResources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



var mapperConfig = new AutoMapper.MapperConfiguration(mc =>
{
    mc.AddProfile(new UpwardsLmsMapper());
});
AutoMapper.IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);








builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<IEmployeeService, EmployeeService>();


builder.Services.AddTransient<IClassAssessmentService, ClassAssessmentService>();

builder.Services.AddTransient<IClassStudentAssessmentService, ClassStudentAssessmentService>();
//ClassStudentAssessmentResource
builder.Services.AddTransient<IClassStudentAssessmentResourceService, ClassStudentAssessmentResourceService>();

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddTransient<IClassAssessmentRepository, ClassAssessmentRepository>();

builder.Services.AddTransient<IClassStudentAssessmentRepository, ClassStudentAssessmentRepository>();

builder.Services.AddTransient<IClassStudentAssessmentResourceRepository, ClassStudentAssessmentResourceRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<UnitOfWorkFilter>();

builder.Services.AddScoped<UpwardsLmsContext>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
