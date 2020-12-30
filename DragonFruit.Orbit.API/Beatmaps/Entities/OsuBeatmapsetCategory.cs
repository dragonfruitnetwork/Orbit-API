﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Orbit.Api.Beatmaps.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class OsuBeatmapsetCategory
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
