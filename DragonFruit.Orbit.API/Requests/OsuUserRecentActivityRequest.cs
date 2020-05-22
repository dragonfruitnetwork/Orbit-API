﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using DragonFruit.Orbit.API.Objects.Interfaces;

namespace DragonFruit.Orbit.API.Requests
{
    public class OsuUserRecentActivityRequest : OrbitApiRequest, IRequiresUserId
    {
        public override string Path => $"https://osu.ppy.sh/api/v2/users/{UserId}/recent_activity";

        public OsuUserRecentActivityRequest(uint userId)
        {
            UserId = userId;
        }

        public uint UserId { get; set; }
    }
}
