using System.Data;

namespace HSMS.API.Database
{
    public interface IDatabaseManager
    {
        void CreateParameters(int parameterCount);

        void AddParameter(string parameterName, object? value);


        int ExecuteNonQuery(CommandType commandType, string commandText);

        void OpenConnection();

        IDataReader ExecuteReader(
            CommandType commandType,
            string commandText);

        void CloseConnection();
    }
}