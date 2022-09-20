using System;
using System.Data.SqlClient;

namespace BasicConnection
{
    class Program
    {
        string connectionString = "Data Source =DESKTOP-4UE3BDQ;Initial Catalog=Latihan1;User ID=test;Password=tes123;";
        void GetAll()
        {
            SqlConnection cnn = new SqlConnection(connectionString);  
            string query = "SELECT * FROM mahasiswa";
            SqlCommand command = new SqlCommand(query, cnn);
            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        Console.WriteLine("Id\tNama\tNim\tAlamat\tUmur");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + "\t" + reader[1] 
                            + "\t" + reader[2] 
                            + "\t" + reader[3]
                            + "\t" + reader[4]
                            );      
                        }   
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
                    cnn.Close();
            }
            catch (Exception e)
            {     
                Console.WriteLine(e.InnerException);
            }       
        }

        void GetById(int id)
        {
            string query = "SELECT * FROM Mahasiswa WHERE Id = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine("Id\tNama\tNim\tAlamat\tUmur");
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + "\t" + sqlDataReader[1] 
                            + "\t" + sqlDataReader[2] 
                            + "\t" + sqlDataReader[3]
                            + "\t" + sqlDataReader[4]
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data tidak ditemukan");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }      
        }

        void Insert(Mahasiswa mhs)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = mhs.Id;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@nama";
                sqlParameter1.Value = mhs.Nama;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@nim";
                sqlParameter2.Value = mhs.Nim; 

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@alamat";
                sqlParameter3.Value = mhs.Alamat; 

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@umur";
                sqlParameter4.Value = mhs.Umur; 

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);

                try
                {
                    sqlCommand.CommandText = 
                    "INSERT INTO Mahasiswa " +
                    "(Id, Nama, Nim, Alamat, Umur) " +
                    "VALUES (@id, @nama, @nim, @alamat, @umur) ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                          Console.WriteLine(exRollback.Message);;
                    }
                }
            }
        }

        void Update(Mahasiswa mhs)
        {
            using(SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                SqlTransaction sqlTransaction = cnn.BeginTransaction();
                SqlCommand sqlCommand = cnn.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = mhs.Id;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@nama";
                sqlParameter1.Value = mhs.Nama;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@nim";
                sqlParameter2.Value = mhs.Nim; 

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@alamat";
                sqlParameter3.Value = mhs.Alamat; 

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@umur";
                sqlParameter4.Value = mhs.Umur; 

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);

                try
                {
                    sqlCommand.CommandText = 
                    "UPDATE Mahasiswa " +
                    "SET Nama=@nama, Nim=@nim, Alamat=@alamat, Umur=@umur " +
                    "WHERE id = @id ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);;
                    }
                }
            }
        }

        void Delete(int id)
        {
            string query = "Delete Mahasiswa WHERE Id = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }      
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            // p.GetAll();
            // p.GetById(4);

            Mahasiswa mhs = new Mahasiswa()
            {
                Id = 5,
                Nama = "Windah",
                Nim = "333",
                Alamat = "Sudirman",
                Umur = 25,
            };
            // p.Update(mhs);
            p.Delete(mhs.Id);
            p.GetAll();
        }
    }
}
