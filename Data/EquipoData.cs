using APIRestEquipos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APIRestEquipos.Data
{
    public class EquipoData
    {
        public static bool Registrar(Equipo oEquipo)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oEquipo.id);
                cmd.Parameters.AddWithValue("@nombreEquipo", oEquipo.nombreEquipo);
                cmd.Parameters.AddWithValue("@puntosTotales", oEquipo.puntosTotales);
                cmd.Parameters.AddWithValue("@lanzamientos", oEquipo.lanzamientos);
                cmd.Parameters.AddWithValue("@asistencias", oEquipo.asistencias);
                cmd.Parameters.AddWithValue("@rebotes", oEquipo.rebotes);
                cmd.Parameters.AddWithValue("@perdidas", oEquipo.perdidas);
                cmd.Parameters.AddWithValue("@robos", oEquipo.robos);
                cmd.Parameters.AddWithValue("@triples", oEquipo.triples);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Equipo oEquipo)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oEquipo.id);
                cmd.Parameters.AddWithValue("@nombreEquipo", oEquipo.nombreEquipo);
                cmd.Parameters.AddWithValue("@puntosTotales", oEquipo.puntosTotales);
                cmd.Parameters.AddWithValue("@lanzamientos", oEquipo.lanzamientos);
                cmd.Parameters.AddWithValue("@asistencias", oEquipo.asistencias);
                cmd.Parameters.AddWithValue("@rebotes", oEquipo.rebotes);
                cmd.Parameters.AddWithValue("@perdidas", oEquipo.perdidas);
                cmd.Parameters.AddWithValue("@robos", oEquipo.robos);
                cmd.Parameters.AddWithValue("@triples", oEquipo.triples);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Equipo> Listar()
        {
            List<Equipo> oListaEquipo = new List<Equipo>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaEquipo.Add(new Equipo()
                            {
                                id = Convert.ToInt32(dr["IdUsuario"]),
                                nombreEquipo = dr["NombreEquipo"].ToString(),
                                puntosTotales = dr["PuntosTotales"].ToString(),
                                lanzamientos = Convert.ToInt32(dr["Lanzamientos"]),
                                asistencias = Convert.ToInt32(dr["Asistencias"]),
                                rebotes = Convert.ToInt32(dr["Rebotes"]),
                                perdidas = Convert.ToInt32(dr["Perdidas"]),
                                robos = Convert.ToInt32(dr["Robos"]),
                                triples = Convert.ToInt32(dr["Triples"])
                            });
                        }

                    }



                    return oListaEquipo;
                }
                catch (Exception ex)
                {
                    return oListaEquipo;
                }
            }
        }

        public static Equipo Obtener(int idEquipo)
        {
            Equipo oEquipo = new Equipo();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", idEquipo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oEquipo = new Equipo()
                            {
                                id = Convert.ToInt32(dr["IdUsuario"]),
                                nombreEquipo = dr["NombreEquipo"].ToString(),
                                puntosTotales = dr["PuntosTotales"].ToString(),
                                lanzamientos = Convert.ToInt32(dr["Lanzamientos"]),
                                asistencias = Convert.ToInt32(dr["Asistencias"]),
                                rebotes = Convert.ToInt32(dr["Rebotes"]),
                                perdidas = Convert.ToInt32(dr["Perdidas"]),
                                robos = Convert.ToInt32(dr["Robos"]),
                                triples = Convert.ToInt32(dr["Triples"])
                            };
                        }

                    }



                    return oEquipo;
                }
                catch (Exception ex)
                {
                    return oEquipo;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }


}
