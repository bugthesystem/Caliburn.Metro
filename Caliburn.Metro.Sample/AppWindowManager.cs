using System.ComponentModel.Composition;
using Caliburn.Metro.Core;
using Caliburn.Micro;
using MahApps.Metro.Controls;

namespace Caliburn.Metro.Sample
{
    [Export(typeof(IWindowManager))]
    public class AppWindowManager : MetroWindowManager
    {
        public override MetroWindow CreateCustomWindow(object view, bool windowIsView)
        {
            if (windowIsView)
            {
                return view as MainWindowContainer;
            }

            return new MainWindowContainer
                       {
                           Content = view
                       };
        }
    }
}