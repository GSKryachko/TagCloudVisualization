using CommandLine;
using CommandLine.Text;

namespace TagsCloudVisualization
{
    class Options
    {
        [Option('c', "count", DefaultValue = 100, HelpText = "How many words should be in cloud")]
        public int Count { get; set; }

        [Option('s', "source", Required = true, HelpText = "Textfile")]
        public string Source { get; set; }

        [Option('d', "dest", Required = true, HelpText = "Output file (without extension")]
        public string Destination { get; set; }

        [Option("hec", DefaultValue = 1, HelpText = "Horizontal extension coefficient")]
        public int HorizontalExtensionCoefficient { get; set; }

        [Option("clr", DefaultValue = "Magenta", HelpText = "Color")]
        public string BrushColor { get; set; }

        [Option('f', "font", DefaultValue = "Arial", HelpText = "Font name")]
        public string FontName { get; set; }

        [Option("bw", DefaultValue = "function-words.txt", HelpText = "File with banned words")]
        public string BannedWords { get; set; }

        [Option("ext", DefaultValue = "png", HelpText = "Output file extension")]
        public string Extension { get; set; }

        [Option("width", DefaultValue = 1000, HelpText = "Output file width")]
        public int Width { get; set; }

        [Option("height", DefaultValue = 1000, HelpText = "Output file height")]
        public int Height { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                (current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

        public static Result<None> CheckOptions(Options options)
        {
            if (options.Source is null || options.Destination is null)
                return Result.Fail<None>("Destination and source are required. Use -h or --help for help");
            if (options.Width <= 0)
                return Result.Fail<None>("Width should be positive");
            if (options.Height <= 0)
                return Result.Fail<None>("Height should be positive");
            return Result.Ok();
        }
    }
}