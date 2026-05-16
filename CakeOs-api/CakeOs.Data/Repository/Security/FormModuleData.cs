using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.SecurityData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Formulario-Módulo.
/// Proporciona operaciones CRUD básicas para la gestión de relaciones entre formularios y módulos.
/// </summary>
public class FormModuleData : DataBase<FormModule>, IFormModuleRepository
{
    private readonly ApplicationDbContext _context;

    public FormModuleData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
