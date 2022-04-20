/*---------------------------------------------------------------------------
 * File: LBButton.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 * Time: 13.36
 *-------------------------------------------------------------------------*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Buttons
{
	/// <summary>
	/// Description of LBButton.
	/// </summary>
	public partial class LBButton : LBIndustrialCtrlBase
	{
		#region (* Enumeratives *)
		/// <summary>
		/// Button styles
		/// </summary>
		public enum ButtonStyle
		{
			Circular = 0,
            Rectangular = 1,
            Elliptical = 2,
		}
		
		/// <summary>
		/// Button states
		/// </summary>
		public enum ButtonState
		{
			Normal = 0,
			Pressed,
		}
		#endregion
		
		#region (* Properties variables *)
		private ButtonStyle					buttonStyle = ButtonStyle.Circular;
		private ButtonState					buttonState = ButtonState.Normal;
		private Color						buttonColor = Color.Red;
		private string						label = String.Empty;
		#endregion
		
		#region (* Constructor *)
		public LBButton()
		{
			// Initialization
			InitializeComponent();
			
			// Properties initialization
			this.buttonColor = Color.Red;
        }
		#endregion

        #region (* Overrided methods *)
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new LBButtonRenderer();
        }
        #endregion

        #region (* Properties *)
        [
			Category("Button"),
			Description("Style of the button")
		]
		public ButtonStyle Style
		{
			set 
			{ 
				this.buttonStyle = value;
                this.CalculateDimensions();
			}
			get { return this.buttonStyle; }
		}
		
		[
			Category("Button"),
			Description("Color of the body of the button")
		]
		public Color ButtonColor
		{
			get { return buttonColor; }
			set
			{
				buttonColor = value;
				Invalidate();
			}
		}
		
		[
			Category("Button"),
			Description("Label of the button"),
		]
		public string Label
		{
			get { return this.label; }
			set
			{
				this.label = value;
				Invalidate();
			}
		}
		
		[
			Category("Button"),
			Description("State of the button")
		]
		public ButtonState State
		{
			set 
			{ 
				this.buttonState = value; 
				this.Invalidate();
			}
			get { return this.buttonState; }
		}
		#endregion
		
		#region (* Events delegates *)
		/// <summary>
		/// Mouse down event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnMouseDown(object sender, MouseEventArgs e)
		{
			// Change the state
			this.State = ButtonState.Pressed;
			this.Invalidate();
			
			// Call the delagates
			LBButtonEventArgs ev = new LBButtonEventArgs();
			ev.State = this.State;
			this.OnButtonChangeState ( ev );
		}
		
		/// <summary>
		/// Mouse up event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnMuoseUp(object sender, MouseEventArgs e)
		{
			// Change the state
			this.State = ButtonState.Normal;
			this.Invalidate();
			
			// Call the delagates
			LBButtonEventArgs ev = new LBButtonEventArgs();
			ev.State = this.State;
			this.OnButtonChangeState ( ev );
		}
		#endregion
		
		#region (* Fire events *)
		/// <summary>
		/// Event for the state changed
		/// </summary>
		public event ButtonChangeState ButtonChangeState;
		
		/// <summary>
		/// Method for call the delagetes
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnButtonChangeState( LBButtonEventArgs e )
	    {
	        if( this.ButtonChangeState != null )
	            this.ButtonChangeState( this, e );
	    }		
		#endregion
	}

	#region (* Classes for event and event delagates args *)
	
	#region (* Event args class *)
	/// <summary>
	/// Class for events delegates
	/// </summary>
	public class LBButtonEventArgs : EventArgs
	{
		private LBButton.ButtonState state;
			
		public LBButtonEventArgs()
		{			
		}
	
		public LBButton.ButtonState State
		{
			get { return this.state; }
			set { this.state = value; }
		}
	}
	#endregion
	
	#region (* Delegates *)
	public delegate void ButtonChangeState ( object sender, LBButtonEventArgs e );
	#endregion
	
	#endregion
}
