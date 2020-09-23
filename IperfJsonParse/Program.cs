using CommandLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Iperf3JsonParse
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sourceFilePath = @"";
            var outputFilePath = @"";
            var showHeaders = true;
            var appendToFile = false;

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    if (o.OutputFile == string.Empty || o.File == string.Empty)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        sourceFilePath = o.File;
                        outputFilePath = o.OutputFile;
                        showHeaders = o.ShowHeaders;
                        appendToFile = o.Append;
                    }
                });

            if (sourceFilePath == string.Empty || outputFilePath == string.Empty) Environment.Exit(0);

            Console.WriteLine("Source File:" + sourceFilePath);
            Console.WriteLine("Output File:" + outputFilePath);
            Console.WriteLine("Print Headers:" + showHeaders);

            var allFileContents = File.ReadAllText(sourceFilePath);
            var iperf3Log = JsonConvert.DeserializeObject<IperfData>(allFileContents);

            var outputDataList = new List<ResultStatistics>();

            foreach (var interval in iperf3Log.Intervals)
                foreach (var streams in interval.Streams)
                {
                    var iperf3Statistics = new ResultStatistics
                    {
                        Socket = streams.Socket,
                        OutOfOrder = streams.OutOfOrder,
                        BitsPerSecond = streams.BitsPerSecond,
                        LostPackets = streams.LostPackets,
                        Jitter = streams.JitterMs
                    };
                    outputDataList.Add(iperf3Statistics);
                }

            if (!appendToFile)
            {
                File.WriteAllText(outputFilePath, string.Empty);  // Zero out the file //
                if (showHeaders) File.AppendAllText(outputFilePath, ResultStatistics.Headers());
            }

            foreach (var groupedT in outputDataList.GroupBy(x => x.Socket))
            {
                var tlist = groupedT.ToList();

                foreach (var l in tlist) File.AppendAllText(outputFilePath, l.ToString());
            }

            Console.WriteLine("Done");
        }
    }

    public class Options
    {
        [Option('f', "file", Default = "", Required = true, HelpText = "Source json file to parse.")]
        public string File { get; set; }

        [Option('o', "output", Default = "", Required = true, HelpText = "Output file name.")]
        public string OutputFile { get; set; }

        [Option('h', "header", Default = false, Required = false, HelpText = "Show headers.")]
        public bool ShowHeaders { get; set; }

        [Option('a', "append", Default = false, Required = false, HelpText = "Append to file.")]
        public bool Append { get; set; }
    }
}