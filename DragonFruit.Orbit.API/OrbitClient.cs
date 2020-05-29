﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DragonFruit.Common.Data;
using DragonFruit.Orbit.API.Exceptions;
using DragonFruit.Orbit.API.Legacy;
using DragonFruit.Orbit.API.Objects.Auth;
using DragonFruit.Orbit.API.Requests;

namespace DragonFruit.Orbit.API
{
    public abstract class OrbitClient : ApiClient
    {
        protected abstract OsuSessionToken GetSessionToken();

        #region Legacy Requests

        /// <summary>
        /// Global Legacy API key, can be obtained from https://old.ppy.sh/p/api
        /// </summary>
        protected virtual string LegacyApiKey { get; }

        /// <summary>
        /// Performs legacy requests, returning them as an <see cref="IEnumerable{T}"/>. If <see cref="LegacyRequestBase.ApiKey"/> is null the <see cref="LegacyApiKey"/> will be used instead
        /// </summary>
        public IEnumerable<T> Perform<T>(LegacyRequestBase requestData) where T : class
        {
            if (string.IsNullOrEmpty(requestData.ApiKey))
                requestData.ApiKey = LegacyApiKey;

            return base.Perform<IEnumerable<T>>(requestData);
        }

        #endregion

        /// <summary>
        /// Performs an <see cref="OsuAuthRequest"/>, returning the <see cref="OsuSessionToken"/> if successful
        /// </summary>
        public OsuSessionToken Perform<T>(T requestData) where T : OsuAuthRequest
        {
            return base.Perform<OsuSessionToken>(requestData);
        }

        public override T Perform<T>(ApiRequest requestData) where T : class
        {
            if (_token == null)
            {
                ProcessToken();
            }

            if (_token.Expired)
            {
                ProcessToken();
            }

            return base.Perform<T>(requestData);
        }

        protected override T ValidateAndProcess<T>(Task<HttpResponseMessage> response) where T : class
        {
            switch (response.Result.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new TokenExpiredException(_token);

                //todo add more status codes
            }

            return base.ValidateAndProcess<T>(response);
        }

        #region OAuth Token (Private)

        private void ProcessToken()
        {
            _token = GetSessionToken();
            Authorization = $"{_token.TokenType} {_token.AccessToken}";
        }

        private OsuSessionToken _token;

        #endregion
    }
}
