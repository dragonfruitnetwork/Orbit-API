﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Orbit.API.Requests
{
    public class OsuBeatmapsetEventsRequest : OrbitApiRequest
    {
        protected override string Route => "/beatmapsets/events";

        public OsuBeatmapsetEventsRequest()
        {
        }

        public OsuBeatmapsetEventsRequest(int page)
        {
            Page = page;
        }

        [QueryParameter("page")]
        public int Page { get; set; }
    }
}
