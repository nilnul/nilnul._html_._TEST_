using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nilnul.html.node.txts
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			IEnumerable<string> nonblankTxtEs(HtmlNode n)
			{
				return n.ChildNodes.OfType<HtmlTextNode>().Where(
					t => !string.IsNullOrWhiteSpace(t.InnerText)
				).Select(x => x.InnerText.Trim());
			}

		}
	}
}
