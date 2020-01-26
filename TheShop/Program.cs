using System;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var shopService = new ShopService();

            //try
            //{
            //    shopService.OrderAndSellArticle(1, 20000, 10);

            //    var article = shopService.GetById(1);
            //    if (article != null)
            //    {
            //        Console.WriteLine("Found article with ID: " + article.ID + "Price of: " + article.ArticlePrice);
            //    }
            //    else
            //    {
            //        throw new Exception("Could not fint article with ID: " + 1);
            //    }
            //    article = shopService.GetById(12);
            //    if (article != null)
            //    {
            //        Console.WriteLine("Found article with ID: " + article.ID + "Price of: " + article.ArticlePrice);
            //    }
            //    else
            //    {
            //        throw new Exception("Could not fint article with ID: " + 12);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            try
            {
                shopService.OrderAndSellArticle(1, 20000, 10);

                var article = shopService.GetById(1);

                article = shopService.GetById(12);

                shopService.OrderAndSellArticle(3, 161, 11);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();

		}
	}
}