﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using DragonFruit.Common.Data.Parameters;
using DragonFruit.Orbit.API.Objects.Enums;
using DragonFruit.Orbit.API.Objects.Interfaces;

namespace DragonFruit.Orbit.API.Requests
{
    public class OsuBeatmapsetSearchRequest : OrbitApiRequest, IHasOptionalMode
    {
        public override string Path => "https://osu.ppy.sh/api/v2/beatmapsets/search";

        public OsuBeatmapsetSearchRequest()
        {
        }

        public OsuBeatmapsetSearchRequest(string query)
        {
            Query = query;
        }

        [QueryParameter("m")]
        public GameMode? Mode { get; set; }

        [QueryParameter("q")]
        public string Query { get; set; }

        [QueryParameter("sort")]
        private string SortQuery => $"{SortCriteria.ToString().ToLowerInvariant()}_{SortDirectionString}";

#nullable enable
        [QueryParameter("l")]
        private string? LanguageQuery => ((int?)Language)?.ToString();

        [QueryParameter("g")]
        private string? GenreQuery => ((int?)Genre)?.ToString();
#nullable restore

        public OsuBeatmapsetSearchSortCriteria SortCriteria { get; set; } = OsuBeatmapsetSearchSortCriteria.Ranked;
        public SortDirection SortDirection { get; set; } = SortDirection.Descending;
        private string SortDirectionString => SortDirection == SortDirection.Descending ? @"desc" : @"asc";

        public OsuLanguage? Language { get; set; }
        public OsuBeatmapsetGenre? Genre { get; set; }
    }
}
