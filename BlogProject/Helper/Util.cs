using Azure.Core;
using System.Text.RegularExpressions;

namespace BlogProject.Helper
{
	public static class Util
	{
		public static string UrlFormating(string text)
		{
			// Türkçe karakterleri İngilizce karakterlere dönüştürme
			text = text.ToLowerInvariant();
			text = text.Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ı", "i").Replace("ö", "o").Replace("ç", "c").Replace(" ", "-");

			// URL dostu olmayan karakterleri temizleme
			text = Regex.Replace(text, @"[^a-z0-9\s-]", "");

			// Birden fazla boşluğu tek bir tireye dönüştürme
			text = Regex.Replace(text, @"\s+", "-").Trim();

			return text;
		}


	}
}
