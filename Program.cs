using System;
using System.Collections.Generic;
using System.Drawing;
using Autofac;
using TagsCloudVisualization.CloudBuilding;
using TagsCloudVisualization.Visualization;
using TagsCloudVisualization.WordsExtraction;

namespace TagsCloudVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            CommandLine.Parser.Default.ParseArguments(args, options);

            var optionStatus = Options.CheckOptions(options);
            if (!optionStatus.IsSuccess)
            {
                Console.WriteLine(optionStatus.Error);
                return;
            }

            var fileReader = new FileReader();

            var resultOfSourceReading = fileReader.ReadFile(options.Source);
            if (!resultOfSourceReading.IsSuccess)
            {
                Console.WriteLine(resultOfSourceReading.Error);
                Console.WriteLine("Check presence and corretnes of the file and try again.");
                return;
            }
            var lines = resultOfSourceReading.Value;


            var resultOfBannedWordsReading = fileReader.ReadFile(options.BannedWords);
            if (!resultOfBannedWordsReading.IsSuccess)
            {
                Console.WriteLine(resultOfSourceReading.Error);
                Console.WriteLine(
                    "Provide correct path to file with banned words in txt format. Otherwise no words will be filtered.");
            }
            var bannedWords = resultOfBannedWordsReading.Value;
            var container = BuildContainer(options, fileReader, bannedWords);
            
            var cloudBilder = container.Resolve<ICloudBuilder>();
            var cloud = cloudBilder.BuildCloud(lines, options.Count, container.Resolve<IDrawingConfig>());
            var result = container.Resolve<ICloudSaver>().SaveCloud(cloud, options.Destination, options.Extension);
            
            if (result.IsSuccess) return;
            Console.WriteLine(
                "Cannot save file. Make sure that you've provided correct extensions and have writing access to destination directory");
            Console.WriteLine(result.Error);
        }

        private static IContainer BuildContainer(Options options, IFileReader fileReader, IEnumerable<string> bannedWords)
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new FrequencyAnalyzer()).As<IFrequencyAnalyzer>();
            builder.RegisterInstance(new DictionaryNormalizer()).As<IDictionaryNormalizer>();
            builder.RegisterInstance(new CloudLayouter(new Point(0, 0), options.HorizontalExtensionCoefficient))
                .As<ICloudLayouter>();
            builder.RegisterInstance(new WordsFilter(bannedWords)).As<IWordsFilter>();
            builder.RegisterInstance(new LayoutNormalizer()).As<ILayoutNormalizer>();
            builder.RegisterType<CloudBuilder>().As<ICloudBuilder>();
            builder.RegisterType<CloudDrawer>().As<ICloudDrawer>();
            builder.RegisterInstance(fileReader).As<IFileReader>();
            builder.RegisterInstance(new CloudSaver()).As<ICloudSaver>();

            var size = new Size(options.Width, options.Height);
            builder.RegisterInstance(new DrawingConfig(options.FontName, options.BrushColor, size))
                .As<IDrawingConfig>();

            return builder.Build();
        }

    }
}