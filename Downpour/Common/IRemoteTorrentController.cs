/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using System.IO;

namespace Downpour.Common
{
    public interface IRemoteTorrentController
    { 
        Torrent GetTorrentDetails(string torrentHash);

        IEnumerable<Torrent> GetAllTorrents();

        DownpourResult RemoveTorrent(string torrentHash, bool withData);

        DownpourResult PauseTorrent(string torrentHash);

        DownpourResult ResumeTorrent(string torrentHash);

        AddTorrentResult AddMagnet(string magnetLink);

        AddTorrentResult AddTorrentFile(Stream torrentFile);

        DownpourResult ForceRecheck(string torrentHash);

        long GetFreeSpace();
    }
}