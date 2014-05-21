﻿using Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.Client.Demo.Log
{
    public class SchemaUpdater: AbstractConfigurationProcessor
    {
        public SchemaUpdater()
            : base("LOG")
        {
        }

        protected override void Process(global::NHibernate.Cfg.Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            schemaUpdate.Execute(true, true);
        }
    }
}
