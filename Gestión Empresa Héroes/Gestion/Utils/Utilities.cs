using Gestion.Enums;

namespace Gestion.Utils;

public abstract class Utilities {
    public static void ImprimirMenu() {
        WriteLine("----- MENÚ PRINCIPAL -----");
        WriteLine($"{(int)OpcionesMenuPrincipal.CrearHeroe}.- Crear Héroe.");
        WriteLine($"{(int)OpcionesMenuPrincipal.ObtenerHeroes}.- Obtener Héroes.");
        WriteLine($"{(int)OpcionesMenuPrincipal.BuscarHeroePorId}.- Buscar Héroe por ID.");
        WriteLine($"{(int)OpcionesMenuPrincipal.ActualizarHeroe}.- Actualizar Héroe.");
        WriteLine($"{(int)OpcionesMenuPrincipal.BorrarHeroe}.- Borrar Héroe.");
        WriteLine("--------------------------");
        WriteLine($"{(int)OpcionesMenuPrincipal.CrearMision}.- Crear Misión.");
        WriteLine($"{(int)OpcionesMenuPrincipal.ObtenerMision}.- Obtener Misiones.");
        WriteLine($"{(int)OpcionesMenuPrincipal.BuscarMisionPorId}.- Buscar  por ID.");
        WriteLine($"{(int)OpcionesMenuPrincipal.ActualizarMision}.- Actualizar Misión.");
        WriteLine($"{(int)OpcionesMenuPrincipal.BorrarMision}.- Borrar Misión.");
        WriteLine("--------------------------");
        WriteLine($"{(int)OpcionesMenuPrincipal.SimularMision}.- Simular Misión.");
        WriteLine($"{(int)OpcionesMenuPrincipal.DescansarHeroe}.- Descansar Héroe.");
        WriteLine($"{(int)OpcionesMenuPrincipal.AsignarHeroeAMision}.- Asignar Héroe a Misión.");
        WriteLine($"{(int)OpcionesMenuPrincipal.Salir}.- Salir");
    }
}