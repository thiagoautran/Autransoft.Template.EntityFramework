using System;
using System.Linq;
using Autransoft.Template.EntityFramework.PostgreSQL.Lib.Loggings;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Autransoft.Template.EntityFramework.PostgreSQL.Lib.Exceptions
{
    [Serializable]
    public class AutranSoftEntityFrameworkException : Exception
    {
        public string Query { get; set; }
        public string JsonEntity { get; set; }

        internal bool? UseNewtonsoft { get; private set; }

        public string Logging { get { return this.LogError(); } }

        public AutranSoftEntityFrameworkException ConvertWithNewtonsoft()
        {
            UseNewtonsoft = true;
            return this;
        }

        public AutranSoftEntityFrameworkException(Exception exception, IQueryable<object> query) : base(exception.Message, exception)
        {
            Query = query?.ToQueryString();
            JsonEntity = null;
        }

        public AutranSoftEntityFrameworkException(Exception exception, string query) : base(exception.Message, exception)
        {
            Query = query;
            JsonEntity = null;
        }

        public AutranSoftEntityFrameworkException(Exception exception, object entity) : base(exception.Message, exception)
        {
            Query = null;

            if(UseNewtonsoft != null && UseNewtonsoft.Value)
                JsonEntity = JsonConvert.SerializeObject(entity);
            else
                JsonEntity = System.Text.Json.JsonSerializer.Serialize(entity);
        }
    }
}