using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ASPAS.Classes.Frotend.Helper
{
    public class FrameNav
    {
        public static Frame FrameNavigation { get; set; }

        public static void SetFrame(Frame frame) =>
            FrameNavigation = FrameNavigation ?? frame;
    }
}
