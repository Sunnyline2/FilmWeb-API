﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public sealed class HttpExecute : IHttpExecute
    {
        private readonly HttpClient _httpClient;

        public HttpExecute(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Execute(HttpRequestMessage message, CancellationToken token = default)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return await _httpClient.SendAsync(message, token).ConfigureAwait(false);
        }
    }
}