using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Drawing;

namespace AnignoLibrary.UI.TextBoxs
{
    /// <summary>
    /// Expends the textBox, add validation using regEx
    /// </summary>
    public class TextBoxValidated : TextBox
    {
        public TextBoxValidated()
        {
            CheckValidity();
        }

        #region (------  Enums  ------)

        public enum ValidationRuleEnum
        {
            Custom,
            Email
        }

		#endregion (------  Enums  ------)

		#region (------  Const Fields  ------)

private const string CATEGORY_STRING = " TextBoxValidated";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)

        private string _customValidationRegexString="";
        private string _validationRegexString=".*";
        private ValidationRuleEnum _validationRule = ValidationRuleEnum.Custom;

		#endregion (------  Fields  ------)

		#region (------  Properties  ------)

        [Category(CATEGORY_STRING),Browsable(false)]
        public bool IsValid { get; private set; }

        [Category(CATEGORY_STRING)]
        public Color ColorValid { get; set; }

        [Category(CATEGORY_STRING)]
        public Color ColorNotValid { get; set; }

        [Category(CATEGORY_STRING)]
        public string CustomValidationRegexString
        {
            get { return _customValidationRegexString; }
            set
            {
                _customValidationRegexString = value;
                ValidationRule = ValidationRuleEnum.Custom;
                CheckValidity();
            }
        }

        [Category(CATEGORY_STRING)]
        public ValidationRuleEnum ValidationRule
        {
            get { return _validationRule; }
            set
            {
                _validationRule = value;
                switch (_validationRule)
                {
                    case ValidationRuleEnum.Custom:
                        _validationRegexString = CustomValidationRegexString;
                        break;
                    case ValidationRuleEnum.Email:
                        _validationRegexString = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                        break;
                }
                CheckValidity();
            }
        }

		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnTextChanged(EventArgs e)
        {
            CheckValidity();
            base.OnTextChanged(e);
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void CheckValidity()
        {
            IsValid = Regex.IsMatch(Text, _validationRegexString);
            BackColor = IsValid ? ColorValid : ColorNotValid;
        }

		#endregion (------  Private Methods  ------)
    }
}
