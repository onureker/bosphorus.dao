﻿using Bosphorus.Dao.NHibernate.Configuration.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.Demo.NHibernate.DTC.Log
{
    public class PersistenceConfigurerProvider : AbstractPersistenceConfigurerProvider
    {
        public PersistenceConfigurerProvider()
            : base("LOG")
        {
        }

        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            return
                SQLiteConfiguration
                    .Standard
                    .UsingFile(@".\Log.db3")
                    .ShowSql()
                    .FormatSql();
        }
    }
}
