using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Relleno.
/// Proporciona operaciones CRUD básicas para la gestión de rellenos de productos.
/// </summary>
public class FilledData : DataBase<Filled>, IFilledRepository
{
    private readonly ApplicationDbContext _context;

    public FilledData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
