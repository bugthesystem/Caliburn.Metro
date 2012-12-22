using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Windows;

namespace Caliburn.Metro.Sample
{
    [Export(typeof(AppViewModel))]
    public class AppViewModel : PropertyChangedBase, IHaveDisplayName
    {
        private string _displayName = "Caliburn Metro Sample";

        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public AppViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public void OpenWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.Manual;

            _windowManager.ShowWindow(new AppViewModel(_windowManager), null, settings);
        }

        public void OpenSettings()
        {
            IsSettingsFlyoutOpen = true;
        }

        private bool _isSettingsFlyoutOpen;

        public bool IsSettingsFlyoutOpen
        {
            get { return _isSettingsFlyoutOpen; }
            set
            {
                _isSettingsFlyoutOpen = value;
                NotifyOfPropertyChange(() => IsSettingsFlyoutOpen);
            }
        }

    }
}