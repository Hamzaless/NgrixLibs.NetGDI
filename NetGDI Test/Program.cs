using NetGDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetGDI_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NGDISettings settings = new NGDISettings();
            settings.InvertedColors = true;
            settings.BlurEffect = true;
            settings.RoundedTunnelEffect = true;
            settings.HatchBrush = false;
            settings.PatternBrush = false;
            settings.ColorFilters = true;
            settings.MeltingScreen = true;
            Thread effectsThread = new Thread(() =>
            {
                GDIEffects netGDI = new GDIEffects(settings);
            });
            effectsThread.Start();
            MessageBox.Show("Are you still using?");
        }
    }
}
