using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Services
{
    public class AreaServices : IAreaServices
    {
        #region ATTRIBUTES
        private readonly string _conn;
        #endregion

        #region CONSTRUCTOR
        public AreaServices(string dbConnection)
        {
            _conn = dbConnection;
        }
        #endregion

        #region METHODS
        public async Task<List<Area>> GetAllAreas()
        {
            var areas = new List<Area>();

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"SELECT 
                                        IdArea,
                                        Nombre,
                                        Descripcion
                                    FROM Area;";

                    areas = (await _db.QueryAsync<Area>(_query)).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return areas;
        }

        public async Task<int> CreateArea(Area area)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"INSERT 
                                        INTO 
                                    Area (
                                        Nombre,
                                        Descripcion
                                    ) 
                                    VALUES (
                                        @Nombre,
                                        @Descripcion
                                    );";

                    rowsAffected = await _db.ExecuteAsync(_query, area);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        public async Task<int> UpdateArea(Area area)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"UPDATE
                                     Area SET
                                        Nombre = @Nombre,
                                        Descripcion = @Descripcion
                                     WHERE IdArea = @IdArea;";

                    rowsAffected = await _db.ExecuteAsync(_query, area);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        public async Task<int> DeleteArea(int idArea)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"DELETE
                                     Area
                                     WHERE IdArea = @IdArea;";

                    rowsAffected = await _db.ExecuteAsync(_query, new { IdArea = idArea });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }
        #endregion
    }
}
