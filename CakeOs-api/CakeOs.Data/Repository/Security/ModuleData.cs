using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.SecurityData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Módulo.
/// Proporciona operaciones CRUD básicas para la gestión de módulos.
/// </summary>
public class ModuleData : DataBase<Module>, IModuleRepository
{
    private readonly ApplicationDbContext _context;

    public ModuleData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
