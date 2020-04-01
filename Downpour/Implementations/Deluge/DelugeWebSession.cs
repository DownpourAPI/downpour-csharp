/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using System.IO;
using Downpour.Common;

namespace Downpour.Implementations.Deluge
{
    public class DelugeWebSession : IRemoteTorrentController
    {
        public Torrent GetTorrentDetails(string torrentHash)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Torrent> GetAllTorrents()
        {
            throw new System.NotImplementedException();
        }

        public DownpourResult RemoveTorrent(string torrentHash)
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

        public AddTorrentResult AddTorrentFile(FileInfo torrentFile)
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