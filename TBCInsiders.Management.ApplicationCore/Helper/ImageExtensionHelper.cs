using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCInsiders.Management.ApplicationCore.Helper
{
    public static class ImageExtensionHelper
    {
        public static bool IsValidExtension(this string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLower();

            if (extension != ".png" && extension != ".jpg")
            {
                return false;
            }
            return true;
        }
    }
}
