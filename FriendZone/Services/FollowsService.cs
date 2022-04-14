using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
    public class FollowsService
    {
        private readonly FollowsRepository _fRepo;

        public FollowsService(FollowsRepository fRepo)
        {
            _fRepo = fRepo;
        }

        internal Follow Create(Follow followData)
        {
            return _fRepo.Create(followData);
        }

        internal List<FollowViewModel> GetProfileFollows(string id)
        {
            return _fRepo.GetProfileFollows(id);
        }
    }
}