using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace HSMS.API.Database
{
    public class DatabaseManager : IDatabaseManager
    {
        private NpgsqlConnection _connection;
        private NpgsqlCommand _command;

        public DatabaseManager(IConfiguration configuration)
        {
            ConnectionHelper.ConnectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? string.Empty;
        }

        public void CreateParameters(int parameterCount)
        {
            _command = new NpgsqlCommand();

            if (parameterCount > 0)
            {
                _command.Parameters.Clear();
            }
        }


        public void AddParameter(string parameterName, object? value)
        {
            _command.Parameters.AddWithValue(
                parameterName,
                value ?? DBNull.Value);
        }


        public void OpenConnection()
        {
            _connection = new NpgsqlConnection(
                ConnectionHelper.ConnectionString);

            _connection.Open();

            _command.Connection = _connection;
        }

        public IDataReader ExecuteReader(
            CommandType commandType,
            string commandText)
        {
            if (commandType == CommandType.StoredProcedure)
            {
                // PostgreSQL row-returning routines are functions.
                // Execute the function through SELECT.
                _command.CommandType = CommandType.Text;
                _command.CommandText = $"SELECT * FROM {commandText}()";
            }
            else
            {
                _command.CommandType = commandType;
                _command.CommandText = commandText;
            }

            return _command.ExecuteReader();
        }

        public void CloseConnection()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }

                _connection.Dispose();
                _connection = null;
            }

            if (_command != null)
            {
                _command.Dispose();
                _command = null;
            }
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            _command.CommandType = commandType;
            _command.CommandText = commandText;

            return _command.ExecuteNonQuery();
        }

    }
}