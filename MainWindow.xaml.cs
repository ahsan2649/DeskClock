using Microsoft.UI.Windowing;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.WindowManagement;
using Windows.UI.ViewManagement;
using Microsoft.UI.Composition.SystemBackdrops;
using Windows.Graphics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Desklock
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        DateTime time;
        public MainWindow()
        {
            this.InitializeComponent();

            ExtendsContentIntoTitleBar = true;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();

            
            this.AppWindow.SetPresenter(AppWindowPresenterKind.CompactOverlay);

            this.AppWindow.Resize(new SizeInt32(322, 200));

        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            time = DateTime.Now;
            Clock.Text = time.Hour.ToString().PadLeft(2,'0')+":"+time.Minute.ToString().PadLeft(2, '0');
        }
    }
}
