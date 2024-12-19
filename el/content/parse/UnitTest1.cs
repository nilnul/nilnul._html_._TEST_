using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace nilnul.html.el.content.parse
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

			var txt = @"

";

			txt = @"
raise <br>    <br>    <summary><br>        <br>         raise the <br>    <br>    </summary><br></constituent  ><br><constituent><br>    c20120<br>    <summary><br>        clear the…<br>    </summary><br></constituent>

";

			txt = @"
raise <br>    <br>    <summary><br>        <br>         raise the <br>    <br>    </summary><br></constituent><br><constituent><br>    c20120<br>    <summary><br>        clear the…<br>    </summary><br></constituent>

";

		
			/// xpn:
			var txt4xpn = @"
<constituent></constituent  ><constituent></constituent>

";

			/// xpn:
			var txt4nbsp = @"<constituent  ></constituent  ></constituent>

";

			txt4nbsp = @"raise<br><br><constituent><br>    <br>    2gmc<br>    <br>    <summary><br>        <br>         raise )<br>    <br>    </summary><br></constituent  ><br><constituent><br>    c20q7j0<br>    <summary><br>        clean f …<br>    </summary><br></constituent>";

			var txt4correct = @"
<constituent></constituent  ><constituent></constituent>

";

			Assert.IsTrue(txt4correct.Length ==txt4xpn.Length);
			for (int i = 0; i < txt4xpn.Length; i++)
			{
				char v = txt4xpn[i];
				char v1 = txt4correct[i];
				//Assert.IsTrue(v == v1);
			}
			txt = txt4xpn;
			txt = txt4nbsp;
			//txt = txt4correct;

			//txt = nilnul.html.el.content._NormalizeX._Normalize2xml_0content(txt);

			HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

			doc.LoadHtml(txt);

			var constituents = doc.DocumentNode.ChildNodes
.Where(
				n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Element
			)
//.Cast<HtmlElement>()
.Where(e => e.Name.StartsWith("constituent" ))
.ToArray();

			Assert.IsTrue(constituents.Length ==2);

		}
    }
}
