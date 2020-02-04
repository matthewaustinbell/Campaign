using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using camp.aign.Models;
using Dapper;


namespace camp.aign.DataAccess
{
    public class UserRepository
    {
        private string _connectionString = "Server=localhost;Database=campaignDB;Trusted_Connection=True;";

        public User UPDATE(User updatedUser, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"Update [User]
                                SET [Name] = @Name
                                    ,[Email] = @Email
                                    ,[donationTotal] = @donationTotal
                            output inserted.*
                                WHERE id = @id";

                updatedUser.Id = id;

                var user = db.QueryFirst<User>(sql, updatedUser);

                return user;
            }
        }
    }
}

