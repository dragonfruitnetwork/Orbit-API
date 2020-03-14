﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using Newtonsoft.Json;

namespace DragonFruit.Orbit.API.Users
{
    public class KudosuCount
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("available")]
        public int Available { get; set; }
    }
}
