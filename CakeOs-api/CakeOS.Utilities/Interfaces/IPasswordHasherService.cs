using CakeOS.Utilities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOS.Utilities.Interfaces
{
    public interface IPasswordHasherService
    {
        /// <summary>
        /// Genera el hash a persistir para una contraseña en texto plano.
        /// Usar en creación de usuario, cambio de contraseña (CU-05)
        /// y en el flujo de rehash-on-login.
        /// </summary>
        string Hash(string password);

        /// <summary>
        /// Verifica una contraseña contra el valor almacenado en base de datos.
        /// Si el valor almacenado resulta ser texto plano legacy y coincide,
        /// devuelve SuccessRehashNeeded para que el llamador actualice el hash.
        /// </summary>
        PasswordVerificationStatus Verify(string storedValue, string providedPassword);
    }
}
