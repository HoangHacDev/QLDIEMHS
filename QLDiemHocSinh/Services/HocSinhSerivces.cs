using QLDiemHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QLDiemHocSinh.Services
{
    public class HocSinhSerivces
    {
        private readonly ConnectionString _connectionString;

        public HocSinhSerivces(ConnectionString connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public string ThemHocSinh(string tenHocSinh, DateTime ngaySinh, bool gioiTinh ,string maLop)
        {
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return null;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Hocsinh_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@HoTen", tenHocSinh);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);

                        string newId = cmd.ExecuteScalar()?.ToString();
                        return newId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm học sinh: " + ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool CapnhatHocSinh(string id_HocSinh, string tenHocSinh, DateTime ngaySinh, bool gioiTinh, string maLop)
        {
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return false;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Hocsinh_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@MaHS", id_HocSinh);
                        cmd.Parameters.AddWithValue("@HoTen", tenHocSinh);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);

                        int rowsAffected = (int)cmd.ExecuteScalar();
                        return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật học sinh: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<HocSinhModel> GetHocSinh(string id_HocSinh = null)
        {
            List<HocSinhModel> result = new List<HocSinhModel>();
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return result;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Hocsinh_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "SELECT");
                        cmd.Parameters.AddWithValue("@MaHS", (object)id_HocSinh ?? DBNull.Value);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new HocSinhModel
                                {
                                    MaHS = reader["MaHS"].ToString(),
                                    HoTen = reader["HoTen"].ToString(),
                                    NgaySinh = (DateTime)reader["NgaySinh"],
                                    GioiTinh = (bool)reader["GioiTinh"],
                                    MaLop = reader["MaLop"].ToString(),
                                    TenLop = reader["TenLop"].ToString(),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu học sinh: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public List<HocSinhModel> GetHocSinhFill(string tenLop = null, string tenKhoi = null)
        {
            List<HocSinhModel> result = new List<HocSinhModel>();
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return result;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Hocsinh_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "SELECT");
                        cmd.Parameters.AddWithValue("@TenLop", (object)tenLop ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Khoi", (object)tenKhoi ?? DBNull.Value);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new HocSinhModel
                                {
                                    MaHS = reader["MaHS"].ToString(),
                                    HoTen = reader["HoTen"].ToString(),
                                    NgaySinh = (DateTime)reader["NgaySinh"],
                                    GioiTinh = (bool)reader["GioiTinh"],
                                    MaLop = reader["MaLop"].ToString(),
                                    TenLop = reader["TenLop"].ToString(),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu học sinh: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public bool DeleteHocSinh(string id_HocSinh)
        {
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return false;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Hocsinh_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "DELETE");
                        cmd.Parameters.AddWithValue("@MaHS", id_HocSinh);

                        int rowsAffected = (int)cmd.ExecuteScalar();
                        return rowsAffected > 0; // Trả về true nếu xóa thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa học sinh: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
