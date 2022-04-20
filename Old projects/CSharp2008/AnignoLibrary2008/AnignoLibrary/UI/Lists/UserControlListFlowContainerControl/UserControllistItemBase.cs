using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace AnignoLibrary.UI.Lists.UserControlListFlowContainerControl
{
    public delegate void OnSelectionChangedDelegate(UserControlListItemBase item);

    public class UserControlListItemBase : UserControl
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " UserControlListItemBase";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private bool _selected;

        private Color _backColorSelected = SystemColors.ControlLightLight;
        private Color _backColorUnSelected = SystemColors.Control;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public UserControlListItemBase()
        {
            InitializeComponent();
            MouseClick += AnyControl_MouseClick;
        }

		#endregion (------  Constructors  ------)

		#region (------  Overridden Properties  ------)

        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

		#endregion (------  Overridden Properties  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                SetSelectionColor();
                if (OnSelectionChanged != null) OnSelectionChanged(this);
            }
        }


        [Category(CATEGORY_STRING)]
        public Color BackColorSelected
        {
            get { return _backColorSelected; }
            set
            {
                _backColorSelected = value;
                SetSelectionColor();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BackColorUnSelected
        {
            get { return _backColorUnSelected; }
            set
            {
                _backColorUnSelected = value;
                SetSelectionColor();
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Events  ------)

        public event OnSelectionChangedDelegate OnSelectionChanged;

		#endregion (------  Events  ------)

		#region (------  Event Handlers  ------)

        private void AnyControl_MouseClick(object sender, MouseEventArgs e)
        {
            Selected = true;
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.MouseClick += AnyControl_MouseClick;
            SetSelectionColor();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            e.Control.MouseClick -= AnyControl_MouseClick;
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControlListItemBase
            // 
            this.Name = "UserControlListItemBase";
            this.Size = new System.Drawing.Size(341, 57);
            this.ResumeLayout(false);

        }

        private void SetSelectionColor()
        {
            if (_selected)
            {
                BackColor = BackColorSelected;
            }
            else
            {
                BackColor = BackColorUnSelected;
            }
            foreach (Control c in Controls)
            {
                c.BackColor = BackColor;
            }
        }

		#endregion (------  Private Methods  ------)

    }
}