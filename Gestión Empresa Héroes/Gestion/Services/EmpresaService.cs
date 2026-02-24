using Gestion.Config;
using Gestion.Exceptions;
using Gestion.Models;
using Gestion.Repositories;
using Gestion.Validators;

namespace Gestion.Services;

public class EmpresaService(IHeroeRepository heroeRepository, IValidator<Heroe> heroeValidator): IEmpresaService {
    
    /// <inheritdoc cref="IEmpresaService.SaveHeroe" />
    public Heroe SaveHeroe(Heroe h) {
        
        var errores = heroeValidator.Validar(h);
        if (errores.Any()) throw new HeroeExceptions.Validation(errores);
        
        return heroeRepository.Create(h) ?? throw new HeroeExceptions.AlreadyExists(h.Id);
    }
    
    /// <inheritdoc cref="IEmpresaService.GetAllHeroes" />
    public IEnumerable<Heroe> GetAllHeroes() => heroeRepository.GetAll();
    
    /// <inheritdoc cref="IEmpresaService.GetHeroeById" />
    public Heroe GetHeroeById(int id) => heroeRepository.GetById(id) ?? throw new HeroeExceptions.NotFound(id);
    
    /// <inheritdoc cref="IEmpresaService.UpdateHeroe" />
    public Heroe UpdateHeroe(int id, Heroe h) {
        
        var errores = heroeValidator.Validar(h);
        if (errores.Any()) throw new HeroeExceptions.Validation(errores);

        return heroeRepository.Update(id, h) ?? throw new HeroeExceptions.NotFound(id);
    }
    
    /// <inheritdoc cref="IEmpresaService.DeleteHeroe" />
    public Heroe DeleteHeroe(int id) => heroeRepository.Delete(id) ?? throw new HeroeExceptions.NotFound(id);
    
    /// <inheritdoc cref="IEmpresaService.GetAllOrderByLevel" />
    public IEnumerable<Heroe> GetAllOrderByLevel() => 
        heroeRepository.GetAll()
            .OrderByDescending(h => h.Nivel)
            .ThenBy(h => h.Experiencia);
    
    /// <inheritdoc cref="IEmpresaService.GetAllOrderByPower" />
    public IEnumerable<Heroe> GetAllOrderByPower() =>
        heroeRepository.GetAll()
            .OrderByDescending(h => h.CalcularPoder())
            .ThenBy(h => h.Nivel);

    /// <inheritdoc cref="IEmpresaService.DescansarHeroe" />
    public void DescansarHeroe(int id) {
        var h = GetHeroeById(id);
        if (h.Energia >= HeroesConfig.EnergiaMaxima) {
            throw new HeroeExceptions.VidaExcesiva();
        }
        heroeRepository.DescansarHeroe(h);
    }
    
    /// <inheritdoc cref="IEmpresaService.GetPoderHeroe" />
    public int GetPoderHeroe(int id) {
        var heroe = GetHeroeById(id);
        return heroeRepository.CalcularPoder(heroe);
    }
}