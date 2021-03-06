﻿using Blazor.Song.Net.Shared;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Blazor.Song.Indexer
{
    public class TrackParser
    {
        private static TrackInfo[] _allTracks;

        private static readonly string _musicDirectoryRoot = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        public string GetTrackData()
        {
            int counter = 0;
            Uri folderRoot = new Uri(_musicDirectoryRoot);

            var trackEnum = Directory.GetFiles(_musicDirectoryRoot, "*.*", SearchOption.AllDirectories)
                .Where(file => Regex.IsMatch(file, ".*\\.(mp3|ogg|flac)$", RegexOptions.IgnoreCase));
            int numberOfTracks = trackEnum.Count();

            _allTracks = trackEnum.AsParallel()
                    .Select((musicFilePath, index) =>
                    {
                        counter++;
                        Console.WriteLine($"progess - {counter * 100 / numberOfTracks}%");
                        return GetTrackInfo(musicFilePath, index, folderRoot);
                    }).ToArray();
            return JsonConvert.SerializeObject(_allTracks);
        }

        public static TrackInfo GetTrackInfo(string musicFilePath, int index, Uri folderRoot)
        {
            FileInfo musicFileInfo = new FileInfo(musicFilePath);
            TagLib.File tagMusicFile = TagLib.File.Create(new TagMusicFile(musicFileInfo.FullName));

            string artist = tagMusicFile.Tag.FirstAlbumArtist ?? tagMusicFile.Tag.AlbumArtistsSort.FirstOrDefault() ?? ((TagLib.NonContainer.File)tagMusicFile).Tag.Performers.FirstOrDefault();
            string title = !string.IsNullOrEmpty(tagMusicFile.Tag.Title) ? tagMusicFile.Tag.Title : Path.GetFileNameWithoutExtension(musicFileInfo.FullName);
            return new TrackInfo
            {
                Album = tagMusicFile.Tag.Album,
                Artist = artist,
                Duration = tagMusicFile.Properties.Duration,
                Id = index,
                Name = musicFileInfo.Name,
                Path = Uri.UnescapeDataString(folderRoot.MakeRelativeUri(new Uri(musicFileInfo.FullName)).ToString().Replace("Music/", "")),
                Title = title,
            };
        }
    }
}