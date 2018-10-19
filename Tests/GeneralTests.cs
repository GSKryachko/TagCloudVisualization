using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Autofac;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TagsCloudVisualization.CloudBuilding;
using TagsCloudVisualization.Visualization;
using TagsCloudVisualization.WordsExtraction;

namespace TagsCloudVisualization.Tests
{
    public class GeneralTests
    {
        [TestFixture]
        public class GeneralTests_Should
        {
            private ICloudBuilder cloudBuilder;
         
            [SetUp]
            public void SetUp()
            {
                var wordsFilterMock = Substitute.For<IWordsFilter>();
                wordsFilterMock.Filter(Arg.Any<IEnumerable<string>>()).Returns(Enumerable.Repeat("mock", 100));
                
                var fileReaderMock = Substitute.For<IFileReader>();
                fileReaderMock.ReadFile(Arg.Any<string>()).Returns(Result.Ok(Enumerable.Repeat("mock", 100)));

                var layoutNormalizerMock = Substitute.For<ILayoutNormalizer>();
                var rect = new Rectangle(0, 0, 1000, 1000);
                var wordInRect = new WordInRect("kek", rect, new Font("Arial", 10));
                layoutNormalizerMock.GetMainRect(Arg.Any<IEnumerable<WordInRect>>()).Returns(rect);
                layoutNormalizerMock.ShiftLayout(Arg.Any<IEnumerable<WordInRect>>(), rect)
                    .Returns(Enumerable.Repeat(wordInRect, 100).ToArray());

                var builder = new ContainerBuilder();
                builder.RegisterInstance(new FrequencyAnalyzer()).As<IFrequencyAnalyzer>();
                builder.RegisterInstance(new DictionaryNormalizer()).As<IDictionaryNormalizer>();
                builder.RegisterInstance(new CloudLayouter(new Point(0, 0), 1))
                    .As<ICloudLayouter>();


                builder.RegisterInstance(wordsFilterMock).As<IWordsFilter>();
                builder.RegisterInstance(layoutNormalizerMock).As<ILayoutNormalizer>();
                builder.RegisterType<CloudBuilder>().As<ICloudBuilder>();
                builder.RegisterType<CloudDrawer>().As<ICloudDrawer>();
                builder.RegisterInstance(fileReaderMock).As<IFileReader>();
                builder.RegisterInstance(new CloudSaver()).As<ICloudSaver>();
                var container = builder.Build();
                cloudBuilder = container.Resolve<ICloudBuilder>();

            }
            
            [Test]
            public void GenerateBitmapOfPassedSize()
            {

                var size = new Size(500, 700);
                var drawingConfig = new DrawingConfig("Arial", "Red", size);

                var cloud = cloudBuilder.BuildCloud(GenerateRandomStrings(100), 100, drawingConfig);

                cloud.Width.Should().Be(500);
                cloud.Height.Should().Be(700);
            }

            private static string[] GenerateRandomStrings(int count)
            {
                var strings = new string[count];
                for (var i = 0; i < count; i++)
                {
                    var path = Path.GetRandomFileName();
                    path = path.Replace(".", "");
                    strings[i] = path;
                }
                return strings;
            }
        }
    }
}