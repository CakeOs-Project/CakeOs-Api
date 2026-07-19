using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOS.Utilities.Provider
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        int? RolId { get; }
        string? RolName { get; }
        string? FullName { get; }
        string? Email { get; }

        /// <summary>
        /// Lanza si no hay usuario autenticado en el contexto actual.
        /// Usar en servicios de Business que requieren un usuario válido
        /// como precondición (ej. crear factura, registrar pago).
        /// </summary>
        int RequireUserId();
    }
}
