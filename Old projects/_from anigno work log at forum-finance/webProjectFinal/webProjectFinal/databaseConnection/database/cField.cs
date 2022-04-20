using System;

namespace webProjectFinal
{
	/// <summary>
	/// hold parameter info and value
	/// </summary>
	public class cField
	{
		private String _fieldName;
		private String _fieldValue;

		//constructor, set parameters values
		public cField(String fieldName,object fieldValue)
		{
			_fieldName=fieldName;
			//check if fieldValue is string type to add '<value>'
			if(fieldValue.GetType().ToString().Equals("System.String"))
				_fieldValue="'"+fieldValue+"'";
			else
				_fieldValue=fieldValue.ToString();
		}//cFields()
		
		public String fieldName
		{
			get
			{
				return _fieldName;
			}//get
		}//fieldName

		public String fieldValue
		{
			get
			{
				return _fieldValue;
			}//get
		}//fieldValue

	}//public class cFields
}//namespace
