using System;
using AnignoLibrary.UI.Lists.ListViewControls;
using System.Windows.Forms;
using System.Drawing;
using LoggingProvider;

namespace AnignoProcessMonitorV2.UI
{
    public delegate void OnDataUpdatedDelegate(string descriptor, string newData);

    public class ListViewProcesses : ListViewExt
    {

		#region Const Fields (4) 

        public const string ALLOW_FALSE = "BLOCK";
        public const string ALLOW_TRUE = "ALLOW";
        public const string ANNOUNCE_FALSE = "No";
        public const string ANNOUNCE_TRUE = "Yes";

		#endregion Const Fields 

		#region Static Fields (5) 

        private static readonly Color ColorProcessActive = Color.LightGreen;
        private static readonly Color ColorProcessAllow = Color.YellowGreen;
        private static readonly Color ColorProcessBlock = Color.LightSalmon;
        private static readonly Color ColorProcessNormal = Color.Black;
        private static readonly Color ColorProcessSystem = Color.Blue;

		#endregion Static Fields 

		#region Delegates (9) 

        private delegate void AddProcessItemDelegate(string descriptor, bool isSystem, string name, string description, uint instances, bool announce, bool allow);
        private delegate ListViewItem GetProcessItemDelegate(string descriptor);
        private delegate void RemoveProcessItemDelegate(string descriptor);
        private delegate void SetAllowDelegate(string descriptor, bool value);
        private delegate void SetAnnounceDelegate(string descriptor, bool value);
        private delegate void SetIsSystemDelegate(string descriptor, bool isSystem);
        private delegate void SetItemColorDelegate(string descriptor);
        private delegate void UpdateDescriptionDelegate(string descriptor, string newDescription);
        private delegate void UpdateInstancesDelegate(string descriptor, uint newInstances);

		#endregion Delegates 

		#region Public Methods (10) 

        public void AddProcessItemInvoked(string descriptor, bool isSystem, string name, string description, uint instances, bool announce, bool allow)
        {
            if (InvokeRequired)
            {
                Invoke(new AddProcessItemDelegate(AddProcessItemInvoked), descriptor, isSystem, name, description, instances, announce, allow);
            }
            else
            {
                ListViewItem item = GetProcessListViewItemInvoke(descriptor);
                if (item == null)
                {
                    string[] sa = new[] { name, "", "", "", "", descriptor };
                    item = new ListViewItem(sa);
                    item.Tag = isSystem;
                    item.ToolTipText = descriptor;
                    Items.Add(item);
                    item.EnsureVisible();
                    item.SubItems[1].Text = description;
                    item.SubItems[2].Text = instances.ToString();
                    item.SubItems[3].Text = announce ? ANNOUNCE_TRUE : ANNOUNCE_FALSE;
                    item.SubItems[4].Text = allow ? ALLOW_TRUE : ALLOW_FALSE;
                    SetItemColorInvoked(descriptor);
                }
                else
                {
                    throw new Exception("Item " + descriptor + " already exist in process list");
                }
            }
        }

        public ListViewItem GetProcessListViewItemInvoke(string descriptor)
        {
            try
            {
                if (InvokeRequired)
                {
                    return (ListViewItem)Invoke(new GetProcessItemDelegate(GetProcessListViewItemInvoke), descriptor);
                }
                foreach (ListViewItem lvi in Items)
                {
                    if (lvi.SubItems[5].Text != descriptor) continue;
                    return lvi;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            Logger.LogWarning("Item not found, Null will be returnd for {0}",descriptor);
            return null;
        }

        public bool IsProcessDescriptor(string descriptor)
        {
            return GetProcessListViewItemInvoke(descriptor) != null;
        }

        public void RemoveProcessItemInvoked(string descriptor)
        {
            if (InvokeRequired)
            {
                Invoke(new RemoveProcessItemDelegate(RemoveProcessItemInvoked), descriptor);
            }
            else
            {
                ListViewItem removeItem = null;
                foreach (ListViewItem lvi in Items)
                {
                    if (lvi.SubItems[5].Text != descriptor) continue;
                    removeItem = lvi;
                    break;
                }
                Items.Remove(removeItem);
                Refresh();
            }
        }

        public void SetAllowInvoked(string descriptor, bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetAllowDelegate(SetAllowInvoked), descriptor, value);
            }
            else
            {
                ListViewItem item = GetProcessListViewItemInvoke(descriptor);
                item.SubItems[4].Text = (value ? ALLOW_TRUE : ALLOW_FALSE);
                SetItemColorInvoked(descriptor);
            }
        }

        public void SetAnnounceInvoked(string descriptor, bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetAnnounceDelegate(SetAnnounceInvoked), descriptor, value);
            }
            else
            {
                ListViewItem item = GetProcessListViewItemInvoke(descriptor);
                item.SubItems[3].Text = (value ? ANNOUNCE_TRUE : ANNOUNCE_FALSE);
            }
        }

        public void SetIsSystemInvoked(string descriptor, bool isSystem)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetIsSystemDelegate(SetIsSystemInvoked), descriptor, isSystem);
            }
            else
            {
                ListViewItem item = GetProcessListViewItemInvoke(descriptor);
                item.Tag = isSystem;
                SetItemColorInvoked(descriptor);
            }
        }

        public void SetItemColorInvoked(string descriptor)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetItemColorDelegate(SetItemColorInvoked), descriptor);
            }
            else
            {
                ListViewItem item = GetProcessListViewItemInvoke(descriptor);
                item.ForeColor = ((bool)item.Tag ? ColorProcessSystem : ColorProcessNormal);
                if (item.SubItems[4].Text == ALLOW_TRUE)
                {
                    if (item.SubItems[2].Text != "0")
                    {
                        item.BackColor = ColorProcessActive;
                    }
                    else
                    {
                        item.BackColor = ColorProcessAllow;
                    }
                }
                else
                {
                    item.BackColor = ColorProcessBlock;
                }
                Refresh();
            }
        }

        public void UpdateDescriptionInvoked(string descriptor, string newDescription)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateDescriptionDelegate(UpdateDescriptionInvoked), descriptor, newDescription);
            }
            else
            {
                ListViewItem item = GetProcessListViewItemInvoke(descriptor);
                item.SubItems[1].Text = newDescription;
            }
        }

        public void UpdateInstancesInvoked(string descriptor, uint newInstances)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new UpdateInstancesDelegate(UpdateInstancesInvoked), descriptor, newInstances);
                }
                else
                {
                    ListViewItem item = GetProcessListViewItemInvoke(descriptor);
                    item.SubItems[2].Text = newInstances.ToString();
                    SetItemColorInvoked(descriptor);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }

		#endregion Public Methods 


        #region Events decleration
        public event OnDataUpdatedDelegate OnDescriptionUpdated;
        public event OnDataUpdatedDelegate OnAnnounceUpdated;
        public event OnDataUpdatedDelegate OnAllowUpdated;
        #endregion

        #region Fields
        private readonly TextBox _textBoxDescriptionEdit = new TextBox();
        private readonly ComboBox _comboBoxAnnounceEdit = new ComboBox();
        private readonly ComboBox _comboBoxAllowEdit = new ComboBox();
        #endregion

        #region CTOR
        public ListViewProcesses()
        {
            InitControls();
            OnSubItemDoubleClicked += ListViewProcesses_OnSubItemDoubleClicked;
        }
        #endregion

        #region Events handlers
        void ListViewProcesses_OnSubItemDoubleClicked(int row, int column, ListViewItem.ListViewSubItem subItem)
        {
            if (column == 1)
            {
                _textBoxDescriptionEdit.Bounds = subItem.Bounds;
                _textBoxDescriptionEdit.Visible = true;
                _textBoxDescriptionEdit.Text = subItem.Text;
                _textBoxDescriptionEdit.Focus();
            }
            if (column == 3)
            {
                _comboBoxAnnounceEdit.Bounds = subItem.Bounds;
                _comboBoxAnnounceEdit.Visible = true;
                _comboBoxAnnounceEdit.Text = subItem.Text;
                _comboBoxAnnounceEdit.Focus();
            }
            if (column == 4)
            {
                _comboBoxAllowEdit.Bounds = subItem.Bounds;
                _comboBoxAllowEdit.Visible = true;
                _comboBoxAllowEdit.Text = subItem.Text;
                _comboBoxAllowEdit.Focus();
            }
        }

        void _comboBoxAllowEdit_LostFocus(object sender, EventArgs e)
        {
            AllowEditEnd(false);
        }

        void _comboBoxAllowEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEditEnd(true);
        }

        void _comboBoxAnnounceEdit_LostFocus(object sender, EventArgs e)
        {
            AnnounceEditEnd(false);
        }

        void _comboBoxAnnounceEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnnounceEditEnd(true);
        }

        void _textBoxDescriptionEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) DescriptionEndEdit(false);
            if (e.KeyCode == Keys.Enter) DescriptionEndEdit(true);
        }

        void _textBoxDescriptionEdit_LostFocus(object sender, EventArgs e)
        {
            DescriptionEndEdit(false);
        }
        #endregion

        #region Private
        private void InitControls()
        {
            Columns.Add("ProcessName", "Name", 100);
            Columns.Add("ProcessDescription", "Description", 200);
            Columns.Add("ProcessInstances", "Instances", 60);
            Columns.Add("ProcessAnnounce", "Announce", 70);
            Columns.Add("ProcessAllow", "Allow", 70);
            Columns.Add("ProcessDescriptor", "Process descriptor", 800);
            Controls.Add(_textBoxDescriptionEdit);
            Controls.Add(_comboBoxAnnounceEdit);
            Controls.Add(_comboBoxAllowEdit);
            _textBoxDescriptionEdit.Visible = _comboBoxAllowEdit.Visible = _comboBoxAnnounceEdit.Visible = false;
            _comboBoxAllowEdit.DropDownStyle = _comboBoxAnnounceEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBoxAllowEdit.Items.Add(ALLOW_FALSE);
            _comboBoxAllowEdit.Items.Add(ALLOW_TRUE);
            _comboBoxAllowEdit.SelectedIndex = 0;
            _comboBoxAnnounceEdit.Items.Add(ANNOUNCE_TRUE);
            _comboBoxAnnounceEdit.Items.Add(ANNOUNCE_FALSE);
            _comboBoxAnnounceEdit.SelectedIndex = 0;
            _textBoxDescriptionEdit.LostFocus += _textBoxDescriptionEdit_LostFocus;
            _textBoxDescriptionEdit.KeyDown += _textBoxDescriptionEdit_KeyDown;
            _comboBoxAnnounceEdit.SelectedIndexChanged += _comboBoxAnnounceEdit_SelectedIndexChanged;
            _comboBoxAnnounceEdit.LostFocus += _comboBoxAnnounceEdit_LostFocus;
            _comboBoxAllowEdit.SelectedIndexChanged += _comboBoxAllowEdit_SelectedIndexChanged;
            _comboBoxAllowEdit.LostFocus += _comboBoxAllowEdit_LostFocus;
        }


        private void DescriptionEndEdit(bool update)
        {
            if (SelectedIndices.Count != 1) return;
            if (update)
            {
                int row = SelectedIndices[0];
                Items[row].SubItems[1].Text = _textBoxDescriptionEdit.Text;
                if (OnDescriptionUpdated != null) OnDescriptionUpdated(Items[row].SubItems[5].Text, _textBoxDescriptionEdit.Text);
            }
            _textBoxDescriptionEdit.Visible = false;
        }

        private void AnnounceEditEnd(bool update)
        {
            if (SelectedIndices.Count != 1) return;
            if (update)
            {
                int row = SelectedIndices[0];
                Items[row].SubItems[3].Text = _comboBoxAnnounceEdit.SelectedItem.ToString();
                if (OnAnnounceUpdated != null) OnAnnounceUpdated(Items[row].SubItems[5].Text, _comboBoxAnnounceEdit.SelectedItem.ToString());
            }
            _comboBoxAnnounceEdit.Visible = false;
        }

        private void AllowEditEnd(bool update)
        {
            if (SelectedIndices.Count != 1) return;
            if (update)
            {
                int row = SelectedIndices[0];
                Items[row].SubItems[4].Text = _comboBoxAllowEdit.SelectedItem.ToString();
                if (OnAllowUpdated != null) OnAllowUpdated(Items[row].SubItems[5].Text, _comboBoxAllowEdit.SelectedItem.ToString());
                SetItemColorInvoked(Items[row].SubItems[5].Text);
            }
            _comboBoxAllowEdit.Visible = false;
        }
        #endregion
    }
}