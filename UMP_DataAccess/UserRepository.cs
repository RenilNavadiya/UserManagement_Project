using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMP_DataObject;

namespace UMP_DataAccess
{
    public class UserRepository : DataConnection
    {
        public UserRepository()
        {

        }

        public UserRepository(SqlTransaction trans) : base(trans)
        {

        }

        // Get all users data functionality created by Parth Darji
        public List<UserEntity> GetUsers()
        {
            List<UserEntity> users = new List<UserEntity>();

            // database access
            using (SqlConnection connection = (Trans == null) ? new SqlConnection(ConnectionString) : Trans.Connection)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT User_Id, FirstName, LastName, DateOfBirth, Gender, Street, City, Province, Country, PostalCode FROM Users;");
                SqlCommand cmd = new SqlCommand(sb.ToString(), connection);

                try
                {
                    if (Trans == null)
                    {
                        connection.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // adding database into Entity
                            UserEntity user = new UserEntity();
                            user.UserId = reader.GetGuid(0);
                            user.FirstName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                            user.LastName = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                            user.DateOfBirth = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3);
                            user.Gender = reader.IsDBNull(4) ? "N/A" : reader.GetString(4);
                            user.Street = reader.IsDBNull(5) ? "N/A" : reader.GetString(5);
                            user.City = reader.IsDBNull(6) ? "N/A" : reader.GetString(6);
                            user.Province = reader.IsDBNull(7) ? "N/A" : reader.GetString(7);
                            user.Country = reader.IsDBNull(8) ? "N/A" : reader.GetString(8);
                            user.PostalCode = reader.IsDBNull(9) ? "N/A" : reader.GetString(9);
                            users.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (Trans == null)
                    {
                        connection.Close();
                    }
                }
            }
            return users;
        }
       
        public int InsertNewUser(UserEntity userEntity)
        {
            using (SqlConnection connection = (Trans == null) ? new SqlConnection(ConnectionString) : Trans.Connection)
            {
                try
                {
                    if (Trans == null)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("Sp_InsertNewUser", connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = userEntity?.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = userEntity?.LastName;
                    cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = userEntity?.DateOfBirth;
                    cmd.Parameters.Add("@Gender", SqlDbType.NChar).Value = userEntity?.Gender;
                    cmd.Parameters.Add("@Street", SqlDbType.NVarChar).Value = userEntity?.Street;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = userEntity?.City;
                    cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = userEntity?.Province;
                    cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = userEntity?.Country;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = userEntity?.PostalCode;


                    int result = cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    return result;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (Trans == null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public int UpdateUser(UserEntity userEntity)
        {
            using (SqlConnection connection = (Trans == null) ? new SqlConnection(ConnectionString) : Trans.Connection)
            {
                try
                {
                    if (Trans == null)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("Sp_UpdateUser", connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userEntity?.UserId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = userEntity?.FirstName.Trim();
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = userEntity?.LastName.Trim();
                    cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = userEntity.DateOfBirth;
                    cmd.Parameters.Add("@Gender", SqlDbType.NChar).Value = userEntity?.Gender.Trim();
                    cmd.Parameters.Add("@Street", SqlDbType.NVarChar).Value = userEntity?.Street.Trim();
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = userEntity?.City.Trim();
                    cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = userEntity?.Province.Trim();
                    cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = userEntity?.Country.Trim();
                    cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = userEntity?.PostalCode.Trim();


                    int result = cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    return result;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (Trans == null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public int DeleteUser(Guid userId)
        {
            using (SqlConnection connection = (Trans == null) ? new SqlConnection(ConnectionString) : Trans.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteUser", connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                    if (Trans == null)
                    {
                        connection.Open();
                    }

                    int result = cmd.ExecuteNonQuery();

                    //cmd.Dispose();
                    return result;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (Trans == null)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
