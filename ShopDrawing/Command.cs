using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ShopDrawing.Events;


using ShopDrawing.Presentation.Views;
using ShopDrawing.Presentation.ViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopDrawing
{
    [Transaction(TransactionMode.Manual)]
    internal class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //export stl 
            GenerateDrawingHandler ShopDrawingExternalEventHandler = new GenerateDrawingHandler();
            var ev = ExternalEvent.Create(ShopDrawingExternalEventHandler);

           

            MainPageViewModel mainPageViewModel = new MainPageViewModel();
  
            var ui = MainWindow.CreateInstance(mainPageViewModel);

            ShopDrawingExternalEventHandler.MainViewModel = mainPageViewModel;

            mainPageViewModel.Ev = ev;


            ui.Show();
            return Result.Succeeded;
        }
    }
}
