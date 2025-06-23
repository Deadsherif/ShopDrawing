using Autodesk.Revit.UI;
using ShopDrawing.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Autodesk.Revit.DB;



namespace ShopDrawing.MVVM.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Attributes
        private ExternalEvent ev;
        private ExternalEvent jsonev;

        private bool _isChecked;

        private bool isBusy = false;

        private Style selectedStyle;
        #endregion
        #region Properties


        public Style SelectedStyle
        {
            get { return selectedStyle; }
            set { selectedStyle = value; OnPropertyChanged(nameof(SelectedStyle)); }
        }
        private ObservableCollection<Style> styleList;

        public ObservableCollection<Style> StyleList
        {
            get { return styleList; }
            set { styleList = value; OnPropertyChanged(nameof(StyleList)); }
        }

        public ExternalEvent Ev
        {
            get { return ev; }
            set { ev = value; OnPropertyChanged(nameof(Ev)); }
        }
        public ExternalEvent JsonEv
        {
            get { return jsonev; }
            set { jsonev = value; OnPropertyChanged(nameof(JsonEv)); }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;

                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }
        // All available Revit rooms
        public List<string> AllRooms { get; set; } = new List<string>();

        // All available Revit levels
        public List<string> AllLevels { get; set; } = new List<string>();

        // Room Cards Collection

        // Commands
        public ICommand AddRoomCommand { get; }
        public ICommand RemoveRoomCommand { get; }
        public ICommand EditLevelsCommand { get; }

        public MainPageViewModel()

        {
            ShopDrawingCommand = new RelayCommand(P => RunExporter(P));
           
        
        }
      



        // Collection for Units
        public ObservableCollection<ExportUnit> Units { get; private set; }

        // Collection for Resolutions

        #endregion
        #region Functions
        public ICommand ShopDrawingCommand { get; }
        public ICommand NavigateCommand { get; }
 

        public void RunExporter(object parameter)
        {



            Ev.Raise();


        }

        public void SetStatus(bool isBusy)
        {
            this.isBusy = isBusy;
        }



        #endregion

    }



}
