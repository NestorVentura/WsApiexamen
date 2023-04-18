using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiExamen
{
    internal class AdoClient
    {
        private readonly string _connectionString;

        public AdoClient(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal async Task<string> AgregarAsync(string name, string description)
        {
            var errorDescription = string.Empty;
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand()
                    {
                        CommandText = "spAgregar",
                        Connection = sqlConnection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var sqlParameterNombre = new SqlParameter
                    {
                        ParameterName = "@nombre",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = name,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    var sqlParameterDescripcion = new SqlParameter
                    {
                        ParameterName = "@descripcion",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = description,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    cmd.Parameters.Add(sqlParameterNombre);
                    cmd.Parameters.Add(sqlParameterDescripcion);

                    sqlConnection.Open();

                    var sdr = await cmd.ExecuteReaderAsync();

                    while (sdr.Read())
                    {
                        errorDescription = sdr[1].ToString();
                    }

                    sdr.Close();
                }
            }
            catch (Exception exception)
            {
                errorDescription = exception.Message;
            }

            return errorDescription!;
        }

        internal async Task<string> ActualizarAsync(int id, string name, string description)
        {
            var errorDescription = string.Empty;
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand()
                    {
                        CommandText = "spActualizar",
                        Connection = sqlConnection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var sqlParameterId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Value = id,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    var sqlParameterNombre = new SqlParameter
                    {
                        ParameterName = "@nombre",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = name,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    var sqlParameterDescripcion = new SqlParameter
                    {
                        ParameterName = "@descripcion",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = description,
                        Direction = System.Data.ParameterDirection.Input
                    };

                    cmd.Parameters.Add(sqlParameterId);
                    cmd.Parameters.Add(sqlParameterNombre);
                    cmd.Parameters.Add(sqlParameterDescripcion);

                    sqlConnection.Open();

                    var sdr = await cmd.ExecuteReaderAsync();

                    while (sdr.Read())
                    {
                        errorDescription = sdr[1].ToString();
                    }

                    sdr.Close();
                }
            }
            catch (Exception exception)
            {
                errorDescription = exception.Message;
            }

            return errorDescription!;
        }

        internal async Task<string> EliminarAsync(int id)
        {
            var errorDescription = string.Empty;
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand()
                    {
                        CommandText = "spEliminar",
                        Connection = sqlConnection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var sqlParameterId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Value = id,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    cmd.Parameters.Add(sqlParameterId);


                    sqlConnection.Open();

                    var sdr = await cmd.ExecuteReaderAsync();

                    while (sdr.Read())
                    {
                        errorDescription = sdr[1].ToString();
                    }

                    sdr.Close();
                }
            }
            catch (Exception exception)
            {
                errorDescription = exception.Message;
            }

            return errorDescription!;
        }

        internal async Task<List<ExamenDto>> ConsultarAsync(string name, string description)
        {
            var examenes = new List<ExamenDto>();
          
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand()
                    {
                        CommandText = "spConsultar",
                        Connection = sqlConnection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var sqlParameterNombre = new SqlParameter
                    {
                        ParameterName = "@nombre",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = name,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    var sqlParameterDescripcion = new SqlParameter
                    {
                        ParameterName = "@descripcion",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = description,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    cmd.Parameters.Add(sqlParameterNombre);
                    cmd.Parameters.Add(sqlParameterDescripcion);


                    sqlConnection.Open();

                    var sdr = await cmd.ExecuteReaderAsync();

                    while (sdr.Read())
                    {
                        var examen = new ExamenDto
                        {
                            Id = sdr[0] is null ? 0 : int.Parse(sdr[0].ToString()),
                            Nombre = sdr[1] is null ? "" : sdr[1].ToString(),
                            Descripcion = sdr[2] is null ? "" : sdr[2].ToString()
                        };

                        examenes.Add(examen);
                    }

                    sdr.Close();
                    return examenes;
                }
            
          

            return examenes;
        }

    }
}