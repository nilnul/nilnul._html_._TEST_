using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace nilnul.html._parse_.by_.agilityPack
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var memoAsXec ="<a/>";

			HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(memoAsXec);


			var precedents =doc.DocumentNode.ChildNodes
				.Where(
								n => n.NodeType== HtmlAgilityPack.HtmlNodeType.Element
							)
				//.Cast<HtmlElement>()
				.Where(e => e.Name == "precedent").Select(e => (e.InnerText?? "").Trim());


		}
	}
}
