using Ardalis.Specification;

namespace Application.Interfaces
{
    /// <summary>
    /// interfaz de repositorio para ejecucion de commandos CQRS
    /// </summary>
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class { }

    /// <summary>
    /// esto es para lectura repositorio para ejecucion de Queries CQRS
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class { }

}
