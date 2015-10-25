﻿using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Common.Mapper.Core.Decoration.Cache;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Mapper.Core
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<PerCallContextCache>()
                    .LifeStyle.Singleton.Start(),

                Component
                    .For<GenericMapper>()
            );
        }
    }

}
