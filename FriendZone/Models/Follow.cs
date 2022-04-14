using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendZone.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public string FollowerId { get; set; }

        public string FollowingId { get; set; }
    }
}