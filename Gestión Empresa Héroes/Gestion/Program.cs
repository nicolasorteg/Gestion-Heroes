using System.Text;
using System.Text.RegularExpressions;
using Gestion.Config;
using Gestion.Enums;
using Gestion.Exceptions;
using Gestion.Repositories;
using Gestion.Services;
using Gestion.Utils;
using Gestion.Validators;
using Serilog;

// daw's template
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Logs/log.log", rollingInterval: RollingInterval.Day).CreateLogger();
Title = "Gestión Empresa Héroes";
OutputEncoding = Encoding.UTF8;
Clear();
Main();
Log.CloseAndFlush();
WriteLine("\n👋 Presiona una tecla para salir...");
ReadKey();
return;

void Main() {
   
    var service = new EmpresaService(HeroeRepository.GetInstance(), new HeroeValidator());
    
    WriteLine("--- 🦸 BIENVENIDO A LA EMPRESA DE HÉROES 🦸 ---");
    WriteLine("-----------------------------------------------");
    OpcionesMenuPrincipal opcion;
    do {
        Utilities.ImprimirMenu();
        opcion = (OpcionesMenuPrincipal)int.Parse(ValidarDato("- Opción elegida -> ", HeroesConfig.RegexOpcionMenuPrincipal));

        try {
            switch (opcion) {
                case OpcionesMenuPrincipal.Salir: break;
                case OpcionesMenuPrincipal.CrearHeroe: CrearHeroe(service); break;
                case OpcionesMenuPrincipal.ObtenerHeroes: ObtenerHeroes(service); break;
                case OpcionesMenuPrincipal.BuscarHeroePorId: BuscarHeroePorId(service); break;
                case OpcionesMenuPrincipal.ActualizarHeroe: ActualizarHeroe(service);break;
                case OpcionesMenuPrincipal.BorrarHeroe: BorrarHeroe(service); break;
                //case OpcionesMenuPrincipal.CrearMision: CrearMision(service); break;
                //case OpcionesMenuPrincipal.ObtenerMision: ObtenerMision(service); break;
                //case OpcionesMenuPrincipal.BuscarMisionPorId: BuscarMisionPorId(service); break;
                //case OpcionesMenuPrincipal.ActualizarMision: ActualizarMision(service); break;
                //case OpcionesMenuPrincipal.BorrarMision: BorrarMision(service); break;
                //case OpcionesMenuPrincipal.SimularMision: SimularMision(service); break;
                case OpcionesMenuPrincipal.DescansarHeroe: DescansarHeroe(service);break;
                case OpcionesMenuPrincipal.CalcularPoderHeroe: CalcularPoder(service); break;
                //case OpcionesMenuPrincipal.AsignarHeroeAMision: AsignarHeroeAMision(service); break;
                default: // si se entra aquí ha fallado la validacion de la opcion
                    WriteLine($"⚠️ Opción inválida. Introduzca una de las {(int)OpcionesMenuPrincipal.AsignarHeroeAMision} opciones posibles.");
                    break;
            } 
        } 
        catch (HeroeExceptions.Validation ex) {
            WriteLine(ex.Message);
            foreach (var error in ex.Errores) WriteLine($"  -> {error}");
        } 
        catch (HeroeExceptions.NotFound ex) {
            WriteLine(ex.Message);
        }
        catch (HeroeExceptions.AlreadyExists ex) {
            WriteLine(ex.Message);
        }
        catch (HeroeExceptions.VidaExcesiva ex) {
            WriteLine(ex.Message);
        }
        catch (Exception) {
            WriteLine("⚠️ Ha ocurrido un error inesperado.");
        }
        
    } while (opcion != OpcionesMenuPrincipal.Salir);
}


// ----------- opciones
void CrearHeroe(EmpresaService service) {
    throw new NotImplementedException();
}

void ObtenerHeroes(EmpresaService service) {
    Utilities.ImprimirMenuObtenerHeroes();
    var opcion = (OpcionObtenerHeroes)int.Parse(ValidarDato("- Opción elegida -> ", HeroesConfig.RegexOpcionMenuOrdenacion));
    switch (opcion) {
        case OpcionObtenerHeroes.Salir: break;
        case OpcionObtenerHeroes.ObtenerPorId: 
            var heroesId = service.GetAllHeroes();
            foreach (var h in heroesId) WriteLine(h);
            break;
        case OpcionObtenerHeroes.ObtenerPorNivel:
            var heroesLvl = service.GetAllOrderByLevel();
            foreach (var h in heroesLvl) WriteLine(h);
            break;
        case OpcionObtenerHeroes.ObtenerPorPoder:
            var heroesPoder = service.GetAllOrderByPower();
            foreach (var h in heroesPoder) WriteLine(h);
            break;
        default: // si se entra aquí ha fallado la validacion de la opcion
            WriteLine($"⚠️ Opción inválida. Introduzca una de las {(int)OpcionObtenerHeroes.ObtenerPorPoder} opciones posibles.");
            break;
    }
}

void BuscarHeroePorId(EmpresaService service) {
    var id = int.Parse(ValidarDato("- ID del Héroe: ", HeroesConfig.RegexId));
    var h = service.GetHeroeById(id);
    WriteLine($"🔎✅  Héroe encontrado:\n-----------------------\n{h}");
}

void ActualizarHeroe(EmpresaService service) {
    var id = int.Parse(ValidarDato("- ID del Héroe a actualizar: ", HeroesConfig.RegexId));
    var actual = service.GetHeroeById(id);
}

void BorrarHeroe(EmpresaService service) {
    var id = int.Parse(ValidarDato("- ID del Héroe a borrar: ", HeroesConfig.RegexId));
    var borrado = service.DeleteHeroe(id);
    WriteLine($"\n🗑️ Héroe {borrado.Nombre} eliminado correctamente.");
}

void DescansarHeroe(EmpresaService service) {
    var id = int.Parse(ValidarDato("- ID del Héroe para descansar: ", HeroesConfig.RegexId));
    service.DescansarHeroe(id);
}



void CalcularPoder(EmpresaService service) {
    var id = int.Parse(ValidarDato("- ID del Héroe para descansar: ", HeroesConfig.RegexId));
    var poder = service.GetPoderHeroe(id);
    WriteLine($"🧨 Poder Cálculado -> {poder}");
}





string ValidarDato(string msg, string rgx) {
    string input;
    var regex = new Regex(rgx);
    do {
        Write($"{msg} ");
        input = ReadLine()?.Trim() ?? "-1";
    } while (!regex.IsMatch(input));
    WriteLine();
    return input;
}