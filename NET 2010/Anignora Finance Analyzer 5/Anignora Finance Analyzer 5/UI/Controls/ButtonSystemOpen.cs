using System.Drawing;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraUI.Labels;

namespace AnignoraFinanceAnalyzer5.UI.Controls
{
    public class ButtonSystemOpen : LabelAsButton
    {
        private readonly AfaSystemBase m_system;

        public ButtonSystemOpen(AfaSystemBase p_system)
        {
            m_system = p_system;
            initControl();
        }

        private void initControl()
        {
            AutoSize = true;
            Font = new Font(Font.FontFamily, Font.Size + 2);
            BorderStyle = BorderStyle.FixedSingle;
            ForeColor = Color.FromArgb(64, 64, 64);
            BackColor = Color.FromArgb(255, 255, 192);
            MouseOverColor = Color.LightGray;
            MouseDownColor = Color.DarkGray;
            Text = m_system.SystemName;
            Tag = m_system;
        }
    }
}
