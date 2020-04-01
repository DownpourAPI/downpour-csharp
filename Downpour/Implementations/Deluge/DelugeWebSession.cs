/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Downpour.Common;
using Downpour.Implementations.Deluge.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;

namespace Downpour.Implementations.Deluge
{
    public class DelugeWebSession : IRemoteTorrentController
    {
        private readonly RestClient _client;
        
        public DelugeWebSession(string basePath, string password)
        {
            _client = new RestClient(basePath) { CookieContainer = new CookieContainer() };
            Login(password);
        }

        private void Login(string password)
        {
            string body = $"{{\"id\":1,\"method\":\"auth.login\",\"params\":[\"{password}\"]}}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
        }
        
        public Torrent GetTorrentDetails(string torrentHash)
        {
            string body = $"{{\"id\":1,\"method\":\"core.get_torrent_status\",\"params\":[\"{torrentHash}\", []]}}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            var responseObject = JsonConvert.DeserializeObject<GetTorrentResponse>(response.Content);

            return responseObject.Result.ToTorrent();
        }

        public IEnumerable<Torrent> GetAllTorrents()
        {
            const string body = "{\"id\":1,\"method\":\"core.get_torrents_status\",\"params\":[{},[]]}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            var responseObject = JsonConvert.DeserializeObject<GetAllTorrentsResponse>(response.Content);

            return responseObject.Result.Values.Select(t => t.ToTorrent()).ToList();
        }

        public DownpourResult RemoveTorrent(string torrentHash, bool withData)
        {
            string body = $"{{\"id\":1,\"method\":\"core.remove_torrent\",\"params\":[\"{torrentHash}\",{withData}]}}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            
            var responseObject = JsonConvert.DeserializeObject<DelugeResponse>(response.Content);

            if (responseObject.Result != null && responseObject.Result == true)
            {
                return DownpourResult.Success;
            }

            return DownpourResult.Failure;
        }

        public DownpourResult PauseTorrent(string torrentHash)
        {
            string body = $"{{\"id\":1,\"method\":\"core.pause_torrent\",\"params\":[\"{torrentHash}\"]}}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            
            var responseObject = JsonConvert.DeserializeObject<DelugeResponse>(response.Content);

            if (responseObject.Result != null && responseObject.Result == true)
            {
                return DownpourResult.Success;
            }

            return DownpourResult.Failure;
        }

        public DownpourResult ResumeTorrent(string torrentHash)
        {
            string body = $"{{\"id\":1,\"method\":\"core.resume_torrent\",\"params\":[\"{torrentHash}\"]}}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            
            var responseObject = JsonConvert.DeserializeObject<DelugeResponse>(response.Content);

            if (responseObject.Result != null && responseObject.Result == true)
            {
                return DownpourResult.Success;
            }

            return DownpourResult.Failure;
        }

        public AddTorrentResult AddMagnet(string magnetLink)
        {
            string body = $"{{\"id\":1,\"method\":\"core.add_torrent_magnet\",\"params\":[\"{magnetLink}\",{{}}]}}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            
            var responseObject = JsonConvert.DeserializeObject<AddTorrentResult>(response.Content);

            switch (responseObject.Status)
            {
                case AddTorrentStatus.Success:
                    return AddTorrentResult.Success(responseObject.Hash);
                case AddTorrentStatus.AlreadyExists:
                    return AddTorrentResult.AlreadyExists();
                case AddTorrentStatus.Failure:
                    return AddTorrentResult.Failure();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public AddTorrentResult AddTorrentFile(Stream torrentFile)
        {
            byte[] fileArray;
            using (var ms = new MemoryStream())
            {
                torrentFile.CopyTo(ms);
                fileArray = ms.ToArray();
            }
            
            string fileB64 = Convert.ToBase64String(fileArray);
            string body = $"{{\"id\":1,\"method\":\"core.add_torrent_file\",\"params\":[\"file\",\"{fileB64}\",{{}}]}}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            
            var responseObject = JsonConvert.DeserializeObject<AddTorrentResult>(response.Content);

            switch (responseObject.Status)
            {
                case AddTorrentStatus.Success:
                    return AddTorrentResult.Success(responseObject.Hash);
                case AddTorrentStatus.AlreadyExists:
                    return AddTorrentResult.AlreadyExists();
                case AddTorrentStatus.Failure:
                    return AddTorrentResult.Failure();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public DownpourResult ForceRecheck(string torrentHash)
        {
            string body = $"{{\"id\":1,\"method\":\"core.force_recheck\",\"params\":[[\"{torrentHash}\"]]}}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            
            var responseObject = JsonConvert.DeserializeObject<DelugeResponse>(response.Content);

            if (responseObject.Result != null && responseObject.Result == true)
            {
                return DownpourResult.Success;
            }

            return DownpourResult.Failure;
        }

        public long GetFreeSpace()
        {
            const string body = "{\"id\":1,\"method\":\"core.get_free_space\",\"params\":[]}";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            
            var responseObject = JsonConvert.DeserializeObject<GetFreeSpaceResponse>(response.Content);

            return responseObject?.Result ?? -1;
        }
    }
}