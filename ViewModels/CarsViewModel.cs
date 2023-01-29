using DevExpress.Data.Async;
using DevExpress.Mvvm.Native;
using DevTrustTest.Interfaces;
using DevTrustTest.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
    #endregion
    public CarsViewModel(ICarDataService CarDataService)
    {
        _carDataService = CarDataService;
        InitilazeData();
    }
    private async void InitilazeData()
    {
       CarData = (await _carDataService.GetCarData()).ToObservableCollection();
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
