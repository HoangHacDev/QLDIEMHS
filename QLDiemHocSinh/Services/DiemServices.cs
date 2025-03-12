using QLDiemHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemHocSinh.Services
{
    public class DiemServices
    {
        private readonly ConnectionString _connectionString;

        public DiemServices(ConnectionString connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public string ThemDiemHS(string maHS, string maLop, string maMH, string maLoaiDiem, float diem)
        {
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return null;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Diem_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@MaHS", maHS);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@MaLoaiDiem", maLoaiDiem);
                        cmd.Parameters.AddWithValue("@Diem", diem);
                        cmd.Parameters.AddWithValue("@HocKy", null);
                        cmd.Parameters.AddWithValue("@NamHoc", null);

                        string newId = cmd.ExecuteScalar()?.ToString();
                        return newId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm điểm cho học sinh: " + ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string DanhGiaHS(string maHS, string maLop, float diemTB, string hocLuc, string hanhKiem)
        {
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return null;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_HanhKiem_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@MaHS", maHS);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@HocKy", null);
                        cmd.Parameters.AddWithValue("@NamHoc", null);
                        cmd.Parameters.AddWithValue("@DiemTrungBinh", diemTB);
                        cmd.Parameters.AddWithValue("@HocLuc", hocLuc);
                        cmd.Parameters.AddWithValue("@HanhKiem", hanhKiem);

                        string newId = cmd.ExecuteScalar()?.ToString();
                        return newId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hạnh kiểm cho học sinh: " + ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public bool CapnhatDanhGiaHS(string maHK, string maHS, string maLop, float diemTB, string hocLuc, string hanhKiem)
        {
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return false;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_HanhKiem_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@MaHK", maHK);
                        cmd.Parameters.AddWithValue("@MaHS", maHS);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@HocKy", null);
                        cmd.Parameters.AddWithValue("@NamHoc", null);
                        cmd.Parameters.AddWithValue("@DiemTrungBinh", diemTB);
                        cmd.Parameters.AddWithValue("@HocLuc", hocLuc);
                        cmd.Parameters.AddWithValue("@HanhKiem", hanhKiem);

                        int rowsAffected = (int)cmd.ExecuteScalar();
                        return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật hạnh kiểm cho học sinh: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool CapnhatDiemHS(string maDiem ,string maHS, string maLop, string maMH, string maLoaiDiem, float diem)
        {
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return false;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Diem_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@MaDiem", maDiem);
                        cmd.Parameters.AddWithValue("@MaHS", maHS);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@MaLoaiDiem", maLoaiDiem);
                        cmd.Parameters.AddWithValue("@Diem", diem);
                        cmd.Parameters.AddWithValue("@HocKy", null);
                        cmd.Parameters.AddWithValue("@NamHoc", null);

                        int rowsAffected = (int)cmd.ExecuteScalar();
                        return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật điểm cho học sinh: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<LoaiDiemModel> GetLoaiDiem(string maLoaiDiem = null)
        {
            List<LoaiDiemModel> result = new List<LoaiDiemModel>();
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return result;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Loaidiem_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "SELECT");
                        cmd.Parameters.AddWithValue("@MaLoaiDiem", (object)maLoaiDiem ?? DBNull.Value);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new LoaiDiemModel
                                {
                                    MaLoaiDiem = reader["MaLoaiDiem"].ToString(),
                                    TenLoaiDiem = reader["TenLoaiDiem"].ToString(),
                                    HeSo = (int)reader["HeSo"],
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu loại điểm HS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        public List<DiemHocSinhModel> GetDiemHS(string maHS = null)
        {
            List<DiemHocSinhModel> result = new List<DiemHocSinhModel>();
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return result;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Diem_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "SELECT");
                        cmd.Parameters.AddWithValue("@MaHS", (object)maHS ?? DBNull.Value);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DiemHocSinhModel diemHocSinh = new DiemHocSinhModel
                                {
                                    MaDiem = reader["MaDiem"].ToString(),
                                    MaHS = reader["MaHS"].ToString(),
                                    Malop = reader["Malop"].ToString(),
                                    MaMH = reader["MaMH"].ToString(),
                                    TenMH = reader["TenMH"].ToString(),
                                    MaLoaiDiem = reader["MaLoaiDiem"].ToString(),
                                    TenLoaiDiem = reader["TenLoaiDiem"].ToString(),
                                    //HeSo = reader["TenLoaiDiem"].ToString(),
                                    NamHoc = reader["NamHoc"].ToString(),
                                    MaHK = reader["MaHK"].ToString(),
                                    HanhKiem = reader["HanhKiem"].ToString(),
                                };

                                // Xử lý giá trị NULL cho Diem
                                if (reader["Diem"] != DBNull.Value)
                                {
                                    diemHocSinh.Diem = Convert.ToSingle(reader["Diem"]);
                                }
                                else
                                {
                                    diemHocSinh.Diem = 0; // hoặc giá trị mặc định khác
                                }

                                // Xử lý giá trị NULL cho HocKy
                                if (reader["HocKy"] != DBNull.Value)
                                {
                                    diemHocSinh.HocKy = Convert.ToInt32(reader["HocKy"]);
                                }
                                else
                                {
                                    diemHocSinh.HocKy = 0; // hoặc giá trị mặc định khác
                                }

                                result.Add(diemHocSinh);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu điểm học sinh: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        public List<HanhKiemModel> GetHanhkiem(string maHS = null)
        {
            List<HanhKiemModel> result = new List<HanhKiemModel>();
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return result;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_HanhKiem_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "SELECT");
                        //cmd.Parameters.AddWithValue("@MaHK", (object)maHanhkiem ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaHS", (object)maHS ?? DBNull.Value);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new HanhKiemModel
                                {
                                    MaHK = reader["MaHK"].ToString(),
                                    MaHS = reader["MaHS"].ToString(),
                                    MaLop = reader["MaLop"].ToString(),
                                    HocKy = reader["HocKy"] != DBNull.Value ? Convert.ToInt32(reader["HocKy"]) : 0,
                                    NamHoc = reader["NamHoc"].ToString(),
                                    DiemTrungBinh = reader["DiemTrungBinh"] != DBNull.Value ? Convert.ToSingle(reader["DiemTrungBinh"]) : 0.0f,
                                    HocLuc = reader["HocLuc"].ToString(),
                                    HanhKiem = reader["HanhKiem"] == DBNull.Value ? "" : reader["HanhKiem"].ToString(),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu hạnh kiểm HS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        public bool DeleteDiemHS(string id_LopHoc)
        {
            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null) return false;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Diem_CRUD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "DELETE");
                        cmd.Parameters.AddWithValue("@MaDiem", id_LopHoc);

                        int rowsAffected = (int)cmd.ExecuteScalar();
                        return rowsAffected > 0; // Trả về true nếu xóa thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa điểm học sinh: " + ex.Message);
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
