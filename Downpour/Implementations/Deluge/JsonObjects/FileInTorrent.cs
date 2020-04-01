/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using Downpour.Common;

namespace Downpour.Implementations.Deluge.JsonObjects
{
    public class FileInTorrent
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public long Offset { get; set; }
        public long Size { get; set; }

        public FileDetails ToFileDetails()
        {
            return new FileDetails(Path, Size);
        }
    }
}