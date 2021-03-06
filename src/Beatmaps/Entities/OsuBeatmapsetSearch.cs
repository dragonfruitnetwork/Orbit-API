﻿// Orbit API Copyright (C) 2019-2021 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System.Collections.Generic;
using DragonFruit.Orbit.Api.Interfaces;
using Newtonsoft.Json;

namespace DragonFruit.Orbit.Api.Beatmaps.Entities
{
    public class OsuBeatmapsetSearch : IPaginatedByCursor
    {
        [JsonProperty("beatmapsets")]
        public IEnumerable<OsuBeatmapset> Beatmapsets { get; set; }

        [JsonProperty("total")]
        public int TotalResults { get; set; }

        [JsonProperty("recommended_difficulty")]
        public double? RecommendedDifficulty { get; set; }

        [JsonProperty("cursor")]
        public IReadOnlyDictionary<string, string> Cursor { get; set; }
    }
}
