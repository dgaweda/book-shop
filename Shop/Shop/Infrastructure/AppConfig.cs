using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Infrastructure
{
    
    public class AppConfig // my own helper
    {
        private static string _iconOfCategories = ConfigurationManager.AppSettings["IconOfCategories"];
        private static string _categoriesImages = ConfigurationManager.AppSettings["CategoriesImages"];
        public static string IconOfCategories
        {
            get 
            {
                return _iconOfCategories; // gets IconOfCategories frok web.config file (cant make failure)
            }
        }

        public static string CategoriesImages
        {
            get
            {
                return _categoriesImages;
            }
        }
    }
}