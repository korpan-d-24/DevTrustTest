using System.Windows.Input;
using System;

namespace DevTrustTest.ViewModels.Commands;

public class LoadToFileCommander : ICommand
{
    #region ICommand Members  
    public event EventHandler CanExecuteChanged;
    public Action<string> _execute;

    public LoadToFileCommander(Action<string> execute)
    {
        _execute = execute;
    }
    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        _execute.Invoke(parameter as string);
    }
    #endregion
}