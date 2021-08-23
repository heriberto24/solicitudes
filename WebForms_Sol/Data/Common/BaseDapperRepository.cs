using Dapper;
using Model.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common
{
    /// <summary>
    /// Common Implementation of Dapper Repository
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseDapperRepository<TEntity>
    {
        #region Properties
        protected SqlConnection Connection { get; set; }
        protected readonly string _connectionString;
        private bool ExternalOpen { get; set; } = false;
        private SqlTransaction Transaction { get; set; } = null;
        #endregion

        public BaseDapperRepository(string dbConnection)
        {
            this._connectionString = dbConnection;
            this.Connection = new SqlConnection(dbConnection);
        }

        #region Connection
        #endregion

        #region READ
        public T QuerySingleOrDefault<T>(string query, DynamicParameters pars, CommandType? commandType = null)
        {
            T result;

            this.Open();
            result = this.Connection.QuerySingleOrDefault<T>(query, pars, commandType: commandType, transaction: this.Transaction);
            this.Close();

            return result;
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string query, DynamicParameters pars, CommandType? commandType = null)
        {
            T result;

            this.Open();
            result = await this.Connection.QuerySingleOrDefaultAsync<T>(query, pars, commandType: commandType, transaction: this.Transaction);
            this.Close();

            return result;
        }

        public IEnumerable<T> Query<T>(string query, DynamicParameters pars, CommandType? commandType = null)
        {
            IEnumerable<T> result;

            this.Open();
            result = this.Connection.Query<T>(query, pars, commandType: commandType, transaction: this.Transaction);
            this.Close();

            return result;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, DynamicParameters pars, CommandType? commandType = null)
        {
            IEnumerable<T> result;

            this.Open();
            result = await this.Connection.QueryAsync<T>(query, pars, commandType: commandType, transaction: this.Transaction);
            this.Close();

            return result;
        }

        public int Execute(string query, DynamicParameters pars, CommandType? commandType = null)
        {
            int result;

            this.Open();
            result = this.Connection.Execute(query, pars, commandType: commandType, transaction: this.Transaction);
            this.Close();

            return result;
        }

        public Guid? Insert<T>(T obj)
        {
            this.Open();
            Guid? uid = Connection.Insert<Guid>(obj, Transaction);
            this.Close();
            return uid;
        }
        public async Task<Guid?> InsertAsync<T>(T obj)
        {
            this.Open();
            Guid? uid = await Connection.InsertAsync<Guid>(obj, Transaction);
            this.Close();
            return uid;
        }

        public T Get<T>(Guid uid)
        {
            this.Open();
            T obj = Connection.Get<T>(uid, Transaction);
            this.Close();
            return obj;
        }
        public async Task<T> GetAsync<T>(Guid uid)
        {
            this.Open();
            T obj = await Connection.GetAsync<T>(uid, Transaction);
            this.Close();
            return obj;
        }
        #endregion

        public SqlConnection GetConnection()
        {
            return new SqlConnection(this._connectionString);
        }

        #region Manage
        public bool ConnectionIsOpen => this.Connection == null ? false : this.Connection.State == ConnectionState.Open;
        private void Open()
        {
            if (!ConnectionIsOpen)
            {
                this.Connection = new SqlConnection(this._connectionString);
                this.Connection.Open();
            }
        }
        private void Close()
        {
            if (ConnectionIsOpen && !this.ExternalOpen)
            {
                this.Connection.Close();
                this.Connection.Dispose();
                this.ExternalOpen = false;
            }
        }

        public void OpenConnection()
        {
            this.Open();
            this.ExternalOpen = true;
        }

        public void CloseConnection()
        {
            this.ExternalOpen = false;
            this.Close();
        }

        public void BeginTransaction()
        {
            if (!ConnectionIsOpen)
                this.Open();

            this.Transaction = this.Connection.BeginTransaction();

            this.ExternalOpen = true;
        }
        public void CommitTransaction()
        {
            this.Transaction.Commit();
            this.Transaction.Dispose();
            this.Transaction = null;
            this.ExternalOpen = false;
            this.Close();
        }
        public void RollbackTransaction()
        {
            this.Transaction.Rollback();
            this.Transaction.Dispose();
            this.Transaction = null;
            this.ExternalOpen = false;
            this.Close();
        }
        #endregion
    }
}
