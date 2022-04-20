using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.UI.TreeViewControls.AnignoSimpleTreeListViewControl
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            AnignoSimpleTreeListViewItem root1 = anignoSimpleTreeListView1.AddRoot("Root1");
            root1.SubItems.Add("root1 data");
            root1.SubItems.Add("root1 second data");
            root1.IsExpended=true;
            AnignoSimpleTreeListViewItem root2 = anignoSimpleTreeListView1.AddRoot("Root2");
            AnignoSimpleTreeListViewItem child1 = anignoSimpleTreeListView1.Addltem(root1, "child1");
            AnignoSimpleTreeListViewItem child2 = anignoSimpleTreeListView1.Addltem(child1, "child2");
            AnignoSimpleTreeListViewItem child3 = anignoSimpleTreeListView1.Addltem(child1, "child3");
            child3.SubItems.Add("some data");
            child3.SubItems.Add("Second data");
            AnignoSimpleTreeListViewItem child4 = anignoSimpleTreeListView1.Addltem(root2, "child4");
            AnignoSimpleTreeListViewItem child5 = anignoSimpleTreeListView1.Addltem(root2, "child5");
            root2.IsExpended=true;
        }
    }
}
