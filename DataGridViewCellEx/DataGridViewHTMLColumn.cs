using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using TheArtOfDev.HtmlRenderer.WinForms;
using System.Diagnostics;
using System.Runtime.InteropServices;
//using HTMLDataGridViewTest.Properties;

namespace DataGridViewHTML
{
    public enum HTMLOverflow { NONE, ELIPSIS, RED_TRIANGLE };

    public class DataGridViewHTMLColumn : DataGridViewColumn
    {
        public DataGridViewHTMLColumn() : base(new DataGridViewHTMLCell())
        { 
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (!(value is DataGridViewHTMLCell))
                    throw new InvalidCastException("CellTemplate must be a DataGridViewHTMLCell");

                base.CellTemplate = value;  
            }
        }
    }

    public class DataGridViewHTMLCell : DataGridViewCell
    {
        public HTMLOverflow m_htmlOverflowType = HTMLOverflow.ELIPSIS;

        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewHTMLEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
            set
            {
                base.ValueType = value;
            }
        }

        public override Type FormattedValueType
        {
            get
            {
                return typeof(string);
            }
        }

        private Image GenerateHTMLImage(int rowIndex, object value, bool selected)
        {
            Size cellSize = GetSize(rowIndex);

            if (cellSize.Width < 1 || cellSize.Height < 1)
                return null;

			Color backColor = selected ? SystemColors.Highlight : SystemColors.Window;

			Image htmlImage = null;
			Size fullImageSize;

            if ( RenderHTMLImage( Convert.ToString(value), cellSize, backColor, out htmlImage, out fullImageSize ) == false )
            {
				Debug.WriteLine("Failed to Generate HTML image");
                return htmlImage;
            }

			//htmlImage = Add1pxBottomBorder(htmlImage);
			htmlImage = DrawCellBorder(htmlImage, this.DataGridView.CellBorderStyle);

			if ( fullImageSize.Height > cellSize.Height ) 
            {
                // there is more html than being displayed!! Lets add some elipsis (...) to the image
                // to let the user know there is more to display
                if (m_htmlOverflowType == HTMLOverflow.ELIPSIS)
                    htmlImage = AddElipsisToImage(htmlImage);

                if (m_htmlOverflowType == HTMLOverflow.RED_TRIANGLE)
                    htmlImage = AddRedTriangleToImage(htmlImage);

            }

            return htmlImage;
        }

        Image Add1pxBottomBorder(Image img)
        {
            Debug.WriteLine("Add1pxBottomBorder");

            Graphics g = Graphics.FromImage(img);

            //int linePos = img.Height - 1;

            g.DrawLine(new Pen(this.DataGridView.GridColor, 1), new Point(0, img.Height - 1), new Point(img.Width - 1, img.Height - 1));

            return img;
        }

        Image DrawCellBorder( Image img, DataGridViewCellBorderStyle borderStyle )
        {
			Debug.WriteLine("Add1pxBorder");
            Graphics g = Graphics.FromImage(img);

			Pen pen, pen1 = Pens.White;
			if (borderStyle == DataGridViewCellBorderStyle.Single || borderStyle == DataGridViewCellBorderStyle.SingleHorizontal || borderStyle == DataGridViewCellBorderStyle.SingleVertical)
				pen = new Pen(this.DataGridView.GridColor, 1);
			else if (borderStyle == DataGridViewCellBorderStyle.Raised || borderStyle == DataGridViewCellBorderStyle.RaisedHorizontal || borderStyle == DataGridViewCellBorderStyle.RaisedVertical ||
				borderStyle == DataGridViewCellBorderStyle.Sunken || borderStyle == DataGridViewCellBorderStyle.SunkenHorizontal || borderStyle == DataGridViewCellBorderStyle.SunkenVertical)
			{
				pen = new Pen(SystemColors.AppWorkspace, 1);
				pen1 = new Pen(SystemColors.Window, 1);
			}
			else
				return img;

			if (borderStyle == DataGridViewCellBorderStyle.Single || borderStyle == DataGridViewCellBorderStyle.SingleHorizontal)
				g.DrawLine(pen, new Point(0, img.Height - 1), new Point(img.Width - 1, img.Height - 1));

			if (borderStyle == DataGridViewCellBorderStyle.Single || borderStyle == DataGridViewCellBorderStyle.SingleVertical)
				g.DrawLine(pen, new Point(img.Width - 1, 0), new Point(img.Width - 1, img.Height - 1));


			if (borderStyle == DataGridViewCellBorderStyle.Raised || borderStyle == DataGridViewCellBorderStyle.RaisedHorizontal)
			{
				g.DrawLine(pen, new Point(0, img.Height - 1), new Point(img.Width - 1, img.Height - 1));
				g.DrawLine(pen1, new Point(0, 0), new Point(img.Width - 1, 0));

			}

			if (borderStyle == DataGridViewCellBorderStyle.Raised || borderStyle == DataGridViewCellBorderStyle.RaisedVertical)
			{
				g.DrawLine(pen, new Point(img.Width - 1, 0), new Point(img.Width - 1, img.Height - 1));
				g.DrawLine(pen1, new Point(0, 0), new Point(0, img.Height - 1));
			}


			if (borderStyle == DataGridViewCellBorderStyle.Sunken || borderStyle == DataGridViewCellBorderStyle.SunkenHorizontal)
			{
				g.DrawLine(pen, new Point(0, 0), new Point(img.Width - 1, 0));
				g.DrawLine(pen1, new Point(1, img.Height - 1), new Point(img.Width - 1, img.Height - 1));

			}

			if (borderStyle == DataGridViewCellBorderStyle.Sunken || borderStyle == DataGridViewCellBorderStyle.SunkenVertical)
			{
				g.DrawLine(pen, new Point(0, 0), new Point(0, img.Height - 1));
				g.DrawLine(pen1, new Point(img.Width - 1, 0), new Point(img.Width - 1, img.Height - 1));
			}


			return img;
        }

        Image AddRedTriangleToImage( Image img )
        {
			Debug.WriteLine("AddRedTriangleToImage");
            // This function will grab a graphics object from the image and then draw another image on-top
            Graphics g = Graphics.FromImage(img);

            //red_triangle
            g.DrawImage(Properties.Resources.red_triangle, new Point(img.Width - Properties.Resources.red_triangle.Width, (img.Height - 1) - Properties.Resources.red_triangle.Height));

            return img;
        }

        Image AddElipsisToImage(Image img)
        {
			Debug.WriteLine("AddElipsisToImage");
            // This function will grab a graphics object from the image and then draw another image on-top
            Graphics g = Graphics.FromImage(img);

            // elipsis
            g.DrawImage(Properties.Resources.elipsis, new Point(img.Width - Properties.Resources.elipsis.Width, (img.Height-1) - Properties.Resources.elipsis.Height));

            return img;
        }

        private bool RenderHTMLImage(string htmlText, Size cellSize, Color backColor, out Image htmlImage, out Size fullImageSize)
        {
			Debug.WriteLine("RenderHTMLImage");

            bool bResult = true;

            // Step 1: Set out parameters
            htmlImage = null;
            fullImageSize = new System.Drawing.Size();
            
            try
            {
                // Step 2: Check for numm html text
                if (string.IsNullOrEmpty(htmlText) == true)
				{
//#if DEBUG
//					htmlText = "This <b>cell</b> has a <span style=\"color: red\">null</span> value!";
//#else
					htmlText = "";
//#endif
				}

				// Need to render image twice! Once to get the full size of image and once to get image clipped to the size of the cell

				// Step 3: Render the html image using the full height but keep the cell width.
				htmlImage = HtmlRender.RenderToImage(htmlText, maxWidth: cellSize.Width, backgroundColor : backColor);

                // Step 4: Keep a record of the full image size to send back to caller.
                fullImageSize.Height = htmlImage.Height;
                fullImageSize.Width = htmlImage.Width;

                // Step 5: Render the HTML imaage a second time with the cell size width / height
                htmlImage = HtmlRender.RenderToImage(htmlText, new Size(cellSize.Width, cellSize.Height), backgroundColor : backColor); 

                //m_editingControl.Text = htmlText;
            }
            catch(Exception ex)
            {
				Debug.WriteLine(ex.Message);
                bResult = false;
            }
            
            return bResult;
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            HtmlLabel ctl = DataGridView.EditingControl as HtmlLabel;
			//ctl.BackColor = SystemColors.Highlight;

		   // initialFormattedValue = "This is an <b>HtmlLabel</b> control";
			if (ctl != null)
            {
				if (initialFormattedValue == null)
				{
					string nullText = "";// This <b>cell</b> has a <span style=\"color: red\">null</span> value!";
					ctl.Text = nullText;
					//SetHTMLPanelText(ctl, nullText);
				}
				else
					ctl.Text = Convert.ToString(initialFormattedValue);
					//SetHTMLPanelText(ctl, Convert.ToString(initialFormattedValue));
			}
        }

        protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
			Debug.WriteLine("GetPreferredSize: w:{0} h:{1}", constraintSize.Width, constraintSize.Height);

            // constraintSize is the cell's maximum allowable size.
            SizeF maxAllowableSize = new System.Drawing.SizeF(constraintSize.Width, constraintSize.Height);

            // start at 0,0
            PointF point = new PointF(0, 0);

            // send the html text to the renderer to find out its size
            SizeF htmlSize = HtmlRender.Render(graphics, Value.ToString(), point, maxAllowableSize);

            // return the cells preffered size
            return htmlSize.ToSize();

            //return base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return value;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, null, null, errorText, cellStyle, advancedBorderStyle, paintParts);

			Image img = GenerateHTMLImage(rowIndex, value, base.Selected);

			if (img != null)
			{
				graphics.DrawImage(img, cellBounds.Left , cellBounds.Top, cellBounds.Width, cellBounds.Height);//, img.Width, img.Height);
			}
		}

        #region Handlers of edit events, copyied from DataGridViewTextBoxCell

        private byte flagsState;

        protected override void OnEnter(int rowIndex, bool throughMouseClick)
        {
            base.OnEnter(rowIndex, throughMouseClick);

            if ((base.DataGridView != null) && throughMouseClick)
            {
                this.flagsState = (byte)(this.flagsState | 1);
            }
        }

        protected override void OnLeave(int rowIndex, bool throughMouseClick)
        {
            base.OnLeave(rowIndex, throughMouseClick);

            if (base.DataGridView != null)
            {
                this.flagsState = (byte)(this.flagsState & -2);
            }
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (base.DataGridView != null)
            {
                Point currentCellAddress = base.DataGridView.CurrentCellAddress;

                if (((currentCellAddress.X == e.ColumnIndex) && (currentCellAddress.Y == e.RowIndex)) && (e.Button == MouseButtons.Left))
                {
                    if ((this.flagsState & 1) != 0)
                    {
                        this.flagsState = (byte)(this.flagsState & -2);
                    }
                    else if (base.DataGridView.EditMode != DataGridViewEditMode.EditProgrammatically)
                    {
                        base.DataGridView.BeginEdit(false);
                    }
                }
            }
        }

        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            return (((((char.IsLetterOrDigit((char)((ushort)e.KeyCode)) && ((e.KeyCode < Keys.F1) || (e.KeyCode > Keys.F24))) || ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.Divide))) || (((e.KeyCode >= Keys.OemSemicolon) && (e.KeyCode <= Keys.OemBackslash)) || ((e.KeyCode == Keys.Space) && !e.Shift))) && (!e.Alt && !e.Control)) || base.KeyEntersEditMode(e));
        }

        #endregion
    }


    public class DataGridViewHTMLEditingControl : HtmlLabel, IDataGridViewEditingControl
    {
        private DataGridViewEx m_dataGridView;
        private int m_rowIndex;
        private bool m_valueChanged;
		private const int WM_KEYDOWN = 0x0100;
		private const int WM_KEYUP = 0x0101;

		//[DllImport("user32.dll", EntryPoint = "SendMessage")]
		//private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

		public DataGridViewHTMLEditingControl()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            AutoSize = false;

			this.LinkClicked += DataGridViewHTMLEditingControl_LinkClicked;
        }


		private void DataGridViewHTMLEditingControl_LinkClicked(object sender, TheArtOfDev.HtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs e)
		{
			this.m_dataGridView.OnLinkClicked(sender, e);
		}

		#region IDataGridViewEditingControl Members

		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return m_dataGridView;
            }
            set
            {
				if (value is DataGridViewEx)
					m_dataGridView = value as DataGridViewEx;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (value is string)
                    this.Text = value as string;
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return m_rowIndex;
            }
            set
            {
                m_rowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return m_valueChanged;
            }
            set
            {
                m_valueChanged = value;
            }
        }
        
        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
			switch ((keyData & Keys.KeyCode))
			{
				case Keys.Return:
				case Keys.Left:
				case Keys.Right:
				case Keys.Up:
				case Keys.Down:
					return true;
			}

			return !dataGridViewWantsInputKey;
        }

        public Cursor EditingPanelCursor
        {
            get { return this.Cursor; }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Text;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        #endregion
    }
}
