/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using System.IO;

namespace Downpour.Common
{
    public interface IRemoteTorrentController
    { 
        public Torrent GetTorrentDetails(string torrentHash);

        public IEnumerable<Torrent> GetAllTorrents();

        public DownpourResult RemoveTorrent(string torrentHash);

        public DownpourResult PauseTorrent(string torrentHash);

        public DownpourResult ResumeTorrent(string torrentHash);

        public AddTorrentResult AddMagnet(string magnetLink);

        public AddTorrentResult AddTorrentFile(FileInfo torrentFile);

        public DownpourResult ForceRecheck(string torrentHash);

        public long GetFreeSpace();
    }
}