using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Hardcodet.Wpf.TaskbarNotification;

namespace ChangeDpi;

public partial class App
{
    // ReSharper disable once NotAccessedField.Local
    private TaskbarIcon? _taskbarIcon;

    protected override void OnStartup(StartupEventArgs eventArgs)
    {
        base.OnStartup(eventArgs);

        _taskbarIcon = new TaskbarIcon
        {
            Icon = new Icon("monitor-screenshot.ico"),
            ContextMenu = new ContextMenu
            {
                Items =
                {
                    CreateMenuItem(1, 100),
                    CreateMenuItem(1, 125),
                    CreateMenuItem(1, 150)
                }
            }
        };
    }

    private static MenuItem CreateMenuItem(int monitorIndex, int size)
    {
        var menuItem = new MenuItem {Header = $"Monitor {monitorIndex} - {size}%"};
        menuItem.Click += (_, _) => SetDpi(monitorIndex, size);
        return menuItem;
    }

    private static void SetDpi(int monitorIndex, int size)
    {
        Process.Start(@".\SetDpi.exe", new[] {monitorIndex.ToString(), size.ToString()});
    }
}