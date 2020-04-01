/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.Linq;
using Downpour.Common;

namespace Downpour.Implementations.Rutorrent
{
    public class GetAllTorrentsResponse
    {
        public IDictionary<string, List<string>> T { get; set; }
        public long Cid { get; set; }

        public List<Torrent> ToTorrents()
        {
            return T.Select(entry => new Torrent
                {
                    Hash = entry.Key,
                    Name = entry.Value[4],
                    UploadRate = Convert.ToInt64(entry.Value[11]),
                    DownloadRate = Convert.ToInt64(entry.Value[12]),
                    NumberOfSeeds = Convert.ToInt32(entry.Value[17]),
                    NumberOfPeers = Convert.ToInt32(entry.Value[15]),
                    Ratio = Convert.ToDouble(entry.Value[10]) / 1000,
                    TotalSizeBytes = Convert.ToInt64(entry.Value[5]),
                    Progress = Convert.ToInt64(entry.Value[8]) / Convert.ToInt64(entry.Value[5]) * 100,
                    State = entry.Value[34],
                    TimeAdded = Convert.ToInt64(entry.Value[21]),
                    TotalDownloaded = Convert.ToInt64(entry.Value[8]),
                    TotalUploaded = Convert.ToInt64(entry.Value[9]),
                    Files = new List<FileDetails>(),
                    RemotePath = entry.Value[25].Replace("\\", "")
                })
            .ToList();
        }
    }
}