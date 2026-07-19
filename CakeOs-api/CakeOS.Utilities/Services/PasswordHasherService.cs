using CakeOS.Utilities.Enum;
using CakeOS.Utilities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOS.Utilities.Services
{
    public sealed class PasswordHasherService : IPasswordHasherService
    {
        // Tipo interno solo para satisfacer el genérico de PasswordHasher<T>.
        // Nunca se usa su contenido.
        private sealed class HasherContext { }

        private readonly PasswordHasher<HasherContext> _hasher = new();
        private static readonly HasherContext Context = new();

        public string Hash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(password));

            return _hasher.HashPassword(Context, password);
        }

        public PasswordVerificationStatus Verify(string storedValue, string providedPassword)
        {
            if (string.IsNullOrWhiteSpace(storedValue) || string.IsNullOrWhiteSpace(providedPassword))
                return PasswordVerificationStatus.Failed;

            // Los hashes de Identity son Base64 válido (marcador de versión + salt + subkey).
            // Si el valor almacenado no tiene esa forma, se asume texto plano legacy
            // (caso real hoy en DataInit.sql: 'admin123', '123456').
            if (!LooksLikeIdentityHash(storedValue))
            {
                return storedValue == providedPassword
                    ? PasswordVerificationStatus.SuccessRehashNeeded
                    : PasswordVerificationStatus.Failed;
            }

            try
            {
                var result = _hasher.VerifyHashedPassword(Context, storedValue, providedPassword);

                return result switch
                {
                    PasswordVerificationResult.Success => PasswordVerificationStatus.Success,
                    PasswordVerificationResult.SuccessRehashNeeded => PasswordVerificationStatus.SuccessRehashNeeded,
                    _ => PasswordVerificationStatus.Failed
                };
            }
            catch (FormatException)
            {
                // Base64 válido mal formado que no corresponde a un hash real de Identity.
                return storedValue == providedPassword
                    ? PasswordVerificationStatus.SuccessRehashNeeded
                    : PasswordVerificationStatus.Failed;
            }
        }

        private static bool LooksLikeIdentityHash(string value)
        {
            Span<byte> buffer = value.Length <= 512 ? stackalloc byte[value.Length] : new byte[value.Length];
            return Convert.TryFromBase64String(value, buffer, out var bytesWritten) && bytesWritten > 1;
        }
    }
}
