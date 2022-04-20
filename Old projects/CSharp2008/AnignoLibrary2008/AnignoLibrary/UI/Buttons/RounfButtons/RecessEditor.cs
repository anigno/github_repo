using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms.Design;

namespace AnignoLibrary.UI.Buttons.RounfButtons
{
    public class RecessEditor : System.Drawing.Design.UITypeEditor
    {

        #region (------  Overridden Methods  ------)

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {

            if ((context != null) && (provider != null))
            {
                // Access the property browser’s UI display service, IWindowsFormsEditorService
                IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (editorService != null)
                {
                    // Create an instance of the UI editor control, passing a reference to the editor service
                    RecessEditorControl dropDownEditor = new RecessEditorControl(editorService);

                    // Pass the UI editor control the current property value
                    dropDownEditor.Recess = (int)value;

                    // Display the UI editor control
                    editorService.DropDownControl(dropDownEditor);

                    // Return the new property value from the UI editor control
                    return dropDownEditor.Recess;
                }
            }
            return base.EditValue(context, provider, value);
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        #endregion (------  Overridden Methods  ------)

    }
}