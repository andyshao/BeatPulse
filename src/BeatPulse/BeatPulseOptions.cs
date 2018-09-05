﻿using System;

namespace BeatPulse
{
    public class BeatPulseOptions
    {
        internal bool DetailedOutput { get; private set; }

        internal string BeatPulsePath { get; private set; }

        internal int Timeout { get; private set; }

        internal int CacheDuration { get; private set; }

        internal bool CacheOutput { get; private set; }

        internal CacheMode CacheMode { get; private set; }

        public BeatPulseOptions()
        {
            DetailedOutput = false;
            BeatPulsePath = BeatPulseKeys.BEATPULSE_DEFAULT_PATH;
            Timeout = -1; // wait infinitely
            CacheOutput = false;
            CacheDuration = 0;
            CacheMode = CacheMode.Header;
        }

        internal BeatPulseOptions(bool detailedOutput, string path, int timeout, bool cacheoutput, int cacheDuration, CacheMode cacheMode)
        {
            DetailedOutput = detailedOutput;
            BeatPulsePath = path;
            Timeout = timeout;
            CacheOutput = cacheoutput;
            CacheDuration = cacheDuration;
            CacheMode = cacheMode;
        }

        public BeatPulseOptions ConfigureOutputCache(int seconds, CacheMode mode = CacheMode.Header)
        {
            CacheDuration = seconds;
            CacheOutput = true;
            CacheMode = mode;

            return this;
        }

        public BeatPulseOptions ConfigureDetailedOutput(bool detailedOutput = true)
        {
            DetailedOutput = detailedOutput;

            return this;
        }

        public BeatPulseOptions ConfigurePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            BeatPulsePath = path;

            return this;
        }

        public BeatPulseOptions ConfigureTimeout(int milliseconds)
        {
            Timeout = milliseconds;

            return this;
        }
    }
}