using Gestion.Config;

namespace Gestion.Models;

public record HeroeAgil: Heroe {
    public required int Agilidad { get; set; }
    
    public override int CalcularPoder() => Energia + Nivel * HeroesConfig.MultiplicadorNivelCalcPoder + Agilidad + (int)Rareza;

    public override string ToString() => base.ToString() + $"  |  Agilidad: {Agilidad}";
}