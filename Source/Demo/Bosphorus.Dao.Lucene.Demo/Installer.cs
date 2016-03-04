﻿using Bosphorus.Common.Api.Container;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Lucene.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene.Demo
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof(IDao<>))
                    .ImplementedBy(typeof(LuceneDao<>))
            );
        }
    }
}
