using CakeOs.Data.Interfaz.IParameterData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;

namespace CakeOs.Data.Repository.ParameterData
{
    /// <summary>
    /// Implementación del repositorio de datos para la entidad Tipo.
    /// Proporciona operaciones CRUD básicas para la gestión de tipos de productos.
    /// </summary>
    public class TypeData : Data<Types>, ITypeData
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa una nueva instancia del repositorio de tipos.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public TypeData(ApplicationDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
