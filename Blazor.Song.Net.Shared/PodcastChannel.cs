﻿using System;

namespace Blazor.Song.Net.Shared
{
    public class PodcastChannel
    {
        public string ArtistName { get; set; }
        public string ArtworkUrl100 { get; set; }
        public string ArtworkUrl30 { get; set; }
        public string ArtworkUrl60 { get; set; }
        public string ArtworkUrl600 { get; set; }
        public string CollectionCensoredName { get; set; }
        public string CollectionExplicitness { get; set; }
        public double CollectionHdPrice { get; set; }
        public int CollectionId { get; set; }
        public string CollectionName { get; set; }
        public double CollectionPrice { get; set; }
        public string CollectionViewUrl { get; set; }
        public string ContentAdvisoryRating { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string FeedUrl { get; set; }
        public string[] GenreIds { get; set; }
        public string[] Genres { get; set; }
        public bool IsLoading { get; set; }
        public string Kind { get; set; }
        public string PrimaryGenreName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string TrackCensoredName { get; set; }
        public int TrackCount { get; set; }
        public string TrackExplicitness { get; set; }
        public double TrackHdPrice { get; set; }
        public double TrackHdRentalPrice { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public double TrackPrice { get; set; }
        public double TrackRentalPrice { get; set; }
        public string TrackViewUrl { get; set; }
        public string WrapperType { get; set; }
    }
}