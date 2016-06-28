using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace SPV.DA
{
    internal class Database : IDisposable
    {
        DbConnection connection;
        DbProviderFactory factory;
        DbCommand command;
      
        public Database()
        {
            factory = DbProviderFactories.GetFactory(DataBaseHelper.GetDbProvider());
        }

        public void Open()
        {
            connection = factory.CreateConnection();
            connection.ConnectionString = DataBaseHelper.GetDbConnectionString();
            try
            {
                connection.Open();
            }
            catch
            {
                throw;
            }
        }

        public void Close()
        {
            connection.Close();
        }

        public string CommandText
        {
            set
            {
                if (command == null)
                {
                    command = factory.CreateCommand();

                }
                if (connection == null)
                {
                    this.Open();
                }
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = value;
                //command.CommandTimeout = 0;
            }
        }

        public string ProcedureName
        {
            set
            {
                if (command == null)
                {
                    command = factory.CreateCommand();
                }
                if (connection == null)
                {
                    this.Open();
                }
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = value;
                //command.CommandTimeout = 0;
            }
        }

        public void AddParameter(string parameterName, DbType parameterType, ParameterDirection parameterDirection, Object parameterValue)
        {
            if (command != null)
            {
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = parameterName;
                parameter.DbType = parameterType;
                parameter.Direction = parameterDirection;
                parameter.Value = parameterValue;
                parameter.SourceColumnNullMapping = true;
                command.Parameters.Add(parameter);
                //command.CommandTimeout = 0;
            }
        }

        public IDataReader GetDataReader()
        {
            return command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection);
        }

        public int Execute()
        {
            command.CommandTimeout = 0;
            return command.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            command.CommandTimeout = 0;
            return command.ExecuteScalar();
        }

        ~Database()
        {
            this.Dispose();
        }

        #region IDisposable Members
        public void Dispose()
        {
            connection = null;
            command = null;
            factory = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }
        #endregion
    }
}