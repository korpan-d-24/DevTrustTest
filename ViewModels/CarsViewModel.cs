using DevExpress.Mvvm.Native;
using DevTrustTest.Interfaces;
using DevTrustTest.Models;
using DevTrustTest.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace DevTrustTest.ViewModels;

public class CarsViewModel : INotifyPropertyChanged
{
    #region Fields
    private ICarDataService _carDataService;
    #endregion
    #region Propeties
    private ObservableCollection<CarModel> _carData;
    public ObservableCollection<CarModel> CarData
    {
        get => _carData;
        set
        {
            if (_carData == value)
                return;
            _carData = value;
            RaisePropertyChange(nameof(CarData));
        }
    }
    private ObservableCollection<CarModel> _selectedCars = new();
    public ObservableCollection<CarModel> SelectedCars
    {
        get => _selectedCars;
        set
        {
            if (_selectedCars == value)
                return;
            _selectedCars = value;
            RaisePropertyChange(nameof(SelectedCars));
        }
    }
    private ObservableCollection<string> _selectedCarsStringRecords = new();
    public ObservableCollection<string> SelectedCarsStringRecords
    {
        get => _selectedCarsStringRecords;
        set
        {
            if (_selectedCarsStringRecords == value)
                return;
            _selectedCarsStringRecords = value;
            RaisePropertyChange(nameof(SelectedCarsStringRecords));
        }
    }
    #endregion

    #region Command
    public LoadToFileCommander SaveToFileCommand { get; private set; }
    #endregion

    public CarsViewModel(ICarDataService CarDataService)
    {
        _carDataService = CarDataService;
        CarData = _carDataService.GetCarData().ToObservableCollection();
        SaveToFileCommand = new LoadToFileCommander(LoadToFile);
    }
    public void LoadToFile(string message)
    {
        foreach (var car in SelectedCars)
            SelectedCarsStringRecords.Add(car.ToString());
        if(message.Equals("- in CSV"))
            File.WriteAllLines("C:\\Users\\Asus\\Desktop\\DevTrustTest\\SavedLists.csv", SelectedCarsStringRecords);
        else if (message.Equals("- in TXT"))
            File.WriteAllLines("C:\\Users\\Asus\\Desktop\\DevTrustTest\\SavedLists.txt", SelectedCarsStringRecords);
    }

    #region INotifyChangeProperty
    public event PropertyChangedEventHandler PropertyChanged;

    public void RaisePropertyChange(string propertyname)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
    #endregion
}
