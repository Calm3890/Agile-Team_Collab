using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Agile_Team_Collab
{
    public class AddDAO : IDisposable
    {
        SqlConnection _conn = null;

        public AddDAO()
        {
            try
            {
                _conn = new SqlConnection(@"Data Source = (localdb)\mssqllocaldb; Initial Catalog = Barangbaru; Integrated Security = true;");
                _conn.Open();
                Console.WriteLine(_conn.State.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Simpan(List<Add> add)
        {
            bool result = false;
            int rowAffected = 0;
            SqlTransaction trans = null;
            try
            {
                trans = _conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.Transaction = trans;
                    foreach (var item in add)
                    {
                        cmd.CommandText = @"Insert Into Barang Values (@Code, @Name, @Price)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Code", item.Code);
                        cmd.Parameters.AddWithValue("@Name", item.Name);
                        cmd.Parameters.AddWithValue("@Price", item.Price);
                        rowAffected = cmd.ExecuteNonQuery();
                    }

                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                throw ex;
            }
            finally
            {
                if (trans != null) trans.Dispose();
            }
            return result;
        }

        public List<Add> GetCode()
        {
            List<Add> list = new List<Add>();

            //string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DBMoneyManager; Integrated Security = True;";
            try
            {


                string sqlstring = @"select * from Barang";
                
                SqlCommand cmd = new SqlCommand(sqlstring, _conn);
                cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@code");
                Console.WriteLine(_conn.State.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Add l = new Add();
                        l.Code = reader["Code"].ToString();
                        l.Name = reader["Name"].ToString();
                        l.Price = Int32.Parse(reader["Price"].ToString());
                        list.Add(l);
                    }
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //finally
            //{
            //    if (_conn != null) _conn.Close();
            //}

            return list;
        }

        public int Delete(string code)
        {
            int result = 0;
            SqlTransaction trans = null;
            try
            {
                trans = _conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"delete barang where code = @code";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@code",code);
                    result = cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                throw ex;
            }
            finally
            {
                if (trans != null) trans.Dispose();
            }
            return result;
        }

        public List<Add> QueryDataBarang(Add add)
        {
            List<Add> listadd = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    if (add == null)
                    {
                        cmd.CommandText =
                            @"select * from Barang order by code";
                    }
                    else
                    {
                        cmd.CommandText =
                            @"select b.* from barang b 
                                where b.code like @code and b.name like @name and
                                b.price like @price
                                order by code";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Code", $"%{add.Code}%");
                        cmd.Parameters.AddWithValue("@Name", $"%{add.Name}%");
                        cmd.Parameters.AddWithValue("@Price", $"%{add.Price}%");
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            listadd = new List<Add>();
                            while (reader.Read())
                            {
                                listadd.Add(
                                    new Add
                                    {
                                        Code = reader["code"].ToString(),
                                        Name = reader["name"].ToString(),
                                        Price = Convert.ToInt32(reader["price"])
                                    });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listadd;
        }

        public Add GetDataAddByKode(string add)
        {
            Add result = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"select * from barang Where code = @code";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@code", add);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                result = new Add
                                {
                                    Code = reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Price = Convert.ToInt32(reader["Price"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int Update(Add add)
        {
            int result = 0;
            SqlTransaction trans = null;
            try
            {
                trans = _conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"update barang set code = @code, name = @name,
                        price = @price where code = @code";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@code", add.Code);
                    cmd.Parameters.AddWithValue("@name", add.Name);
                    cmd.Parameters.AddWithValue("@price", add.Price);
                    result = cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                throw ex;
            }
            finally
            {
                if (trans != null) trans.Dispose();
            }
            return result;
        }

        public void Dispose()
        {
            if (_conn != null) _conn.Close();
        }
    }
}
