using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Services
{
    public class EmpleadoHabilidadServices : IEmpleadoHabilidadServices
    {
        #region ATTRIBUTES
        private readonly string _conn;
        #endregion

        #region CONSTRUCTOR
        public EmpleadoHabilidadServices(string dbConnection)
        {
            _conn = dbConnection;
        }
        #endregion

        #region METHODS
        public async Task<List<EmpleadoHabilidad>> GetAllEmployeeSkill(int idEmpleado)
        {
            var empleadoHabilidades = new List<EmpleadoHabilidad>();

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"SELECT
                                        IdHabilidad,
                                        IdEmpleado,
                                        NombreHabilidad
                                    FROM Empleado_Habilidad
                                    WHERE IdEmpleado = @IdEmpleado;";

                    empleadoHabilidades = (await _db.QueryAsync<EmpleadoHabilidad>(_query, new { IdEmpleado = idEmpleado })).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return empleadoHabilidades;
        }

        public async Task<int> CreateEmployeeSkill(EmpleadoHabilidad empleadoHabilidad)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"INSERT 
                                        INTO 
                                    Empleado_Habilidad (
                                        IdEmpleado,
                                        NombreHabilidad
                                    ) 
                                    VALUES (
                                        @IdEmpleado,
                                        @NombreHabilidad 
                                    );";

                    rowsAffected = await _db.ExecuteAsync(_query, empleadoHabilidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        public async Task<int> DeleteEmployeeSkill(int idHabilidad)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"DELETE
                                     Empleado_Habilidad
                                     WHERE IdHabilidad = @IdHabilidad;";

                    rowsAffected = await _db.ExecuteAsync(_query, new { IdHabilidad = idHabilidad });
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
