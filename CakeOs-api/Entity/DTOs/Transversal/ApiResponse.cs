namespace CakeOs.Entity.DTOs.Transversal
{
    public sealed class ApiResponse
    {
        public bool Success { get; init; }
        public int StatusCode { get; init; }
        public string Message { get; init; } = string.Empty;
        public object? Data { get; init; }
        public IDictionary<string, string[]>? Errors { get; init; }

        public static ApiResponse Ok(int statusCode, object? data = null, string message = "Operación realizada correctamente") =>
            new() { Success = true, StatusCode = statusCode, Message = message, Data = data };

        public static ApiResponse Fail(int statusCode, string message, IDictionary<string, string[]>? errors = null) =>
            new() { Success = false, StatusCode = statusCode, Message = message, Errors = errors };
    }
}
