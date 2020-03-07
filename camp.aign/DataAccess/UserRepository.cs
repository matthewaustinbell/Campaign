using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using camp.aign.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                                SET [donationTotal] = @donationTotal
                            output inserted.*
                                WHERE id = @id";

                updatedUser.Id = id;

                var user = db.QueryFirst<User>(sql, updatedUser);

                return user;
            }
        }

        public User getUserById(int userId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM [USER] WHERE id = @userId";
                return db.QueryFirst<User>(sql, new {userId});
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT [Name], donationTotal, [Id]
                            FROM [USER]
                            ORDER BY donationTotal DESC";
                var users = db.Query<User>(sql);
                return users;
            }
        }
    }
}

