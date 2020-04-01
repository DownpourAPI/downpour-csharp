/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.Linq;
using Downpour.Common;

namespace Downpour.Implementations.Deluge.JsonObjects
{
    public class DelugeTorrent
    {
        public string Comment { get; set; }

        //  @SerialName("active_time")
        public int ActiveTime { get; set; }

        //  @SerialName("is_seed")
        public bool IsSeed { get; set; }

        public string Hash { get; set; }

        //  @SerialName("upload_payload_rate")
        public long UploadPayloadRate { get; set; }

        //  @SerialName("move_completed_path")
        public string MoveCompletedPath { get; set; }

        //  @SerialName("private")
        public bool IsPrivate { get; set; }

        //  @SerialName("total_payload_upload")
        public long TotalPayloadUpload { get; set; }

        public bool Paused { get; set; }

        //  @SerialName("seed_rank")
        public int SeedRank { get; set; }

        //  @SerialName("seeding_time")
        public int SeedingTime { get; set; }

        //  @SerialName("max_upload_slots")
        public int MaxUploadSlots { get; set; }

        //  @SerialName("prioritize_first_last")
        public bool PrioritizeFirstAndLastChunks { get; set; }

        //  @SerialName("distributed_copies")
        public double DistributedCopies { get; set; }

        //  @SerialName("download_payload_rate")
        public long DownloadPayloadRate { get; set; }

        public string Message { get; set; }

        //  @SerialName("num_peers")
        public int NumberOfPeers { get; set; }

        //  @SerialName("max_download_speed")
        public double MaxDownloadSpeed { get; set; }

        //  @SerialName("max_connections")
        public int MaxConnections { get; set; }

        public bool Compact { get; set; }

        public double Ratio { get; set; }

        //  @SerialName("total_peers")
        public int TotalPeers { get; set; }

        //  @SerialName("total_size")
        public long TotalSize { get; set; }

        //  @SerialName("total_wanted")
        public long TotalWanted { get; set; }

        public string State { get; set; }

        //  @SerialName("file_priorities")
        public IEnumerable<int> FilePriorities { get; set; }

        //  @SerialName("max_upload_speed")
        public double MaxUploadSpeed { get; set; }

        //  @SerialName("remove_at_ratio")
        public bool WillRemoveAtRatio { get; set; }

        public string Tracker { get; set; }

        //  @SerialName("save_path")
        public string SavePath { get; set; }

        public double Progress { get; set; }

        //  @SerialName("time_added")
        public double TimeAdded { get; set; }

        //  @SerialName("tracker_host")
        public string TrackerHost { get; set; }

        //  @SerialName("total_uploaded")
        public long TotalUploaded { get; set; }

        public IEnumerable<FileInTorrent> Files { get; set; }

        //  @SerialName("total_done")
        public long TotalDone { get; set; }

        //  @SerialName("num_pieces")
        public int NumberOfPieces { get; set; }

        //  @SerialName("tracker_status")
        public string TrackerStatus { get; set; }

        //  @SerialName("total_seeds")
        public int TotalSeeds { get; set; }

        //  @SerialName("move_on_completed")
        public bool WillMoveOnCompletion { get; set; }

        //  @SerialName("next_announce")
        public int NextAnnounce { get; set; }

        //  @SerialName("stop_at_ratio")
        public bool WillStopAtRatio { get; set; }

        //  @SerialName("file_progress")
        public IEnumerable<double> FileProgress { get; set; }

        //  @SerialName("move_completed")
        public bool MoveOnCompletion { get; set; }

        //  @SerialName("piece_length")
        public int PieceLength { get; set; }

        //  @SerialName("all_time_download")
        public long AllTimeDownload { get; set; }

        //  @SerialName("move_on_completed_path")
        public string MoveOnCompletedPath { get; set; }

        //  @SerialName("num_seeds")
        public int NumberOfSeeds { get; set; }

        public IEnumerable<string> Peers { get; set; }

        public string Name { get; set; }

        public IEnumerable<Tracker> Trackers { get; set; }

        //  @SerialName("total_payload_download")
        public long TotalPayloadDownload { get; set; }

        //  @SerialName("is_auto_managed")
        public bool IsAutoManaged { get; set; }

        //  @SerialName("seeds_peers_ratio")
        public double SeedsToPeersRatio { get; set; }

        public int Queue { get; set; }

        //  @SerialName("num_files")
        public int NumberOfFiles { get; set; }

        public int Eta { get; set; }

        //  @SerialName("stop_ratio")
        public double StopAtRatio { get; set; }

        //  @SerialName("is_finished")
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