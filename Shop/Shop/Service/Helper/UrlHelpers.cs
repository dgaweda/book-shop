using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Infrastructure
{
    public static class UrlHelpers
    {
        //helpers
        public static string CategoriesIconsPath(this UrlHelper helper, string categoryIcoName) // Extension
        {
            var CategoryIconsFolder = AppConfig.IconOfCategories;
            var path = Path.Combine(CategoryIconsFolder, categoryIcoName);
            var straightPath = helper.Content(path);
            
            return straightPath;
        }

        public static string BookImagesPath(this UrlHelper helper, string bookImageName) // Extension
        {
            var BookImagesFolder = AppConfig.CategoriesImages;
            var path = Path.Combine(BookImagesFolder, bookImageName);
            var straightPath = helper.Content(path);

            return straightPath;
        }
    }
}