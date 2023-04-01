using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
	public class TemotDaten
	{
		public String StripImageUri { get; set; }

		public Int32 ImgWidth { get; set; }

		public Int32 ImgHeight { get; set; }

		public List<TemotStripElement> StripElements { get; set; }

		public List<KeyValuePair<int, int>> StripElementsIdArticleIds { get; set; }

		public bool HatDaten
		{
			get { return !string.IsNullOrEmpty(StripImageUri) && ImgHeight>0; }
		}
	}
}
