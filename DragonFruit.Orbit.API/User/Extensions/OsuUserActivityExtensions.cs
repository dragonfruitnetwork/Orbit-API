﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System.Collections.Generic;
using DragonFruit.Orbit.Api.User.Entities;
using DragonFruit.Orbit.Api.User.Requests;

namespace DragonFruit.Orbit.Api.User.Extensions
{
    public static class OsuUserActivityExtensions
    {
        /// <summary>
        /// Gets the user's recent in-game activity
        /// </summary>
        /// <param name="client">The <see cref="OrbitClient"/> to use</param>
        /// <param name="user">The user to lookup</param>
        /// <param name="page">Optional page number to return entries for</param>
        /// <param name="limit">Optional limit to cap responses. Make sure this is equal to the max or lower otherwise pagination will fail</param>
        public static IEnumerable<OsuRecentActivity> GetUserActivity<T>(this T client, OsuUserCard user, uint? page = null, uint? limit = null) where T : OrbitClient
        {
            return client.GetUserActivity(user.Id, page, limit);
        }

        /// <summary>
        /// Gets the user's recent in-game activity
        /// </summary>
        /// <param name="client">The <see cref="OrbitClient"/> to use</param>
        /// <param name="id">The id of the user</param>
        /// <param name="page">Optional page number to return entries for</param>
        /// <param name="limit">Optional limit to cap responses. Make sure this is equal to the max or lower otherwise pagination will fail</param>
        public static IEnumerable<OsuRecentActivity> GetUserActivity<T>(this T client, uint id, uint? page = null, uint? limit = null) where T : OrbitClient
        {
            var request = new OsuUserRecentActivityRequest(id)
            {
                Page = page ?? 0,
                Limit = limit
            };

            return client.Perform<IEnumerable<OsuRecentActivity>>(request);
        }
    }
}
