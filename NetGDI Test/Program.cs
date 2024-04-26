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
            //bo
            NGDISettings.InvertedColors.Enabled = true;
            NGDISettings.BlurEffect.Enabled = true;
            NGDISettings.RoundedTunnelEffect.Enabled = true;
            NGDISettings.HatchBrush.Enabled = false;
            NGDISettings.PatternBrush.Enabled = false;
            NGDISettings.ColorFilters.Enabled = true;
            NGDISettings.MeltingScreen.Enabled = true;
            Thread effectsThread = new Thread(() =>
            {
                GDIEffects netGDI = new GDIEffects();
            });
            effectsThread.Start();
            MessageBox.Show("Are you still using?");
        }
    }
}
