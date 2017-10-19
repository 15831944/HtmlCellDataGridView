using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTMLDataGridViewTest
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			//dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;// | DataGridViewCellBorderStyle.SingleHorizontal;

			dataGridView1.LinkClicked += DataGridView1_LinkClicked;


			for (int i = 0; i < 10; i++)
			{
				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells(dataGridView1);
				row.HeaderCell.Value = (i + 1).ToString();
                row.Cells[4].Value = "This is an <b>Test</b> <a href=\"vobj://btm=part&oid=asdfasdfas\">VCI-Test0001</a>control<br>清洗零件，确保零件清洁<br>使用防锈脂涂抹零件表面<br>sdfasfdasdfas<br>sdfasfdasdfas";

                dataGridView1.Rows.Add(row);
			}

			dataGridView1.AutoResizeRows();
		}

		private void DataGridView1_LinkClicked(object sender, TheArtOfDev.HtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs e)
		{
			MessageBox.Show(e.Link);
			//throw new NotImplementedException();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
