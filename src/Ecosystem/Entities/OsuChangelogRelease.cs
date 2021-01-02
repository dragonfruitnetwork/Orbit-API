﻿// Orbit API Copyright (C) 2019-2021 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DragonFruit.Orbit.Api.Ecosystem.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class OsuChangelogRelease
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("display_version")]
        public string DisplayVersion { get; set; }

        [JsonProperty("users")]
        public int? Users { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("update_stream")]
        public OsuChangelogTarget Target { get; set; }

        [JsonProperty("changelog_entries")]
        public IEnumerable<OsuChangelogEntry> Entries { get; set; }
    }
}
