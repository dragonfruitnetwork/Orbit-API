﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System.ComponentModel;

namespace DragonFruit.Orbit.API.Enums
{
    public enum RankingType
    {
        [Description("Spotlight")]
        Charts,

        [Description("Country")]
        Country,

        [Description("Performance")]
        Performance,

        [Description("Score")]
        Score
    }
}
