/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Downpour.Common;
using RestSharp;

namespace Downpour.Implementations.Rutorrent
{
    public class RutorrentSession : IRemoteTorrentController
    {
        private readonly RestClient _client;
        private readonly string _authHeader;
        
        public RutorrentSession(string basePath, string user, string password)
        {
            _client = new RestClient(basePath);
            _authHeader = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{user}:{password}"));
        }
        
        public Torrent GetTorrentDetails(string torrentHash)
        {
            var request = new RestRequest("/plugins/httprpc/action.php", Method.POST);
            request.AddHeader("Authorization", _authHeader);
            request.AddXmlBody(
	            $@"<?xml version='1.0'?>
                <methodCall>
                	<methodName>system.multicall</methodName>
                	<params>
                		<param>
                			<value>
                			<array>
                				<data>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.name</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.up.rate</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.down.rate</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.get_peers_complete</string> <!-- Seeders -->
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.get_peers_accounted</string> <!-- Peers -->
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.ratio</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.size_bytes</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.connection_current</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.state</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.is_active</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.timestamp.started</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.completed_bytes</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.up.total</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                					<value>
                						<struct>
                							<member>
                								<name>methodName</name>
                								<value>
                									<string>d.base_path</string>
                								</value>
                							</member>
                							<member>
                								<name>params</name>
                								<value>
                									<array>
                										<data>
                											<value>
                												<string>{torrentHash}</string>
                											</value>
                										</data>
                									</array>
                								</value>
                							</member>
                						</struct>
                					</value>
                				</data>
                			</array>
                			</value>
                		</param>
                	</params>
                </methodCall>");
            var response = _client.Execute(request);

            if (string.IsNullOrEmpty(response.Content)) return null;
            
            const string pattern = "<(?:string|i8)>(.*?)<";

            var results = Regex.Matches(response.Content, pattern).Cast<Match>();

            var resultValues = results.Select(m => m.Groups[1].Value).ToList();

            if (resultValues.Any(rv => rv == "Unsupported target type found."))
            {
	            throw new Exception("Unsupported target type found. Is your info-hash correct?");
            }
	            
            return new Torrent
            {
	            Hash = torrentHash,
	            Name = resultValues[0],
	            UploadRate = long.Parse(resultValues[1]),
	            DownloadRate = long.Parse(resultValues[2]),
	            NumberOfSeeds = int.Parse(resultValues[3]),
	            NumberOfPeers = int.Parse(resultValues[4]),
	            Ratio = double.Parse(resultValues[5]) / 1000,
	            TotalSizeBytes = long.Parse(resultValues[6]),
	            Progress = (double.Parse(resultValues[11]) / double.Parse(resultValues[6])) * 100,
	            State = resultValues[7],
	            TimeAdded = double.Parse(resultValues[10]),
	            TotalDownloaded = long.Parse(resultValues[11]),
	            TotalUploaded = long.Parse(resultValues[12]),
	            Files = new List<FileDetails>(),
	            RemotePath = resultValues[13]
            };

        }

        public IEnumerable<Torrent> GetAllTorrents()
        {
            throw new System.NotImplementedException();
        }

        public DownpourResult RemoveTorrent(string torrentHash, bool withData)
        {
            throw new System.NotImplementedException();
        }

        public DownpourResult PauseTorrent(string torrentHash)
        {
            throw new System.NotImplementedException();
        }

        public DownpourResult ResumeTorrent(string torrentHash)
        {
            throw new System.NotImplementedException();
        }

        public AddTorrentResult AddMagnet(string magnetLink)
        {
            throw new System.NotImplementedException();
        }

        public AddTorrentResult AddTorrentFile(Stream torrentFile)
        {
            throw new System.NotImplementedException();
        }

        public DownpourResult ForceRecheck(string torrentHash)
        {
            throw new System.NotImplementedException();
        }

        public long GetFreeSpace()
        {
            throw new System.NotImplementedException();
        }
    }
}