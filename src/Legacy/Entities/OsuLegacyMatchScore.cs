﻿// Orbit API Copyright (C) 2019-2021 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System;
using DragonFruit.Orbit.Api.Legacy.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Orbit.Api.Legacy.Entities
{
    [Serializable]
    public class OsuLegacyMatchScore : OsuLegacyScore
    {
        [JsonProperty("pass")]
        public LegacyBool Passed { get; set; }

        [JsonProperty("slot")]
        public uint PlayerSlot { get; set; }

        [JsonProperty("team")]
        public LegacyTeam Team { get; set; }
    }
}
