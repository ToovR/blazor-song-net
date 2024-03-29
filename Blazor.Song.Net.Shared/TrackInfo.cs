﻿using System;
using System.Text.Json.Serialization;

namespace Blazor.Song.Net.Shared
{
    public class TrackInfo
    {
        public string Album { get; set; }
        public string Artist { get; set; }

        [JsonIgnore]
        public bool? ClickMarker { get; set; }

        public int? CollectionId { get; set; }
        public string DownloadPath { get; set; }

        [JsonIgnore]
        public TimeSpan Duration { get; set; }

        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public string SDuration
        {
            get { return Duration.ToString(); }
            set { Duration = TimeSpan.Parse(value); }
        }

        public object SourceObject { get; set; }
        public string Title { get; set; }
    }
}