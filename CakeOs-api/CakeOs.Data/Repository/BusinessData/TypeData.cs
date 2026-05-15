using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Parameter;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.BusinessData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Tipo.
/// Proporciona operaciones CRUD básicas para la gestión de tipos de productos.
/// </summary>
public class TypeData : DataBase<Types>, ITypeRepository
{
    private readonly ApplicationDbContext _context;

    public TypeData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
