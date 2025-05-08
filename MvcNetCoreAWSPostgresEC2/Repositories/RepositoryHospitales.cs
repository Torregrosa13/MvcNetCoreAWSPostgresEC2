using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Data;
using MvcNetCoreAWSPostgresEC2.Models;

namespace MvcNetCoreAWSPostgresEC2.Repositories
{
    public class RepositoryHospitales
    {
        private  HospitalContext context;
        public RepositoryHospitales(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }
        public async Task<Departamento> GetDepartamentoByIdAsync(int id)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == id);
        }
        public async Task AddDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }
        public async Task DeleteDepartamentoAsync(int id)
        {
            var departamento = await GetDepartamentoByIdAsync(id);
            if (departamento != null)
            {
                this.context.Departamentos.Remove(departamento);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
