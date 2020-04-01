/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

namespace Downpour.Common
{
    public class FileDetails
    {
        public string Name { get; set; }
        public long Size { get; set; }

        public FileDetails(string name, long size)
        {
            Name = name;
            Size = size;
        }
    }
}