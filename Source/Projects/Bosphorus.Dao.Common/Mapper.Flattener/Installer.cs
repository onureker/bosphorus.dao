﻿using Bosphorus.Container.Castle.Registration.Handler.Generic.Implementation;
using Bosphorus.Container.Castle.Registration.Handler.Generic.Selector;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Common.Mapper.Core.Decoration.Cache;
using Bosphorus.Dao.Common.Mapper.Flattener.Decoration.Cache;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Mapper.Flattener
{
    public class Installer : AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store,
            FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof (IFlattener<,>))
                    .WithService
                    .FromInterface(),

                Component
                    .For(typeof (IFlattener<,>))
                    .ImplementedBy(typeof (ListFlattener<,>), GenericImplementationArgs.Transformed.ListTrimmed, GenericService.AllArgs.IsList),

                Component
                    .For(typeof (IFlattener<,>))
                    .ImplementedBy(typeof (EchoFlattener<>), GenericImplementationArgs.Distinct, GenericService.AllArgs.IsStruct),

                Component
                    .For(typeof (IFlattener<,>))
                    .ImplementedBy(typeof (ValueInjectorFlattener<,>)),

                Component
                    .For(typeof(IFlattener<,>))
                    .ImplementedBy(typeof(CacheDecorator<,>))
                    .IsDefault(),

                Component
                    .For<GenericFlattener>()
                );
        }
    }
}