/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https { get; set; } */

using System.Collections.Generic;

namespace Downpour.Common
{
    public class Torrent
    {
        public string Hash { get; set; }
        public string Name { get; set; }
        public long UploadRate { get; set; }
        public long DownloadRate { get; set; }
        public int NumberOfSeeds { get; set; }
        public int NumberOfPeers { get; set; }
        public double Ratio { get; set; }
        public long TotalSizeBytes { get; set; }
        public double Progress { get; set; }
        public string State { get; set; }
        public double TimeAdded { get; set; }
        public long TotalDownloaded { get; set; }
        public long TotalUploaded { get; set; }
        public IList<FileDetails> Files { get; set; }
        public string RemotePath { get; set; }
    }
}