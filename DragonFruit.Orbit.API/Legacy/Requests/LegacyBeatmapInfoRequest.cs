﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Orbit.API.Objects.Enums;

namespace DragonFruit.Orbit.API.Legacy.Requests
{
    public class LegacyBeatmapInfoRequest : LegacyEnumerableResponseRequest
    {
        public override string Path => "https://osu.ppy.sh/api/get_beatmaps";

        public DateTimeOffset? Since { get; set; }

        public bool? IncludeConvertedMaps { get; set; }

        public OsuMods Mods { get; set; } = OsuMods.None;

        [QueryParameter("s")]
        public uint? BeatmapsetId { get; set; }

        [QueryParameter("b")]
        public uint? BeatmapId { get; set; }

        [QueryParameter("h")]
        public string MapHash { get; set; }

        [QueryParameter("since")]
        private string SqlSince => Since?.ToString("yyyy-MM-dd HH:mm:ss");

        [QueryParameter("a")]
        private uint IncludeConvertedMapsValue => IncludeConvertedMaps ?? true ? 1 : 0u;

        [QueryParameter("mods")]
        private ulong ModsValue => (uint)Mods;
    }
}
