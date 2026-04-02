using CakeOs.Business.Base;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Interfaces.Parameter
{
    public interface IImageServices : IServices<ImageListDto,ImageUpdateDto,Image>
    {
    }
}
