﻿// Orbit API Copyright (C) 2019-2021 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System;
using System.Collections.Generic;
using DragonFruit.Orbit.Api.Ecosystem.Enums;
using DragonFruit.Orbit.Api.Interfaces;
using DragonFruit.Orbit.Api.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace DragonFruit.Orbit.Api.Ecosystem.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class OsuCommentsSummary : IPaginatedByCursor
    {
        private string _sortMethodName;

        [JsonProperty("has_more")]
        public bool More { get; set; }

        [JsonProperty("has_more_id")]
        public uint? MoreId { get; set; }

        [JsonProperty("sort")]
        public string SortMethodName
        {
            get => _sortMethodName;
            set
            {
                _sortMethodName = value;
                SortedBy = EnumUtils.GetInternalValue<CommentSort>(value);
            }
        }

        public CommentSort? SortedBy { get; set; }

        // todo add users and user votes

        [JsonProperty("comments")]
        public IEnumerable<OsuComment> Comments { get; set; }

        [CanBeNull]
        [JsonProperty("pinned_comments")]
        public IEnumerable<OsuComment> PinnedComments { get; set; }

        [CanBeNull]
        [JsonProperty("included_comments")]
        public IEnumerable<OsuComment> IncludedComments { get; set; }

        [JsonProperty("commentable_meta")]
        public IEnumerable<OsuCommentableMetadata> Metadata { get; set; }

        [JsonProperty("cursor")]
        public IReadOnlyDictionary<string, string> Cursor { get; set; }
    }
}
