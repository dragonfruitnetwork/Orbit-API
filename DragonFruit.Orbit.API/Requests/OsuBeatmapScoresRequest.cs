﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Orbit.API.Objects.Enums;

namespace DragonFruit.Orbit.API.Requests
{
    public class OsuBeatmapScoresRequest : OrbitApiRequest
    {
        public override string Path => $"https://osu.ppy.sh/api/v2/beatmaps/{BeatmapId}/scores";

        public OsuBeatmapScoresRequest(uint mapId, GameMode mode, BeatmapLeaderboardScope type)
        {
            BeatmapId = mapId;
            Mode = mode;
            Type = type;
        }

        public uint BeatmapId { get; set; }
        public GameMode Mode { get; set; }
        public BeatmapLeaderboardScope Type { get; set; }
        public IEnumerable<string>? Mods { get; set; }

        #region Compiled Queries

        [QueryParameter("mode")]
        private string ModeQuery => Mode.ToString().ToLowerInvariant();

        [QueryParameter("type")]
        private string TypeQuery => Type.ToString().ToLowerInvariant();

        [QueryParameter("mods[]")]
        private string CompiledModsQuery => Mods == null ? null : string.Join("&mods[]", Mods);

        #endregion
    }
}
