﻿using Blazor.Song.Net.Services;
using Blazor.Song.Net.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Song.Net.Controllers
{
    [Route("api/[controller]")]
    public class PodcastController : ControllerBase
    {
        private readonly IPodcastStore _podcastStore;

        public PodcastController(IPodcastStore podcastStore)
        {
            _podcastStore = podcastStore;
        }

        [HttpGet("[action]")]
        public PodcastChannel[] Channels(string filter)
        {
            PodcastChannel[] channels = _podcastStore.GetChannels(filter);
            return channels;
        }

        [HttpGet("[action]")]
        [ResponseCache(Duration = 3600)]
        public async Task<ActionResult> GetChannelEpisode(int collectionId, long id)
        {
            byte[]? file = await _podcastStore.GetChannelEpisodeFile(collectionId, id);
            return File(file, "audio/mpeg");
        }

        [HttpGet("[action]")]
        public async Task<Feed> GetChannelEpisodes(Int64 collectionId)
        {
            Feed feed = await _podcastStore.GetChannelEpisodes(collectionId);
            return feed;
        }

        [HttpGet("[action]")]
        public async Task<PodcastChannelResponse> NewChannels(string filter)
        {
            PodcastChannelResponse channels = await _podcastStore.GetNewChannels(filter);
            return channels;
        }

        [HttpPost("[action]")]
        public async Task NewChannels([FromBody] PodcastChannel podcast)
        {
            await _podcastStore.AddNewChannel(podcast);
        }
    }
}