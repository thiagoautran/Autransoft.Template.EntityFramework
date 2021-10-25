using System;
using System.Linq;
using Autransoft.Template.EntityFramework.Lib.Loggings;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Autransoft.Template.EntityFramework.Lib.Exceptions
{
    [Serializable]
    public class DbException : Exception
    {
        public string Query { get; set; }
        public string JsonEntity { get; set; }

        internal bool? UseNewtonsoft { get; private set; }

        public string Logging { get { return this.LogError(); } }

        public DbException ConvertWithNewtonsoft()
        {
            UseNewtonsoft = true;
            return this;
        }

        public DbException(Exception exception, IQueryable<object> query) : base(exception.Message, exception)
        {
            Query = query?.ToQueryString();
            JsonEntity = null;
        }

        public DbException(Exception exception, string query) : base(exception.Message, exception)
        {
            Query = query;
            JsonEntity = null;
        }

        public DbException(Exception exception, object entity) : base(exception.Message, exception)
        {
            Query = null;

            if(UseNewtonsoft != null && UseNewtonsoft.Value)
                JsonEntity = JsonConvert.SerializeObject(entity);
            else
                JsonEntity = System.Text.Json.JsonSerializer.Serialize(entity);
        }
    }
}