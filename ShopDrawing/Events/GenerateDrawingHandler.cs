using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ShopDrawing.Presentation.ViewModels;
using ShopDrawing.Presentation.Views;
using System;

namespace ShopDrawing.Events
{
    internal class GenerateDrawingHandler : IExternalEventHandler
    {
        public MainPageViewModel MainViewModel { get; set; }

        public void Execute(UIApplication app)
        {
            try
            {
                var uidoc = app.ActiveUIDocument;
                var doc = uidoc.Document;
                var activeView = doc.ActiveView;
                var projectName = doc.Title;
                MainViewModel.SetStatus(true);
                Transaction tr = new Transaction(doc, "Create Component");
                tr.Start();

                tr.Commit();
            }
            catch (Exception ex) { TaskDialog.Show("Error", ex.Message); }
        }
    
        public string GetName() => "Run Tool";
    }

}
