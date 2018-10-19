using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;

namespace TagsCloudVisualization.CloudBuilding
{
    public class CloudSaver : ICloudSaver
    {
        public Result<None> SaveCloud(Bitmap cloud, string filename, string extension)
        {
            var format = GetImageFormat(extension);
            if (!format.IsSuccess)
                return Result.Fail<None>(format.Error);
            var fullname = filename + "." + extension;
            return Result.OfAction(() => cloud.Save(fullname, format.Value));
        }

        private static Result<ImageFormat> GetImageFormat(string extension)
        {
            var prop = typeof(ImageFormat)
                .GetProperties()
                .FirstOrDefault(p => p.Name.Equals(extension, StringComparison.InvariantCultureIgnoreCase));
            if (prop == null)
                return Result.Fail<ImageFormat>($"Unknown image extension: '{extension}'. Try another one");
            return Result.Ok(prop.GetValue(prop) as ImageFormat);
        }
    }
}