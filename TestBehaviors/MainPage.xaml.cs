using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestBehaviors
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MyClass _class;

        public MainPage()
        {
            this.InitializeComponent();
            _class = new MyClass();
            this.DataContext = _class;
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            _class.GetRect = true;
            Debug.WriteLine(_class.Rect);
        }
    }

    class MyClass : ObservableObject
    {
        private bool myVar;

        public bool GetRect
        {
            get { return myVar; }
            set { Set(ref myVar, value); }
        }

        private Rect rect;
        public Rect Rect
        {
            get { return rect; }
            set { rect = value; }
        }
    }

    public static class UIEX
    {
        public static Rect GetRect(FrameworkElement element)
        {
            Debug.WriteLine("GetRect");
            var t = element.TransformToVisual(Window.Current.Content).TransformPoint(new Point(0, 0));
            return new Rect(t.X, t.Y, element.ActualWidth, element.ActualHeight);
        }
    }
}
