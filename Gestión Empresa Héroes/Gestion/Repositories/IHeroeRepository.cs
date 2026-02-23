using Gestion.Models;
using Gestion.Repositories.Common;

namespace Gestion.Repositories;

public interface IHeroeRepository: ICrudRepository<int, Heroe> {}