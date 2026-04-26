using CakeOs.Data.Interfaz.IParameterData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;

namespace CakeOs.Data.Repository.ParameterData
{
    /// <summary>
    /// Implementación del repositorio de datos para la entidad Forma.
    /// Proporciona operaciones CRUD básicas para la gestión de formas de productos.
    /// </summary>
    public class ShapeData : Data<Shape>, IShapeData
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa una nueva instancia del repositorio de formas.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public ShapeData(ApplicationDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
