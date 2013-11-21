﻿using System.Web.Mvc;

namespace RavenDbNorthwind.App_Start
{
    public class FeatureViewLocationRazorViewEngine : RazorViewEngine
    {
        public FeatureViewLocationRazorViewEngine()
        {
            var featureFolderViewLocationFormats = new[]
              {
                "~/Features/{1}/{0}.cshtml",
                "~/Features/{1}/{0}.vbhtml",
                "~/Features/Shared/{0}.cshtml",
                "~/Features/Shared/{0}.vbhtml",
              };

            ViewLocationFormats = featureFolderViewLocationFormats;
            MasterLocationFormats = featureFolderViewLocationFormats;
            PartialViewLocationFormats = featureFolderViewLocationFormats;
        }
    }
}