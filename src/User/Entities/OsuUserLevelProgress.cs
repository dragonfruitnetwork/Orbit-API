﻿// Orbit API Copyright (C) 2019-2021 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Orbit.Api.User.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class OsuUserLevelProgress
    {
        [JsonProperty("current")]
        public uint Current { get; set; }

        [JsonProperty("progress")]
        public float Progress { get; set; }
    }
}
