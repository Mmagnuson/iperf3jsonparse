using Newtonsoft.Json;

namespace Iperf3JsonParse
{
    public class IperfData
    {
        [JsonProperty("start")] public Start Start { get; set; }

        [JsonProperty("intervals")] public Interval[] Intervals { get; set; }

        [JsonProperty("end")] public End End { get; set; }
    }

    public class End
    {
        [JsonProperty("streams")] public Stream[] Streams { get; set; }

        [JsonProperty("sum")] public Sum Sum { get; set; }

        [JsonProperty("cpu_utilization_percent")]
        public CpuUtilizationPercent CpuUtilizationPercent { get; set; }
    }

    public class CpuUtilizationPercent
    {
        [JsonProperty("host_total")] public double HostTotal { get; set; }

        [JsonProperty("host_user")] public double HostUser { get; set; }

        [JsonProperty("host_system")] public double HostSystem { get; set; }

        [JsonProperty("remote_total")] public long RemoteTotal { get; set; }

        [JsonProperty("remote_user")] public long RemoteUser { get; set; }

        [JsonProperty("remote_system")] public long RemoteSystem { get; set; }
    }

    public class Stream
    {
        [JsonProperty("udp")] public Sum Udp { get; set; }
    }

    public class Sum
    {
        [JsonProperty("socket", NullValueHandling = NullValueHandling.Ignore)]
        public long? Socket { get; set; }

        [JsonProperty("start")] public double Start { get; set; }

        [JsonProperty("end")] public double End { get; set; }

        [JsonProperty("seconds")] public double Seconds { get; set; }

        [JsonProperty("bytes")] public long Bytes { get; set; }

        [JsonProperty("bits_per_second")] public double BitsPerSecond { get; set; }

        [JsonProperty("jitter_ms")] public double JitterMs { get; set; }

        [JsonProperty("lost_packets")] public long LostPackets { get; set; }

        [JsonProperty("packets")] public long Packets { get; set; }

        [JsonProperty("lost_percent")] public long LostPercent { get; set; }

        [JsonProperty("out_of_order", NullValueHandling = NullValueHandling.Ignore)]
        public long OutOfOrder { get; set; }

        [JsonProperty("omitted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Omitted { get; set; }
    }

    public class Interval
    {
        [JsonProperty("streams")] public Sum[] Streams { get; set; }

        [JsonProperty("sum")] public Sum Sum { get; set; }
    }

    public class Start
    {
        [JsonProperty("connected")] public Connected[] Connected { get; set; }

        [JsonProperty("version")] public string Version { get; set; }

        [JsonProperty("system_info")] public string SystemInfo { get; set; }

        [JsonProperty("timestamp")] public Timestamp Timestamp { get; set; }

        [JsonProperty("accepted_connection")] public AcceptedConnection AcceptedConnection { get; set; }

        [JsonProperty("cookie")] public string Cookie { get; set; }

        [JsonProperty("sock_bufsize")] public long SockBufsize { get; set; }

        [JsonProperty("sndbuf_actual")] public long SndbufActual { get; set; }

        [JsonProperty("rcvbuf_actual")] public long RcvbufActual { get; set; }

        [JsonProperty("test_start")] public TestStart TestStart { get; set; }
    }

    public class AcceptedConnection
    {
        [JsonProperty("host")] public string Host { get; set; }

        [JsonProperty("port")] public long Port { get; set; }
    }

    public class Connected
    {
        [JsonProperty("socket")] public long Socket { get; set; }

        [JsonProperty("local_host")] public string LocalHost { get; set; }

        [JsonProperty("local_port")] public long LocalPort { get; set; }

        [JsonProperty("remote_host")] public string RemoteHost { get; set; }

        [JsonProperty("remote_port")] public long RemotePort { get; set; }
    }

    public class TestStart
    {
        [JsonProperty("protocol")] public string Protocol { get; set; }

        [JsonProperty("num_streams")] public long NumStreams { get; set; }

        [JsonProperty("blksize")] public long Blksize { get; set; }

        [JsonProperty("omit")] public long Omit { get; set; }

        [JsonProperty("duration")] public long Duration { get; set; }

        [JsonProperty("bytes")] public long Bytes { get; set; }

        [JsonProperty("blocks")] public long Blocks { get; set; }

        [JsonProperty("reverse")] public long Reverse { get; set; }

        [JsonProperty("tos")] public long Tos { get; set; }
    }

    public class Timestamp
    {
        [JsonProperty("time")] public string Time { get; set; }

        [JsonProperty("timesecs")] public long Timesecs { get; set; }
    }
}