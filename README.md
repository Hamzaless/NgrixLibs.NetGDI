# NetGDI (.NET Framework GDI32.DLL)
[Website](https://mrhamzaless.com)
[Nuget Package](https://www.nuget.org/packages/NetGDI/)
## Introduction
NetGDI is a library for creating graphical user interface effects using GDI32.DLL on the .NET Framework. This library enables you to create various visual effects on the screen and add dynamism to graphical user interfaces.

## Features

    Inverted Colors: Apply an inverted colors effect to the screen.
    Blur Effect: Blur the screen.
    Rounded Tunnel Effect: Create a rounded tunnel effect on the screen.
    Hatch Brush: Apply a hatch brush to the screen.
    Pattern Brush: Apply a pattern brush to the screen.
    Color Filters: Apply color filters to the screen.
    Melting Screen: Simulate the melting effect on the screen.

## Usage

```
using NetGDI;
using System.Threading;

namespace NetGDI_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // NetGDI settings
            NGDISettings settings = new NGDISettings();
            settings.InvertedColors = true;
            settings.BlurEffect = true;
            settings.RoundedTunnelEffect = true;
            settings.HatchBrush = false;
            settings.PatternBrush = false;
            settings.ColorFilters = true;
            settings.MeltingScreen = true;
            
            // Create and start thread for GDIEffects
            Thread effectsThread = new Thread(() =>
            {
                GDIEffects netGDI = new GDIEffects(settings);
            });
            effectsThread.Start();

            // Your subsequent code here
            // For example:
            // MessageBox.Show("Are you still using it?");
        }
    }
}
```
License

This project is licensed under the MIT License - see the LICENSE file for details.
