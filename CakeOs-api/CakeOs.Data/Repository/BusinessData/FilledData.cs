using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Relleno.
/// Proporciona operaciones CRUD básicas para la gestión de rellenos de productos.
/// </summary>
public class FilledData : Data<Filled>, IFilledData
{
    private readonly ApplicationDbContext _context;

    public FilledData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
