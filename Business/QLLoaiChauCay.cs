using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChauCayCanh.Models;
namespace QuanLyChauCayCanh.Business
{
    public class QLLoaiChauCay
    {
        public static List<LoaiChauCay> GetList()
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<LoaiChauCay> lst = new List<LoaiChauCay>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");
                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandText = "select * from db_QLBH.dbo.tbl_loaichaucay;";
                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            var nv = new LoaiChauCay()
                            {
                                Id = rd["idLoaichaucay"].ToString(),
                                Ten = rd["tenLoaichaucay"].ToString(),
                                ThoiGianTao = CommonTask.StrToDate(rd["dThoigiantao"].ToString()),
                                ThoiGianSua = CommonTask.StrToDate(rd["dThoigiansua"].ToString()),
                            };
                            lst.Add(nv);
                        }

                    }

                }

            }
            catch (SqlException sqlexception)
            {
                //Response.Write("ERROR ::" + sqlexception.Message);
            }
            catch (Exception ex)
            {
                //Response.Write("ERROR ::" + ex.Message);
            }
            finally
            {
                conObject.Close();
            }
            return lst;

        }
        public static (bool, string) IsValid(LoaiChauCay loaiChauCay)
        {
            var res = (true, "");
            if (String.IsNullOrEmpty(loaiChauCay.Id))
            {
                return (false, "Không được để trống mã loại chậu cây!");
            }

            if (String.IsNullOrEmpty(loaiChauCay.Ten))
            {
                return (false, "Không được để trống tên loại chậu cây!");
            }


            return res;
        }

        public static (bool, string) Add(LoaiChauCay loaiChauCay)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");


                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ThemLoaiChauCay";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = loaiChauCay.Id;

                        cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 30));
                        cmd.Parameters["@Ten"].Value = loaiChauCay.Ten;


                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;

                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = "Mã đã tồn tại" ;
                        }

                        return (IsSuccess, CreateMsg);
                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return (false, "Lỗi sql !");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi không xác định !");
            }
            finally
            {
                conObject.Close();
            }
            return (false, "Lỗi Không xác định !");
        }
        public static (bool, string) Edit(LoaiChauCay loaiChauCay)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");


                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SuaLoaiChauCay";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = loaiChauCay.Id;

                        cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 30));
                        cmd.Parameters["@Ten"].Value = loaiChauCay.Ten;


                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;


                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0" ;
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = "Mã không tồn tại" ;
                        }

                        return (IsSuccess, CreateMsg);
                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return (false, "Lỗi sql !");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi không xác định !");
            }
            finally
            {
                conObject.Close();
            }
            return (false, "Lỗi không xác định !");
        }
        public static void Delete(LoaiChauCay loaiChauCay)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");


                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "XoaLoaiChauCay";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = loaiChauCay.Id;

                        var res = cmd.ExecuteNonQuery();

                    }

                }

            }
            catch (SqlException sqlexception)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conObject.Close();
            }
        }

        public static LoaiChauCay GetById(string Id)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            LoaiChauCay loaiChauCay = null;

            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GetLoaiChauCay";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = Id;

                        var rd = cmd.ExecuteReader();

                        if (rd.Read())
                        {
                            loaiChauCay = new LoaiChauCay()
                            {
                                Id = rd["idLoaichaucay"].ToString(),
                                Ten = rd["tenLoaiChauCay"].ToString(),
                            };

                        }

                        return loaiChauCay;
                    }



                }

            }
            catch (SqlException sqlexception)
            {
                return loaiChauCay;
            }
            catch (Exception ex)
            {
                return loaiChauCay;
            }
            finally
            {
                conObject.Close();
            }
            return loaiChauCay;
        }
    
    }
}
