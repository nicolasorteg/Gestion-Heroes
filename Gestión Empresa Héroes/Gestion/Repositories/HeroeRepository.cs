using Gestion.Models;

namespace Gestion.Repositories;

public class HeroeRepository: IHeroeRepository {

    // singleton para instancia unica
    private static HeroeRepository? _instance;
    public static HeroeRepository GetInstance() {
        return _instance ??= new HeroeRepository();
    }
    
    // listado de heroes
    private readonly List<Heroe> _heroes = [];

    
    private static int _idCounter;
    
    private HeroeRepository() {
        InitMiembros();
    }

    private void InitMiembros() {
        var miembrosIniciales = HeroeFactory.DemoHeroes();
        foreach (var h in miembrosIniciales) Create(h);
    }
    
    private static int GetNextId() => ++_idCounter;


    /// <inheritdoc cref="IHeroeRepository.GetAll" />
    public IEnumerable<Heroe> GetAll() => _heroes;
    
    /// <inheritdoc cref="IHeroeRepository.GetById" />
    public Heroe? GetById(int id) => _heroes.FirstOrDefault(h => h.Id == id);
    
    /// <inheritdoc cref="IHeroeRepository.Create" />
    public Heroe? Create(Heroe entity) {
        if (GetById(entity.Id) != null) return null;
        
        var nuevoConId = entity with { Id = GetNextId() };
        _heroes.Add(nuevoConId);
        return entity;
    }
    
    /// <inheritdoc cref="IHeroeRepository.Update" />
    public Heroe? Update(int id, Heroe entity) {
        var existente = GetById(id);
        if (existente == null) return null;
        
        existente.Nombre = entity.Nombre;
        existente.Nivel = entity.Nivel;
        existente.Energia = entity.Energia;
        existente.Experiencia = entity.Experiencia;
        existente.Rareza = entity.Rareza;
        
        return existente;
    }
    
    /// <inheritdoc cref="IHeroeRepository.Delete" />
    public Heroe? Delete(int id) {
        var heroe = GetById(id);
        if (heroe != null) {
            _heroes.Remove(heroe);
        }
        return heroe;
    }
}