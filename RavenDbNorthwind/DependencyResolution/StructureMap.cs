// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructureMap.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using ShortBus;
using StructureMap;
using StructureMap.Pipeline;

namespace RavenDbNorthwind.DependencyResolution {
    public static class StructureMap {
        public static IContainer Configure() {
            ObjectFactory.Initialize(x =>
            {
                var perHttpRequest = new HttpContextLifecycle();

                x.For<IDocumentStore>().LifecycleIs(new SingletonLifecycle()).Use(ConfigureDocumentStore);
                x.For<IDocumentSession>().LifecycleIs(perHttpRequest).Use(ctx => ctx.GetInstance<IDocumentStore>().OpenSession());

                x.Scan(y =>
                {
                    y.AssemblyContainingType<IMediator>();
                    y.TheCallingAssembly();
                    y.WithDefaultConventions();
                    y.LookForRegistries();
                    y.AddAllTypesOf<Controller>();
                    y.AddAllTypesOf(typeof(ValueResolver<,>));
                    y.AddAllTypesOf(typeof (IQueryHandler<,>));
                    y.AddAllTypesOf(typeof (ICommandHandler<>));
                });
            });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));

            return ObjectFactory.Container;
        }

        private static IDocumentStore ConfigureDocumentStore()
        {
            var store = new DocumentStore { ConnectionStringName = "RavenDb" };
            store.Initialize();
            IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), store);
            return store;
        }
    }
}