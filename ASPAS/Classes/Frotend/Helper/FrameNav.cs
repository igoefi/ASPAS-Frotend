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
