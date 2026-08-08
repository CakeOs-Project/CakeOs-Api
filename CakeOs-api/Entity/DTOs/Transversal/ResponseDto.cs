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
        public string Message { get; set; } = string.Empty;
        public ResponseErrorType ErrorType { get; set; }

        public static ResponseDto Ok(string message = "Operación exitosa")
            => new() { Success = true, Message = message, ErrorType = ResponseErrorType.None };

        public static ResponseDto Fail(string message, ResponseErrorType errorType = ResponseErrorType.Validation)
            => new() { Success = false, Message = message, ErrorType = errorType };

        public static ResponseDto NotFound(string message)
            => Fail(message, ResponseErrorType.NotFound);

        public static ResponseDto Conflict(string message)
            => Fail(message, ResponseErrorType.Conflict);
    }

    public enum ResponseErrorType
    {
        None,
        Validation,
        NotFound,
        Conflict,
        Unauthorized,
        Forbidden
    }
}
