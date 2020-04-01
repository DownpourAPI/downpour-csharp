﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

namespace Downpour.Implementations.Deluge.JsonObjects
{
    public class AddMagnetResponse
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public ResponseError? Error { get; set; }
    }
}