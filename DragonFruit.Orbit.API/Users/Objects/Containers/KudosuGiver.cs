﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using Newtonsoft.Json;

namespace DragonFruit.Orbit.API.Users.Objects.Containers
{
    public class KudosuGiver
    {
        [JsonProperty("url")]
        public string Url;

        [JsonProperty("username")]
        public string Username;
    }
}