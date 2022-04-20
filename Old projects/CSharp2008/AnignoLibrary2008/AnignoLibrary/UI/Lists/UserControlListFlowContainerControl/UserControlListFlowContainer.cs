using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnignoLibrary.UI.Lists.UserControlListFlowContainerControl;
using System.ComponentModel;

namespace AnignoLibrary.UI.Lists.UserControlListFlowContainerControl
{
    public class UserControlListFlowContainer : FlowLayoutPanel
    {

		#region (------  Properties  ------)


        [Browsable(false)]
        public UserControlListItemBase SelectedUserControl { get; set; }


		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        void UserControlItemBase_OnSelectionChanged(UserControlListItemBase item)
        {
            if(!item.Selected)return;
            SelectedUserControl=item;
            //unselect all controls except selected one
            foreach (Control c in Controls)
            {
                if (c is UserControlListItemBase)
                {
                    if (c != item)
                    {
                        ((UserControlListItemBase)c).Selected = false;
                    }
                }
            }
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is UserControlListItemBase)
            {
                ((UserControlListItemBase) e.Control).OnSelectionChanged += UserControlItemBase_OnSelectionChanged;
                e.Control.Focus();
            }
            
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (e.Control is UserControlListItemBase)
            {
                ((UserControlListItemBase)e.Control).OnSelectionChanged -= UserControlItemBase_OnSelectionChanged;
            }
            if(SelectedUserControl==e.Control)SelectedUserControl=null;
            base.OnControlRemoved(e);
        }

		#endregion (------  Overridden Methods  ------)

    }
}