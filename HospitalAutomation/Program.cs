using HospitalAutomation.DataAccess;
using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.DataAccess.Concretes;
using HospitalAutomation.Service;
using HospitalAutomation.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<HospitalDbContext>();

// Repositories
builder.Services.AddScoped<IAppointmentRepository, AppointmentSqlRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentSqlRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorSqlRepository>();
builder.Services.AddScoped<IPatientRepository, PatientSqlRepository>();
builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionSqlRepository>();
builder.Services.AddScoped<IPrescriptionItemRepository, PrescriptionItemRepository>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBillingRepository, BillingRepository>();

// Services
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IPrescriptionItemService, PrescriptionItemService>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBillingService, BillingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
