using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PV.Translation
{
	public interface ITranslationManager
    {
		string Translate(string key);
		string Translate(string key, params string[] values);
		string TranslateFormat(string key, DateTime value);
		void SetLanguage(string language);
	}
}
