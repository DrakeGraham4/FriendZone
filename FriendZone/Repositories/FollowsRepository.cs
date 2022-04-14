using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FriendZone.Models;

namespace FriendZone.Repositories
{

    public class FollowsRepository
    {
        private readonly IDbConnection _db;

        public FollowsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Follow Create(Follow followData)
        {
            string sql = @"
            INSERT INTO follows
            (followerId, followingId)
            VALUES
            (@FollowerId, @FollowingId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, followData);
            followData.Id = id;
            return followData;
        }

        internal List<FollowViewModel> GetProfileFollows(string id)
        {
            string sql = @"
            SELECT 
            f.id AS FollowId,
            a.*
            FROM follows f
            JOIN accounts a ON a.id = f.followingId
            WHERE f.followingId = @id;";
            return _db.Query<FollowViewModel>(sql, new { id }).ToList();
        }
    }
}