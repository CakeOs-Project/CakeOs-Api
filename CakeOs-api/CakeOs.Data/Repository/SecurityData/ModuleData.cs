using CakeOs.Data.Interfaz.ISecurityData;
using CakeOs.Data.Repository.Data;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.SecurityData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Módulo.
/// Proporciona operaciones CRUD básicas para la gestión de módulos.
/// </summary>
public class ModuleData : Data<Module>, IModuleData
{
    private readonly ApplicationDbContext _context;

    public ModuleData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
