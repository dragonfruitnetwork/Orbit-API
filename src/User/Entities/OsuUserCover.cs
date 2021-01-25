﻿// Orbit API Copyright (C) 2019-2021 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace DragonFruit.Orbit.Api.User.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class OsuUserCover
    {
        [CanBeNull]
        [JsonProperty("custom_url")]
        public string CustomUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
