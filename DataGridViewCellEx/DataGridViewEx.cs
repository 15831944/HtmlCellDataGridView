using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Core.Entities;

namespace DataGridViewHTML
{
	public class DataGridViewEx : DataGridView
	{
		public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked;
		public DataGridViewEx() : base()
		{ }

		public void OnLinkClicked(object sender, HtmlLinkClickedEventArgs e)
		{
			if (LinkClicked != null)
				LinkClicked(sender, e);
		}
	}
}
