﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System.ComponentModel;

namespace DragonFruit.Orbit.API.Enums
{
    public enum Modes
    {
        Default = -1,

        [Description("osu!standard")]
        Standard = 0,

        [Description("osu!taiko")]
        Taiko = 1,

        [Description("osu!catch")]
        Fruits = 2,

        [Description("osu!mania")]
        Mania = 3
    }
}
