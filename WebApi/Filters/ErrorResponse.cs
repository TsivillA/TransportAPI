using System.Collections.Generic;

namespace WebApi.Filters
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }

    public class ErrorModel
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
