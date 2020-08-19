﻿using BenchmarkDotNet.Attributes;

namespace NetTools.Benchmark
{
    [ShortRunJob]
    public class IPv4EnumerateTest
    {
        [Benchmark]
        public long UsePrevVersion()
        {
            var l = 0L;
            var ipAddressRange = NetTools.PrevVersion.IPAddressRange.Parse("10.0.0.0/8");
            foreach (var item in ipAddressRange.AsEnumerable())
            {
#pragma warning disable CS0618 // Type or member is obsolete
                l |= item.Address;
#pragma warning restore CS0618 // Type or member is obsolete
            }
            return l;
        }

        [Benchmark]
        public long UseLatestVersion()
        {
            var l = 0L;
            var ipAddressRange = NetTools.IPAddressRange.Parse("10.0.0.0/8");
            foreach (var item in ipAddressRange.AsEnumerable())
            {
#pragma warning disable CS0618 // Type or member is obsolete
                l |= item.Address;
#pragma warning restore CS0618 // Type or member is obsolete
            }
            return l;
        }
    }
}
