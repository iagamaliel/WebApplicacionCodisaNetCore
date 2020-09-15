using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Services
{
    public class EmpleadoServices : IEmpleadoServices
    {
        #region ATTRIBUTES
        private readonly string _conn;
        #endregion

        #region CONSTRUCTOR
        public EmpleadoServices(string dbConnection)
        {
            _conn = dbConnection;
        }
        #endregion

        #region METHODS
        public async Task<List<Empleado>> GetAllEmployee()
        {
            var empleados = new List<Empleado>();

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"SELECT
                                        IdEmpleado,
                                        NombreCompleto,
                                        Cedula,
                                        Correo,
                                        FechaNacimiento,
                                        FechaIngreso,
                                        IdJefe,
                                        IdArea,
                                        Foto
                                    FROM Empleado;";

                    empleados = (await _db.QueryAsync<Empleado>(_query)).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return empleados;
        }

        public async Task<int> CreateEmployee(Empleado empleado)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"INSERT 
                                        INTO 
                                    Empleado (
                                        NombreCompleto,
                                        Cedula,
                                        Correo,
                                        FechaNacimiento,
                                        FechaIngreso,
                                        IdJefe,
                                        IdArea
                                    ) 
                                    VALUES (
                                        @NombreCompleto,
                                        @Cedula,
                                        @Correo,
                                        @FechaNacimiento,
                                        @FechaIngreso,
                                        @IdJefe,
                                        @IdArea
                                    );";

                    rowsAffected = await _db.ExecuteAsync(_query, empleado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        public async Task<int> UpdateEmployee(Empleado empleado)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"UPDATE
                                     Empleado SET
                                           NombreCompleto = @NombreCompleto,
                                           Cedula = @Cedula,
                                           Correo = @Correo,
                                           FechaNacimiento = @FechaNacimiento,
                                           FechaIngreso = @FechaIngreso,
                                           IdJefe = @IdJefe,
                                           IdArea = @IdArea
                                     WHERE IdEmpleado = @IdEmpleado;";

                    rowsAffected = await _db.ExecuteAsync(_query, empleado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        public async Task<int> DeleteEmployee(int idEmpleado)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"DELETE
                                     Empleado
                                     WHERE IdEmpleado = @IdEmpleado;";

                    rowsAffected = await _db.ExecuteAsync(_query, new { IdEmpleado = idEmpleado });
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
