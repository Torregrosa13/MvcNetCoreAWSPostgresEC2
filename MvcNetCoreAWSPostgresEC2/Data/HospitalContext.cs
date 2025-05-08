using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Models;

namespace MvcNetCoreAWSPostgresEC2.Data
{
    public class HospitalContext:DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) 
            : base(options){ }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
