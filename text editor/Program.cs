using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging;
using Avalonia.ReactiveUI;
using Serilog;
using Serilog.Filters;
using Splat;
using text_editor.Models;

namespace text_editor
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine("start");
            Locator.CurrentMutable.RegisterConstant(new Context(), typeof(Context));
            //Locator.CurrentMutable.RegisterConstant(new DragDropController(), typeof(DragDropController));
            
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}