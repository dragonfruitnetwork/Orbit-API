﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using Newtonsoft.Json;

namespace DragonFruit.Orbit.API.Objects.Changelogs
{
    public class OsuChangelogVersionCursor
    {
        [JsonProperty("next")]
        public OsuChangelogRelease Next { get; set; }

        [JsonProperty("previous")]
        public OsuChangelogRelease Previous { get; set; }
    }
}
