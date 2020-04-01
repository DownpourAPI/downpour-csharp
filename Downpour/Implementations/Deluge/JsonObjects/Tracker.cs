/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

namespace Downpour.Implementations.Deluge.JsonObjects
{
    public class Tracker
    {
        public bool send_stats { get; set; }
        public int fails { get; set; }
        public bool verified { get; set; }
        public int? min_announce { get; set; }
        public string url { get; set; }
        public int fail_limit { get; set; }
        public int? next_announce { get; set; }
        public bool complete_sent { get; set; }
        public int source { get; set; }
        public bool start_sent { get; set; }
        public int tier { get; set; }
        public bool updating { get; set; }
    }
}