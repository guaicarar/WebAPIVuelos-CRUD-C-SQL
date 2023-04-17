using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPIVuelos.Models;

namespace WebAPIVuelos.Data
{
    public class VueloData
    {
        public static bool Registrar(Vuelo oVuelo)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numvuelo", oVuelo.Numvuelo);
                cmd.Parameters.AddWithValue("@codaerolinea", oVuelo.Codaerolinea);
                cmd.Parameters.AddWithValue("@ciudadorigen", oVuelo.Ciudadorigen);
                cmd.Parameters.AddWithValue("@ciudaddestino", oVuelo.Ciudaddestino);
                cmd.Parameters.AddWithValue("@horasalida", oVuelo.Horasalida);
                cmd.Parameters.AddWithValue("@horallegada", oVuelo.Horallegada);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    //return oVuelo;
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Vuelo oVuelo)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idvuelo", oVuelo.IdVuelo);
				
                cmd.Parameters.AddWithValue("@numvuelo", oVuelo.Numvuelo);
                cmd.Parameters.AddWithValue("@codaerolinea", oVuelo.Codaerolinea);
                cmd.Parameters.AddWithValue("@ciudadorigen", oVuelo.Ciudadorigen);
                cmd.Parameters.AddWithValue("@ciudaddestino", oVuelo.Ciudaddestino);
                cmd.Parameters.AddWithValue("@horasalida", oVuelo.Horasalida);
                cmd.Parameters.AddWithValue("@horallegada", oVuelo.Horallegada);

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

        public static List<Vuelo> Listar()
        {
            List<Vuelo> oListaVuelo = new List<Vuelo>();
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
                            oListaVuelo.Add(new Vuelo()
                            {
                                IdVuelo = Convert.ToInt32(dr["IdVuelo"]),
                                Numvuelo = dr["Numvuelo"].ToString(),
                                Codaerolinea = dr["Codaerolinea"].ToString(),
                                Ciudadorigen= dr["Ciudadorigeno"].ToString(),
								Ciudaddestino= dr["Ciudaddestino"].ToString(),
                                Horasalida = Convert.ToDateTime(dr["Horasalida"].ToString()),
                                Horallegada = Convert.ToDateTime(dr["Horallegada"].ToString()),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                            });
                        }

                    }
                    return oListaVuelo;
                }
                catch (Exception ex)
                {
                    return oListaVuelo;
                }
            }
        }

        public static Vuelo Obtener(int idvuelo)
        {
            Vuelo oVuelo = new Vuelo();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idvuelo", idvuelo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oVuelo = new Vuelo()
                            {
                                
                                IdVuelo = Convert.ToInt32(dr["IdVuelo"]),
                                Numvuelo = dr["Numvuelo"].ToString(),
                                Codaerolinea = dr["Codaerolinea"].ToString(),
                                Ciudadorigen = dr["Ciudadorigeno"].ToString(),
                                Ciudaddestino = dr["Ciudaddestino"].ToString(),
                                Horasalida = Convert.ToDateTime(dr["Horasalida"].ToString()),
                                Horallegada = Convert.ToDateTime(dr["Horallegada"].ToString()),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())


                            };
                        }

                    }


                    return oVuelo;
                }
                catch (Exception ex)
                {
                    return oVuelo;
                }
            }
        }
        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idvuelo", id);

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