﻿using System;
using System.Linq;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.NHibernate.Session;
using NHibernate.Linq;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Common
{
    public class AccountBuilder : AbstractBuilder<Account, AccountBuilder>
    {
        public static AccountBuilder Default
        {
            get { return Empty.WithName("Maaş Hesabı"); }
        }

        public static AccountBuilder FromDatabaseWithChildren()
        {
            ISessionProvider sessionProvider = BuildSessionProvider();
            Console.WriteLine("Reading object from database to session ----------");
            ISession session = sessionProvider.Open<NHibernateStatefulSession>(SessionAlias.Default, SessionScope.Application);
            Account model = dao.Value.Query(session).Fetch(x => x.Customer).ThenFetch(x => x.CustomerType).First();
            sessionProvider.Close<NHibernateStatefulSession>(SessionAlias.Default, SessionScope.Application);
            Console.WriteLine("Reading object from database to session ----------");

            AccountBuilder builder = new AccountBuilder();
            builder.model = model;
            return builder;
        }

        public AccountBuilder WithId(int id)
        {
            model.Id = id;
            return this;
        }

        public AccountBuilder WithName(string name)
        {
            model.Name = name;
            return this;
        }

        public AccountBuilder WithCustomer(Customer customer)
        {
            model.Customer = customer;
            return this;
        }
    }
}
