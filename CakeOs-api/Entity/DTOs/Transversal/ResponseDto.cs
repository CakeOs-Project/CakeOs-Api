using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Transversal
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ResponseDto Ok(string message = "Operación exitosa")
            => new() { Success = true, Message = message };

        public static ResponseDto Fail(string message)
            => new() { Success = false, Message = message };
    }
}
