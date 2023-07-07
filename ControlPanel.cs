using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    public class ControlPanel : Panel
    {
        public ControlPanel(Size size, Point location)
        {
            Size = size;
            Location = location;
            BackgroundImage = Image.FromFile(Matherials.blurredGameFormBackgroundPath);
        }
        
    }
}