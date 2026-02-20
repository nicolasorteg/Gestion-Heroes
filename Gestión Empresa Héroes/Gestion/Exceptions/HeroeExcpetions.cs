namespace Gestion.Exceptions;

public class HeroeExcpetions(string message): DomainException(message) {
    
    public sealed class NotFound(int id): HeroeExcpetions($"❌ No se ha encontrado ningún héroe con ID: {id}");

    public sealed class Validation(IEnumerable<string> errores) : HeroeExcpetions($"❌ Se han detectado errores de validación en la entidad.") {
        public IEnumerable<string> Errores { get; init; } = errores;
    }
    

    public sealed class NotFound(int id): HeroeExcpetions($"❌ No se ha encontrado ningún héroe con ID: {id}");

    public sealed class NotFound(int id): HeroeExcpetions($"❌ No se ha encontrado ningún héroe con ID: {id}");

}