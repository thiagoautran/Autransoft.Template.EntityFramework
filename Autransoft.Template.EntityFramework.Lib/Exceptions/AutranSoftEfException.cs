using System;
using System.Linq;
using Autransoft.Template.EntityFramework.Lib.Loggings;
using Microsoft.EntityFrameworkCore;

namespace Autransoft.Template.EntityFramework.Lib.Exceptions
{
    [Serializable]
    public class AutranSoftEfException : Exception
    {
        public string Query { get; set; }
        public string JsonEntity { get; set; }

        internal bool? UseNewtonsoft { get; private set; }

        public string LogError { get { return this.LogError(); } }

        public AutranSoftEfException ConvertWithNewtonsoft()
        {
            UseNewtonsoft = true;
            return this;
        }

        public AutranSoftEfException(Exception exception, IQueryable<object> query) : base(exception.Message, exception)
        {
            Query = query?.ToQueryString();
            JsonEntity = null;
        }

        public AutranSoftEfException(Exception exception, string query) : base(exception.Message, exception)
        {
            Query = query;
            JsonEntity = null;
        }

        public AutranSoftEfException(Exception exception, object entity) : base(exception.Message, exception)
        {
            Query = null;
            JsonEntity = System.Text.Json.JsonSerializer.Serialize(entity);
        }
    }
}