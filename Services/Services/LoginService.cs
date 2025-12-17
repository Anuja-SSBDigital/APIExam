using APIExam.Data;
using APIExam.Model.DTOs;
using APIExam.Services.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace APIExam.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public static string ComputeSha256(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // hex string
                }

                return builder.ToString();
            }
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            if (request == null)
                return new LoginResponse { IsSuccess = false, Message = "Invalid login request" };

            // Hash password
            string hashedPassword = ComputeSha256(request.Password);

            // Input parameters
            var usernameParam = new SqlParameter("@Username", request.UserName);
            var passwordParam = new SqlParameter("@Password", hashedPassword);

            // Output parameters
            var isSuccessParam = new SqlParameter("@IsSuccess", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };

            var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
            {
                Direction = ParameterDirection.Output
            };

            // Execute stored procedure
            var result = await _context.LoginResult
                .FromSqlRaw(
                    "EXEC sp_LoginUser @Username, @Password, @IsSuccess OUTPUT, @Message OUTPUT",
                    usernameParam, passwordParam, isSuccessParam, messageParam
                )
                .ToListAsync();

            // Read output values
            var response = new LoginResponse
            {
                IsSuccess = Convert.ToBoolean(isSuccessParam.Value),
                Message = Convert.ToString(messageParam.Value)
            };

            // If login successful, extract user info
            if (response.IsSuccess && result.Any())
            {
                var r = result.First();

                response.UserName = r.UserName;
                response.CollegeName = r.CollegeName;
                response.CollegeCode = r.CollegeCode;
                response.DistrictName = r.DistrictName;
                response.DistrictCode = r.DistrictCode;
                response.PrincipalMobileNo = r.PrincipalMobileNo;
                response.EmailId = r.EmailId;
            }

            return response;
        }

    }
}
