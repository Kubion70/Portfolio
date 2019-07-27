using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Portfolio.Core.Database
{
    public class DatabaseWrapper : IDatabaseWrapper
    {
        private IDbConnection DbConnection { get; }

        public DatabaseWrapper(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        public Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);

        public Task<int> ExecuteAsync(CommandDefinition command)
            => DbConnection.ExecuteAsync(command);

        public Task<object> ExecuteScalarAsync(CommandDefinition command)
            => DbConnection.ExecuteScalarAsync(command);

        public Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);

        public Task<object> ExecuteScalarAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);

        public Task<T> ExecuteScalarAsync<T>(CommandDefinition command)
            => DbConnection.ExecuteScalarAsync<T>(command);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);

        public Task<IEnumerable<object>> QueryAsync(Type type, CommandDefinition command)
            => DbConnection.QueryAsync(type, command);

        public Task<IEnumerable<dynamic>> QueryAsync(CommandDefinition command)
            => DbConnection.QueryAsync(command);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id")
            => DbConnection.QueryAsync(command, map, splitOn);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn = "Id")
            => DbConnection.QueryAsync(command, map, splitOn);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id")
            => DbConnection.QueryAsync(command, map, splitOn);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn = "Id")
            => DbConnection.QueryAsync(command, map, splitOn);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string splitOn = "Id")
            => DbConnection.QueryAsync(command, map, splitOn);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public Task<IEnumerable<object>> QueryAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(type, sql, param, transaction, commandTimeout, commandType);

        public Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(sql, param, transaction, commandTimeout, commandType);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string splitOn = "Id")
            => DbConnection.QueryAsync(command, map, splitOn);

        public Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sql, Type[] types, Func<object[], TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(sql, types, map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command)
            => DbConnection.QueryAsync<T>(command);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);

        public Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryFirstAsync<T>(sql, param, transaction, commandTimeout, commandType);

        public Task<object> QueryFirstAsync(Type type, CommandDefinition command)
            => DbConnection.QueryFirstAsync(type, command);

        public Task<dynamic> QueryFirstAsync(CommandDefinition command)
            => DbConnection.QueryFirstAsync(command);

        public Task<T> QueryFirstAsync<T>(CommandDefinition command)
            => DbConnection.QueryFirstAsync<T>(command);

        public Task<dynamic> QueryFirstAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryFirstAsync(sql, param, transaction, commandTimeout, commandType);

        public Task<object> QueryFirstAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryFirstAsync(type, sql, param, transaction, commandTimeout, commandType);

        public Task<dynamic> QueryFirstOrDefaultAsync(CommandDefinition command)
            => DbConnection.QueryFirstOrDefaultAsync(command);

        public Task<object> QueryFirstOrDefaultAsync(Type type, CommandDefinition command)
            => DbConnection.QueryFirstOrDefaultAsync(type, command);

        public Task<object> QueryFirstOrDefaultAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryFirstOrDefaultAsync(type, sql, param, transaction, commandTimeout, commandType);

        public Task<T> QueryFirstOrDefaultAsync<T>(CommandDefinition command)
            => DbConnection.QueryFirstOrDefaultAsync<T>(command);

        public Task<dynamic> QueryFirstOrDefaultAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryFirstOrDefaultAsync(sql, param, transaction, commandTimeout, commandType);

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);

        public Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QueryMultipleAsync(sql, param, transaction, commandTimeout, commandType);

        public Task<SqlMapper.GridReader> QueryMultipleAsync(CommandDefinition command)
            => DbConnection.QueryMultipleAsync(command);

        public Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QuerySingleAsync<T>(sql, param, transaction, commandTimeout, commandType);

        public Task<object> QuerySingleAsync(Type type, CommandDefinition command)
            => DbConnection.QuerySingleAsync(type, command);

        public Task<T> QuerySingleAsync<T>(CommandDefinition command)
            => DbConnection.QuerySingleAsync<T>(command);

        public Task<dynamic> QuerySingleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QuerySingleAsync(sql, param, transaction, commandTimeout, commandType);

        public Task<dynamic> QuerySingleAsync(CommandDefinition command)
            => DbConnection.QuerySingleAsync(command);

        public Task<object> QuerySingleAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QuerySingleAsync(type, sql, param, transaction, commandTimeout, commandType);

        public Task<dynamic> QuerySingleOrDefaultAsync(CommandDefinition command)
            => DbConnection.QuerySingleOrDefaultAsync(command);

        public Task<object> QuerySingleOrDefaultAsync(Type type, CommandDefinition command)
            => DbConnection.QuerySingleOrDefaultAsync(type, command);

        public Task<T> QuerySingleOrDefaultAsync<T>(CommandDefinition command)
            => DbConnection.QuerySingleOrDefaultAsync<T>(command);

        public Task<object> QuerySingleOrDefaultAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QuerySingleOrDefaultAsync(type, sql, param, transaction, commandTimeout, commandType);

        public Task<dynamic> QuerySingleOrDefaultAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QuerySingleOrDefaultAsync(sql, param, transaction, commandTimeout, commandType);

        public Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            => DbConnection.QuerySingleOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);

        public Task<bool> DeleteAllAsync<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class
            => DbConnection.DeleteAllAsync<T>(transaction, commandTimeout);

        public Task<bool> DeleteAsync<T>(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
            => DbConnection.DeleteAsync<T>(entityToDelete, transaction, commandTimeout);

        public Task<IEnumerable<T>> GetAllAsync<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class
            => DbConnection.GetAllAsync<T>(transaction, commandTimeout);

        public Task<T> GetAsync<T>(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
            => ((dynamic)DbConnection).GetAsync<T>(id, transaction, commandTimeout);

        public Task<int> InsertAsync<T>(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class
            => DbConnection.InsertAsync<T>(entityToInsert, transaction, commandTimeout, sqlAdapter);

        public Task<bool> UpdateAsync<T>(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
            => DbConnection.UpdateAsync<T>(entityToUpdate, transaction, commandTimeout);
    }
}