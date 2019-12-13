using Beblue.DataVo.Converters;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.Services.Services
{
    public class SpotifyService : ServiceBase<Disco>, ISpotifyService
    {
        private const string spotifyApiToken = "https://accounts.spotify.com";
        private const string spotifyApi = "https://api.spotify.com/v1";

        private const string clientId = "9a09f83d68024f6aa381866913915f0b";
        private const string clientSecret = "59d1584144074d64bd74b9c0c561a9ce";

        private readonly TokenSpotify _token;
        private readonly List<string> generos = new List<string> { "pop", "mpb", "classical", "rock" };

        /// <summary>
        /// Declaracao das Interfaces
        /// </summary>
        private readonly IDiscoService _discoService;
        private readonly IGeneroService _generoService;
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoItemService _pedidoItemService;
        private readonly ICashbackGeneroService _cashbackGeneroService;

        private readonly DiscoConverter _discoConverter;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="discoRepository"></param>
        public SpotifyService(IDiscoService discoService,                               
                              IGeneroService generoService,
                              IPedidoService pedidoService,
                              IPedidoItemService pedidoItemService,
                              ICashbackGeneroService cashbackGeneroService,
                              DiscoConverter discoConverter) : base(null)
        {
            _generoService = generoService;
            _discoService = discoService;
            _discoConverter = discoConverter;
            _pedidoService = pedidoService;
            _pedidoItemService = pedidoItemService;
            _cashbackGeneroService = cashbackGeneroService;

            _token = GetToken();
        }

        private static TokenSpotify GetToken()
        {
            var client = new RestClient(spotifyApiToken);
            client.Authenticator = new HttpBasicAuthenticator(clientId, clientSecret);
            //
            var request = new RestRequest("/api/token", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            //
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<TokenSpotify>(response.Content);
        }

        public void GetAlbuns()
        {
            var client = new RestClient(spotifyApi);
            //
            var request = new RestRequest("/recommendations", Method.GET);
            request.AddHeader("Host", "api.spotify.com");
            request.AddHeader("Authorization", $"Bearer {_token.Access_Token}");
            request.AddHeader("content-type", "application/json");
            //
            request.AddParameter("limit", "50");
            request.AddParameter("market", "BR");
            //
            var albuns = new List<Disco>();
            foreach (var genero in generos)
            {
                request.AddParameter("seed_genres", genero);
                var response = client.Execute(request);
                var spotifyResult = JObject.Parse(response.Content);
                var albunsSpotify = spotifyResult["tracks"].Children().Select(x => x.ToObject<Disco>()).ToList();
                var generoSpotify = new Genero { Id = Guid.NewGuid().ToString(), Nome = genero };
                //
                albunsSpotify.ForEach(x => x.Genero = generoSpotify);
                albuns.AddRange(albunsSpotify);
            }

            // Limpa tabela de Discos
            _cashbackGeneroService.CleanTable();
            _pedidoItemService.CleanTable();
            _pedidoService.CleanTable();
            _discoService.CleanTable();
            _generoService.CleanTable();

            foreach (var item in albuns)
            {
                _generoService.Add(item.Genero);
            };

            foreach (var item in albuns)
            {
                Random r = new Random();
                Disco _disco = new Disco();

                _disco.GeneroId = item.Genero.Id;
                _disco.Name = item.Name;
                _disco.Preco = Math.Round(50 + r.NextDouble() * (200 - 50), 2);

                _discoService.Add(_disco);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
