using System;
using System.Windows.Forms;

namespace AnignoLibrary.UI.ComboBoxes
{
    public class ComboBoxEnumInitialized : ComboBox
    {

		#region (------  Fields  ------)


        private Type _enumData;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public ComboBoxEnumInitialized()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

		#endregion (------  Constructors  ------)

		#region (------  Public Methods  ------)

        /// <summary>
        /// Returns an object representing an enum value of the selected item
        /// </summary>
        public object GetEnumValue()
        {
            return Enum.Parse(_enumData, SelectedItem.ToString());
        }

        /// <summary>
        /// Set items to be the given enum items, first item is selected by default
        /// </summary>
        public void SetEnum(Type enumData)
        {
            _enumData = enumData;
            Items.Clear();
            foreach (string sEnum in Enum.GetNames(enumData))
            {
                Items.Add(sEnum);
            }
            SelectedIndex = 0;
        }

		#endregion (------  Public Methods  ------)

    }
}