using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using TagsCloudVisualization.CloudBuilding;

namespace TagsCloudVisualization.Tests {
    [TestFixture]
    public class CloudLayouter_should {
        private CloudLayouter layouter;
        [SetUp]
        public void SetUp() {
            layouter = new CloudLayouter(new Point(20, 20),1);
        }

        [Test]
        public void CreateNewLayouter_WhenPointIsPassed() {
            layouter = new CloudLayouter(new Point(20, 20),1);
        }
        [Test]
        public void ReturnRectangle_WhenPassedSize() {
            var size = new Size(20,20);

            var supposedlyRect = layouter.PutNextRectangle(size);
            
            Assert.IsInstanceOf<Rectangle>(supposedlyRect);
        }

        [Test]
        public void AvoidRectangleIntersection_WhenPuttingSecondRectangle()
        {
            var size = new Size(20,20);
            var firstRect = layouter.PutNextRectangle(size);
            var secondRect = layouter.PutNextRectangle(size);

            Assert.False(firstRect.IntersectsWith(secondRect));
        }

	    [Test]
	    public void AvoidRectangleIntersection_OnHundredRandomRectangles()
	    {
		    var rnd = new Random();
		    var rects = new List<Rectangle>();
			for (var i = 0; i < 100; i++)
			{
				var size = new Size(rnd.Next(1,100),rnd.Next(1,100));
				rects.Add(layouter.PutNextRectangle(size));
			}

			for (var i=0; i <rects.Count-1; i++)
				for (var j=i+1; j< rects.Count;j++)
					Assert.False(rects[i].IntersectsWith(rects[j]));
	    }

	}
}