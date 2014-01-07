using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace College.UserProfile.Core.Exceptions
{
    public class GeneralException : ApplicationException
    {
        public JsonResult exceptionDetails;
        public GeneralException(JsonResult exceptionDetails)
        {
            this.exceptionDetails = exceptionDetails;
        }
        public GeneralException(string message) : base(message) { }
        public GeneralException(string message, Exception inner) : base(message, inner) { }
        protected GeneralException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }

    public class ValidationException : ApplicationException
    {
        public JsonResult exceptionDetails;
        public ValidationException(JsonResult exceptionDetails)
        {
            this.exceptionDetails = exceptionDetails;
        }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception inner) : base(message, inner) { }
        protected ValidationException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }
}
