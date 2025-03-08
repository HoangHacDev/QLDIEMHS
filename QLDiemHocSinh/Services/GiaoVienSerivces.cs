using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDiemHocSinh.Models;

namespace QLDiemHocSinh.Services
{
    public class GiaoVienSerivces
    {
        private readonly ConnectionString _connectionString;

        public GiaoVienSerivces(ConnectionString connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<GiaoVienModel> DangNhapAsync(string username, string password)
        {
            GiaoVienModel result = new GiaoVienModel();

            using (SqlConnection conn = _connectionString.KetNoiSQLServer())
            {
                if (conn == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Không thể kết nối đến database!";
                    return result;
                }

                try
                {
                    //await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_DangNhap", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameters
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Output parameters
                        SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(resultParam);
                        cmd.Parameters.Add(messageParam);

                        // Sử dụng SqlDataReader để lấy thông tin người dùng
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            int loginResult = Convert.ToInt32(resultParam.Value ?? 0);
                            string message = messageParam.Value?.ToString() ?? "";

                            if (loginResult == 1)
                            {
                                await reader.ReadAsync();
                                result = new GiaoVienModel
                                {
                                    IsSuccess = true,
                                    Message = message
                                };
                            }
                            else
                            {
                                result.IsSuccess = false;
                                result.Message = message;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Message = "Lỗi khi đăng nhập: " + ex.Message;
                }
            }
            return result;
        }
    }
}
