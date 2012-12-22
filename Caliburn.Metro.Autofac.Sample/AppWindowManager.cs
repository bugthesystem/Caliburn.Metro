using Caliburn.Metro.Core;
using MahApps.Metro.Controls;

namespace Caliburn.Metro.Autofac.Sample
{
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