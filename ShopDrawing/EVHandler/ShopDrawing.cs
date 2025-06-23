using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ShopDrawing.MVVM.ViewModel;
using System;

namespace ShopDrawing.EVHandler
{
    internal class ShopDrawingExternalEventHandler : IExternalEventHandler
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
