using Gestion.Enums;

namespace Gestion.Config;

public static class HeroesConfig {
    public const int EnergiaRestauraDescansar = 5;
    public const int EnergiaMinima = 10;
    public const int EnergiaMaxima = 200;
    
    public const int MultiplicadorNivelCalcPoder = 100;
    public const int NivelMaximo = 10;
    
    public const int DificultadMinima = 1;
    public const int DificultadMaxima = 10;
    
    public const int FuerzaMinima = 1;
    public const int FuerzaMaxima = 50;

    public const int AgilidadMinima = 1;
    public const int AgilidadMaxima = 50;
    
    public static readonly string RegexOpcionMenuPrincipal = @$"^[?:{(int)OpcionesMenuPrincipal.Salir}-{(int)OpcionesMenuPrincipal.ActualizarMision}]|1[0-3]$";
    public static readonly string RegexOpcionMenuOrdenacion = @$"^[?:{(int)OpcionObtenerHeroes.Salir}-{(int)OpcionObtenerHeroes.ObtenerPorPoder}]$";
    public const string RegexId = @"^\d{1,}$";

    public static int[] UmbralesNivel = [10, 25, 50, 100, 150, 225, 325, 450, 600, 800, 0];
}