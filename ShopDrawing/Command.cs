using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ShopDrawing.EVHandler;

using ShopDrawing.MVVM.View;
using ShopDrawing.MVVM.ViewModel;

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
            ShopDrawingExternalEventHandler ShopDrawingExternalEventHandler = new ShopDrawingExternalEventHandler();
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
