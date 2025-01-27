﻿using System.Configuration;
using System.Data.EntityClient;

namespace DesignExplorer.DataAccess
{
    public class ConnectionHelper
    {
        public string DbConnectionStringKey
        {
            get
            {
                return ConfigurationManager.AppSettings["DbConnectionStringKey"];
            }
        }
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DbConnectionStringKey].ConnectionString;
            }
        }
        static string _entityConnection = null;
        public string EntityConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_entityConnection))
                {
                    EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                    entityBuilder.Provider = "System.Data.SqlClient";
                    entityBuilder.ProviderConnectionString = ConnectionString;
                    entityBuilder.Metadata = @"res://*/OnBoarding.csdl|res://*/OnBoarding.ssdl|res://*/OnBoarding.msl";
                    _entityConnection = entityBuilder.ToString();
                }
                return _entityConnection;
            }
        }
    }
}
