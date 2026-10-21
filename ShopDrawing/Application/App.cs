using Autodesk.Revit.UI;
using ShopDrawing.Application.Tab;

using System;
using System.IO;

namespace ShopDrawing
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;

            var builder = new RibbonBuilder(application, "Shop Drawing");

            builder.AddPanel("Common")
                   .AddPushButton("Grids", "Grids", "ShopDrawing.Application.GridsCommand", Properties.Resources.favicon1_32x32);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;

        private System.Reflection.Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var name = args.Name.Split(',')[0];
            var path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), name + ".dll");

            return File.Exists(path) ? System.Reflection.Assembly.LoadFrom(path) : null;
        }
    }
}
