/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

namespace Downpour.Common
{
    public class AddTorrentResult
    {
        public AddTorrentStatus Status { get; }
        
        public string Hash { get; }

        private AddTorrentResult(AddTorrentStatus status, string hash = null)
        {
            Status = status;
            Hash = hash;
        }

        public static AddTorrentResult Success(string torrentHash)
        {
            return new AddTorrentResult(AddTorrentStatus.Success, torrentHash);
        }
        
        public static AddTorrentResult Failure()
        {
            return new AddTorrentResult(AddTorrentStatus.Failure);
        }
        
        public static AddTorrentResult AlreadyExists()
        {
            return new AddTorrentResult(AddTorrentStatus.AlreadyExists);
        }
    }
}