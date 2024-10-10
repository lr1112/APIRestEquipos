using APIRestEquipos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APIRestEquipos.Data
{
    public class JugadorData
    {
        public static bool Registrar(Jugador oJugador)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("jsp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", oEquipo.id);
                cmd.Parameters.AddWithValue("@nombre", oJugador.nombre);
                cmd.Parameters.AddWithValue("@apellido", oJugador.apellido);
                cmd.Parameters.AddWithValue("@puntos", oJugador.puntos);
                cmd.Parameters.AddWithValue("@lanzamientos", oJugador.lanzamientos);
                cmd.Parameters.AddWithValue("@asistencias", oJugador.asistencias);
                cmd.Parameters.AddWithValue("@rebotes", oJugador.rebotes);
                cmd.Parameters.AddWithValue("@perdidas", oJugador.perdidas);
                cmd.Parameters.AddWithValue("@robos", oJugador.robos);
                cmd.Parameters.AddWithValue("@triples", oJugador.triples);

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

        public static bool Modificar(Jugador oJugador)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("jsp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oJugador.id);
                cmd.Parameters.AddWithValue("@nombreEquipo", oJugador.nombre);
                cmd.Parameters.AddWithValue("@apellido", oJugador.apellido);
                cmd.Parameters.AddWithValue("@puntosTotales", oJugador.puntos);
                cmd.Parameters.AddWithValue("@lanzamientos", oJugador.lanzamientos);
                cmd.Parameters.AddWithValue("@asistencias", oJugador.asistencias);
                cmd.Parameters.AddWithValue("@rebotes", oJugador.rebotes);
                cmd.Parameters.AddWithValue("@perdidas", oJugador.perdidas);
                cmd.Parameters.AddWithValue("@robos", oJugador.robos);
                cmd.Parameters.AddWithValue("@triples", oJugador.triples);

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

        public static List<Jugador> Listar()
        {
            List<Jugador> oListaJugador = new List<Jugador>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("jsp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaJugador.Add(new Jugador()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                puntos = Convert.ToInt32(dr["puntos"]),
                                lanzamientos = Convert.ToInt32(dr["lanzamientos"]),
                                asistencias = Convert.ToInt32(dr["asistencias"]),
                                rebotes = Convert.ToInt32(dr["rebotes"]),
                                perdidas = Convert.ToInt32(dr["perdidas"]),
                                robos = Convert.ToInt32(dr["robos"]),
                                triples = Convert.ToInt32(dr["triples"])
                            });
                        }

                    }



                    return oListaJugador;
                }
                catch (Exception ex)
                {
                    return oListaJugador;
                }
            }
        }

        public static Jugador Obtener(int id)
        {
            Jugador oJugador = new Jugador();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("jsp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oJugador = new Jugador()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                puntos = Convert.ToInt32(dr["puntos"]),
                                lanzamientos = Convert.ToInt32(dr["lanzamientos"]),
                                asistencias = Convert.ToInt32(dr["asistencias"]),
                                rebotes = Convert.ToInt32(dr["rebotes"]),
                                perdidas = Convert.ToInt32(dr["perdidas"]),
                                robos = Convert.ToInt32(dr["robos"]),
                                triples = Convert.ToInt32(dr["triples"])
                            };
                        }

                    }



                    return oJugador;
                }
                catch (Exception ex)
                {
                    return oJugador;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("jsp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

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
