using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace nilnul.html.el.content.parse.nbsp
{
	[TestClass]
	public class UnitTest1
	{
		/*
		 github.com/zzzprojects/html-agility-pack/issues/578

1. Description
if we append a char nbsp (0xa0) to element name, it's parsed normally without exception thrown.

eg:

<constituent></constituent  >note in the end tag before this sentence, char 0xA0, not 0x20, is appended<constituent></constituent>
will be parsed as one "constituent" element, not two.
And the problem is suppressed (which is not good), and it's hard to debug, as 0xA0 is visually indiscernible from 0x20.

2. Expectation
https://dev.w3.org/html5/spec-LC/syntax.html#:~:text=HTML%20elements%20all%20have%20names,005A%20LATIN%20CAPITAL%20LETTER%20Z.

doesnot allow such chars in element name.

nor xml allows as stipulated in:

w3.org/TR/REC-xml/#NT-NameStartChar

;

it's hard to pin down the issue;
		otherwise it's hard to pindown the issue;

Solution?
Should we in documentation explicitly allow such chars or should we throw exception?

		 */
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void TestMethod1()
		{
			{
				var txt = "<a></a\u00a0><a></a>";



				HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

				doc.LoadHtml(txt);

				var constituents = doc.DocumentNode.ChildNodes
	.Where(
					n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Element
				)
	//.Cast<HtmlElement>()
	//.Where(e => e.Name.StartsWith("a" ))
	.ToArray();

				Assert.IsTrue(constituents.Length == 2);


			}





		}

		[TestMethod]
		public void TestMethod11()
		{
			{
				var txt = "<a></a\u00a0><br><a></a>";



				HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

				doc.LoadHtml(txt);

				var constituents = doc.DocumentNode.ChildNodes
	.Where(
					n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Element
				)
	//.Cast<HtmlElement>()
	//.Where(e => e.Name.StartsWith("a" ))
	.ToArray();

				Assert.IsTrue(constituents.Length == 3);


			}





		}


	}
}
