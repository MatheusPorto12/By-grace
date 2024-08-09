using ByGrace.IRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace ByGrace.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly IRepositorioTrabalho Contexto;

        public ControllerBase(IRepositorioTrabalho repositorio)
        {
            Contexto = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }
    }
}
