﻿// Orbit API Copyright (C) 2019-2021 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using DragonFruit.Orbit.Api.Auth.Requests;

namespace DragonFruit.Orbit.Api.Auth.Extensions
{
    public static class OsuClientAuthExtensions
    {
        /// <summary>
        /// Use the <see cref="OrbitClient"/> credentials to create a guest user access token
        /// </summary>
        /// <remarks>
        /// Client credentials don't give a refresh token (as it's pointless)
        /// </remarks>
        /// <param name="client">The <see cref="OrbitClient"/> to use</param>
        public static OsuAuthToken GetSessionToken<T>(this T client) where T : OrbitClient
        {
            return client.Perform(new OsuClientAuthRequest());
        }
    }
}
