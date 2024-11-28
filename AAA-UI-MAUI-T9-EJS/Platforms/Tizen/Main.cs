using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace AAA_UI_MAUI_T9_EJS
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
