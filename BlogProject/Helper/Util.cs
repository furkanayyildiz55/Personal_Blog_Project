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

		public static string BaseUrl(HttpRequest Request)
		{
			return $"{Request.Scheme}://{Request.Host}/";
        }

		public static string Guid12()
		{
			string guid12 = Guid.NewGuid().ToString().ToLower().Replace("-","").Substring(0,12);

			guid12 = UrlFormating(guid12);

			return guid12;

		}


	}
}
