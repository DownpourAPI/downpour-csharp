/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.Linq;
using Downpour.Common;
using Newtonsoft.Json;

namespace Downpour.Implementations.Deluge.JsonObjects
{
    public class DelugeTorrent
    {
        public string Comment { get; set; }

        [JsonProperty("active_time")]
        public int ActiveTime { get; set; }

        [JsonProperty("is_seed")]
        public bool IsSeed { get; set; }

        public string Hash { get; set; }

        [JsonProperty("upload_payload_rate")]
        public long UploadPayloadRate { get; set; }

        [JsonProperty("move_completed_path")]
        public string MoveCompletedPath { get; set; }

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("total_payload_upload")]
        public long TotalPayloadUpload { get; set; }

        public bool Paused { get; set; }

        [JsonProperty("seed_rank")]
        public int SeedRank { get; set; }

        [JsonProperty("seeding_time")]
        public int SeedingTime { get; set; }

        [JsonProperty("max_upload_slots")]
        public int MaxUploadSlots { get; set; }

        [JsonProperty("prioritize_first_last")]
        public bool PrioritizeFirstAndLastChunks { get; set; }

        [JsonProperty("distributed_copies")]
        public double DistributedCopies { get; set; }

        [JsonProperty("download_payload_rate")]
        public long DownloadPayloadRate { get; set; }

        public string Message { get; set; }

        [JsonProperty("num_peers")]
        public int NumberOfPeers { get; set; }

        [JsonProperty("max_download_speed")]
        public double MaxDownloadSpeed { get; set; }

        [JsonProperty("max_connections")]
        public int MaxConnections { get; set; }

        public bool Compact { get; set; }

        public double Ratio { get; set; }

        [JsonProperty("total_peers")]
        public int TotalPeers { get; set; }

        [JsonProperty("total_size")]
        public long TotalSize { get; set; }

        [JsonProperty("total_wanted")]
        public long TotalWanted { get; set; }

        public string State { get; set; }

        [JsonProperty("file_priorities")]
        public IEnumerable<int> FilePriorities { get; set; }

        [JsonProperty("max_upload_speed")]
        public double MaxUploadSpeed { get; set; }

        [JsonProperty("remove_at_ratio")]
        public bool WillRemoveAtRatio { get; set; }

        public string Tracker { get; set; }

        [JsonProperty("save_path")]
        public string SavePath { get; set; }

        public double Progress { get; set; }

        [JsonProperty("time_added")]
        public double TimeAdded { get; set; }

        [JsonProperty("tracker_host")]
        public string TrackerHost { get; set; }

        [JsonProperty("total_uploaded")]
        public long TotalUploaded { get; set; }

        public IEnumerable<FileInTorrent> Files { get; set; }

        [JsonProperty("total_done")]
        public long TotalDone { get; set; }

        [JsonProperty("num_pieces")]
        public int NumberOfPieces { get; set; }

        [JsonProperty("tracker_status")]
        public string TrackerStatus { get; set; }

        [JsonProperty("total_seeds")]
        public int TotalSeeds { get; set; }

        [JsonProperty("move_on_completed")]
        public bool WillMoveOnCompletion { get; set; }

        [JsonProperty("next_announce")]
        public int NextAnnounce { get; set; }

        [JsonProperty("stop_at_ratio")]
        public bool WillStopAtRatio { get; set; }

        [JsonProperty("file_progress")]
        public IEnumerable<double> FileProgress { get; set; }

        [JsonProperty("move_completed")]
        public bool MoveOnCompletion { get; set; }

        [JsonProperty("piece_length")]
        public int PieceLength { get; set; }

        [JsonProperty("all_time_download")]
        public long AllTimeDownload { get; set; }

        [JsonProperty("move_on_completed_path")]
        public string MoveOnCompletedPath { get; set; }

        [JsonProperty("num_seeds")]
        public int NumberOfSeeds { get; set; }

        public IEnumerable<string> Peers { get; set; }

        public string Name { get; set; }

        public IEnumerable<Tracker> Trackers { get; set; }

        [JsonProperty("total_payload_download")]
        public long TotalPayloadDownload { get; set; }

        [JsonProperty("is_auto_managed")]
        public bool IsAutoManaged { get; set; }

        [JsonProperty("seeds_peers_ratio")]
        public double SeedsToPeersRatio { get; set; }

        public int Queue { get; set; }

        [JsonProperty("num_files")]
        public int NumberOfFiles { get; set; }

        public int Eta { get; set; }

        [JsonProperty("stop_ratio")]
        public double StopAtRatio { get; set; }

        [JsonProperty("is_finished")]
        public bool IsFinished { get; set; }

        public Torrent ToTorrent()
        {
            return new Torrent
            {
                DownloadRate = DownloadPayloadRate,
                UploadRate = UploadPayloadRate,
                Files = Files.Select(f => f.ToFileDetails()),
                Hash = Hash,
                Name = Name,
                NumberOfPeers = NumberOfPeers,
                NumberOfSeeds = NumberOfSeeds,
                Progress = Progress,
                Ratio = Ratio,
                RemotePath = SavePath,
                State = State,
                TimeAdded = TimeAdded,
                TotalDownloaded = TotalDone,
                TotalUploaded = TotalDone,
                TotalSizeBytes = TotalSize
            };
        }
    }
}