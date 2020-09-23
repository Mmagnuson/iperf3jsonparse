using System;
using System.Globalization;

namespace Iperf3JsonParse
{
    public class ResultStatistics
    {
        public long? Socket { get; set; }
        public double Jitter { get; set; }
        public long LostPackets { get; set; }
        public long? OutOfOrder { get; set; }
        public double BitsPerSecond { get; set; }

        public override string ToString()
        {
            return Socket + "," + Jitter.ToString(CultureInfo.InvariantCulture) + "," + LostPackets + "," +
                   OutOfOrder + "," + BitsPerSecond + Environment.NewLine;
        }

        public static string Headers()
        {
            return "Socket,Jitter,LostPackets,OutOfOrder,BitsPerSecond" + Environment.NewLine;
        }
    }
}