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
using System.Media;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI;           // Needed for WindowId.
using Microsoft.UI.Windowing; // Needed for AppWindow.
using WinRT.Interop;          // Needed for XAML/HWND interop.

namespace touhou_music_player
{
    public sealed partial class MainWindow : Window
    {
        private AppWindow m_AppWindow;
        
        public MainWindow()
        {
            this.InitializeComponent();
            m_AppWindow = GetAppWindowForCurrentWindow();
            
            m_AppWindow.Title = "Touhou - Sundown Inc.";

            // Sets title bar icon and shows it (for some reason it's defaulted to hidden); also adds icon to alt-tab entry. :D
            // The icon looks a bit off within the title bar, but that's alright <3. It's probably best to use a 64x64 icon or something like that...
            m_AppWindow.SetIcon("Assets/thf-marisa-winkM.ico");
            m_AppWindow.TitleBar.IconShowOptions = IconShowOptions.ShowIconAndSystemMenu;


            // "Dir" is the project's source directory.
            // Then refer to wav file and play it (looped).
            // BGM: Touhou 10 ~ Mountain of Faith - Akutagawa Ryuunosuke's "Kappa" ~ Candid Friend
            string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SoundPlayer player = new SoundPlayer(dir + "\\" + "Assets\\BGM\\th.wav");
            player.PlayLooping();
        }
        private AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(wndId);
        }
    }
}
