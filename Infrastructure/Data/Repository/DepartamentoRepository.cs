using Domain;

namespace Infrastructure.Data.Repository

public class DepartamentoRepository : IDepartamentoRepository
{
        public Task TaskAsync(Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Departamento>> GetAllAsync()
        {
            return await Task.FromResult(
                new List<Departamento>
                {
                    new() { Id = 1, Nombre = "Departamento 1" },
                    new() { Id = 2, Nombre = "Departamento 2" },
                    new() { Id = 3, Nombre = "Departamento 3" }
                });
        }

        public Task<Departamento> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
}
      