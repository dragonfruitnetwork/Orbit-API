﻿// Orbit API Copyright 2020 DragonFruit Network
// Licensed under the MIT License - see the LICENSE file at the root of the project for more info

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Handlers;
using DragonFruit.Orbit.API.Exceptions;
using DragonFruit.Orbit.API.Legacy;
using DragonFruit.Orbit.API.Objects.Auth;
using DragonFruit.Orbit.API.Requests;

#nullable enable

namespace DragonFruit.Orbit.API
{
    public abstract class OrbitClient : ApiClient
    {
        protected abstract OsuSessionTokenBase GetSessionToken();

        /// <summary>
        /// Initialises a new <see cref="OrbitClient"/>
        /// </summary>
        protected OrbitClient()
            : this(new HttpClientHandler())
        {
        }

        /// <summary>
        /// Initialises a new <see cref="OrbitClient"/> with a specific <see cref="HttpMessageHandler"/>
        /// </summary>
        protected OrbitClient(HttpMessageHandler handler)
        {
            //some urls like "/users/papacurry" redirect to another url.
            //the normal handler will strip the auth header giving us a 401...
            switch (handler)
            {
                case HeaderPreservingRedirectHandler _:
                    Handler = handler;
                    break;

                default:
                    Handler = new HeaderPreservingRedirectHandler(handler);
                    break;
            }
        }

        #region APIv2 OAuth

        protected virtual string ClientId { get; }
        protected virtual string ClientSecret { get; }

        public OsuSessionToken Perform<T>(T requestData) where T : OsuAuthRequest
        {
            //inject the clientid and secret if they haven't been set
            if (string.IsNullOrEmpty(requestData.ClientSecret))
            {
                requestData.ClientId = ClientId;
                requestData.ClientSecret = ClientSecret;
            }

            //bypass the _token checks as we're getting them now...
            return base.Perform<OsuSessionToken>(requestData);
        }

        #endregion

        #region Legacy Requests

        /// <summary>
        /// Global Legacy API key, can be obtained from https://old.ppy.sh/p/api
        /// </summary>
        protected virtual string LegacyApiKey { get; }

        /// <summary>
        /// Perform a legacy request, returning the result as an <see cref="IEnumerable{T}"/>.
        /// </summary>
        public IEnumerable<T> Perform<T>(LegacyEnumerableResponseRequest requestData) where T : class
        {
            InjectLegacyApiKey(requestData);
            return base.Perform<IEnumerable<T>>(requestData);
        }

        /// <summary>
        /// Perform a legacy request
        /// </summary>
        public T Perform<T>(LegacyRequest requestData) where T : class
        {
            InjectLegacyApiKey(requestData);
            return base.Perform<T>(requestData);
        }

        private void InjectLegacyApiKey(LegacyRequest requestData)
        {
            if (string.IsNullOrEmpty(requestData.ApiKey))
            {
                requestData.ApiKey = LegacyApiKey ?? throw new LegacyApiException("Legacy API Request attempted with no key");
            }
        }

        #endregion

        #region API v2 Auth

        protected void ProcessToken()
        {
            _token = GetSessionToken();
            Authorization = $"{_token!.TokenType} {_token.AccessToken}";
        }

        private OsuSessionTokenBase? _token;

        #endregion

        public virtual T Perform<T>(OrbitApiRequest requestData) where T : class
        {
            if (_token?.Expired ?? true)
            {
                ProcessToken();
            }

            return base.Perform<T>(requestData);
        }

        protected override T ValidateAndProcess<T>(HttpResponseMessage response, HttpRequestMessage request) where T : class =>
            response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => throw new TokenExpiredException(_token),
                _ => base.ValidateAndProcess<T>(response, request)
            };
    }
}
