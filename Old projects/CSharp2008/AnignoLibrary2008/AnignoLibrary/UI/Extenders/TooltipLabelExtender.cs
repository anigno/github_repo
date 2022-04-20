﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Drawing;

namespace AnignoLibrary.UI.Extenders
{
    [ProvideProperty("TooltipLabel", typeof(Control))]
    public class TooltipLabelExtender : Component, IExtenderProvider
    {
        #region Fields
        private Hashtable _tooltips = new Hashtable();
        private Label _label = new Label();
        #endregion

        #region Properties
        public Color ForeColor
        {
            get { return _label.ForeColor; }
            set { _label.ForeColor = value; }
        }

        public Color BackColor
        {
            get { return _label.BackColor; }
            set { _label.BackColor = value; }
        }
        #endregion

        #region CTOR
        public TooltipLabelExtender()
        {
            _label.AutoSize = true;
            _label.BorderStyle = BorderStyle.FixedSingle;
        }
        #endregion

        #region Public
        public string GetTooltipLabel(Control control)
        {
            if (_tooltips[control] == null) return string.Empty;
            return (string)_tooltips[control];
        }

        public void SetTooltipLabel(Control control, string text)
        {
            if (text == null)
            {
                _tooltips[control] = string.Empty;
            }
            else
            {
                _tooltips[control] = text;
                _label.Visible = false;
                control.MouseLeave += new EventHandler(control_MouseLeave);
                control.MouseMove += new MouseEventHandler(control_MouseMove);
                control.MouseEnter += new EventHandler(control_MouseEnter);
            }
        }
        #endregion

        #region Events handlers
        void control_MouseEnter(object sender, EventArgs e)
        {
            Control parent = ((Control)sender).Parent;
            if (parent != null)
            {
                parent.Controls.Add(_label);
                if (_tooltips[(Control)sender].ToString() != "") _label.Visible = true;
            }
        }

        void control_MouseMove(object sender, MouseEventArgs e)
        {
            _label.Text = _tooltips[(Control)sender].ToString();
            _label.BringToFront();
            _label.Left = e.X + ((Control)sender).Left;
            _label.Top = e.Y + ((Control)sender).Top - _label.Height - 5;
        }

        void control_MouseLeave(object sender, EventArgs e)
        {
            Control parent = ((Control)sender).Parent;
            if (parent != null)
            {
                _label.Visible = false;
                parent.Controls.Remove(_label);
            }
        }
        #endregion

        #region IExtenderProvider Members
        public bool CanExtend(object extendee)
        {
            return (extendee is Control);
        }
        #endregion
    }
}