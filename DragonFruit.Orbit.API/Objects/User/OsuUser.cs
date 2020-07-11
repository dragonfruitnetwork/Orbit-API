﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Orbit.API.Objects.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Orbit.API.Objects.User
{
    public class OsuUser
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("join_date")]
        public DateTimeOffset JoinDate { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("previous_usernames")]
        public IEnumerable<string> PreviousUsernames { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("profile_colour")]
        public string Colour { get; set; }

        [JsonProperty("avatar_url")]
        private string AvatarString
        {
            set => AvatarUrl = value.StartsWith("http") ? value : "https://osu.ppy.sh" + value;
        }

        public string AvatarUrl { get; set; }

        [JsonProperty("cover_url")]
        public string CoverObject
        {
            get => Cover?.Url;
            set => Cover = new OsuUserCover { Url = value };
        }

        [JsonProperty("cover")]
        public OsuUserCover Cover { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("is_supporter")]
        public bool IsSupporter { get; set; }

        [JsonProperty("support_level")]
        public int SupportLevel { get; set; }

        [JsonProperty("is_gmt")]
        public bool IsGMT { get; set; }

        [JsonProperty("is_qat")]
        public bool IsQAT { get; set; }

        [JsonProperty("is_bng")]
        public bool IsBNG { get; set; }

        [JsonProperty("is_bot")]
        public bool IsBot { get; set; }

        [JsonProperty("is_active")]
        public bool Active { get; set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }

        [JsonProperty("pm_friends_only")]
        public bool PMFriendsOnly { get; set; }

        [JsonProperty("interests")]
        public string Interests { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("last_visit")]
        public DateTimeOffset? LastVisit { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("lastfm")]
        public string Lastfm { get; set; }

        [JsonProperty("skype")]
        public string Skype { get; set; }

        [JsonProperty("discord")]
        public string Discord { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("post_count")]
        public int PostCount { get; set; }

        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }

        [JsonProperty("favourite_beatmapset_count")]
        public int FavouriteBeatmapsetCount { get; set; }

        [JsonProperty("graveyard_beatmapset_count")]
        public int GraveyardBeatmapsetCount { get; set; }

        [JsonProperty("loved_beatmapset_count")]
        public int LovedBeatmapsetCount { get; set; }

        [JsonProperty("ranked_and_approved_beatmapset_count")]
        public int RankedAndApprovedBeatmapsetCount { get; set; }

        [JsonProperty("unranked_beatmapset_count")]
        public int UnrankedBeatmapsetCount { get; set; }

        [JsonProperty("scores_first_count")]
        public int ScoresFirstCount { get; set; }

        [JsonProperty("playstyle")]
        private string[] PlayStyleObject
        {
            set => PlayStyle = value?.Select(str => Enum.Parse(typeof(OsuUserPlayStyle), str, true)).Cast<OsuUserPlayStyle>().ToArray();
        }

        public IEnumerable<OsuUserPlayStyle> PlayStyle { get; set; }

        [JsonProperty("playmode")]
        public string PlayMode { get; set; }

        [JsonProperty("profile_order")]
        public IEnumerable<string> ProfileOrder { get; set; }

        [JsonProperty("kudosu")]
        public KudosuCount Kudosu { get; set; }

        [JsonProperty("statistics")]
        public OsuUserStats Stats { get; set; }

        [JsonProperty("rankHistory")]
        private OsuRankHistory RankHistoryObject
        {
            set => Stats.RankHistory = value;
        }

        [JsonProperty("badges")]
        public IEnumerable<OsuBadge> Badges { get; set; }

        [JsonProperty("user_achievements")]
        public IEnumerable<OsuUserAchievement> Achievements { get; set; }

        [JsonProperty("monthly_playcounts")]
        public IEnumerable<OsuUserHistoryCount> MonthlyPlaycounts { get; set; }

        [JsonProperty("replays_watched_counts")]
        public IEnumerable<OsuUserHistoryCount> ReplaysWatchedCounts { get; set; }
    }
}
