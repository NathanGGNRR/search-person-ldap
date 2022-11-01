using System;
using System.Runtime.Serialization;

namespace Diiage.Directory.Core.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public ErrorType Type { get; set; }

        public BusinessException(ErrorType errorType, Exception innerException) : base(errorType.ToString(), innerException)
        {
            Type = errorType;
        }

        public BusinessException(ErrorType errorType) : this(errorType, null)
        { }

        protected BusinessException(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            Type = (ErrorType)info.GetValue(nameof(Type), typeof(ErrorType));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("Type", Type);

            base.GetObjectData(info, context);
        }
    }
}
