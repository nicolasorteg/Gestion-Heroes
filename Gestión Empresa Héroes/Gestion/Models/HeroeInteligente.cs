using Gestion.Config;

namespace Gestion.Models;

public sealed record HeroeInteligente: Heroe {
    public required Agilidades Agilidad { get; set; }
    public enum Agilidades { Baja = 10, Media = 30, Alta = 50 }
    
    public override int CalcularPoder() => Energia + Nivel * HeroesConfig.MultiplicadorNivelCalcPoder + (int)Agilidad + (int)Rareza;
    
    public override string ToString() => base.ToString() + $"  |  Agilidad: {Agilidad}";
}