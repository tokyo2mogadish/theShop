using System;
using System.Collections.Generic;
using System.Linq;

namespace TheShop
{
	public class ShopService
	{
		private DatabaseDriver DatabaseDriver;
		
		public ShopService()
		{
			DatabaseDriver = new DatabaseDriver();
			
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
            #region ordering article

            Article article = null;

            article = DatabaseDriver.GetAllArticles().Where(a => a.ID == id && a.ArticlePrice <= maxExpectedPrice).FirstOrDefault();

            #endregion

            #region selling article

            if (article == null)
            {
                throw new Exception("SS/Could not order an article with id=" + id + " or price of: " + maxExpectedPrice);
            }
            else
            {
                Logger.Debug("L/Trying to sell article with id=" + id);

                article.IsSold = true;
                article.SoldDate = DateTime.Now;
                article.BuyerUserId = buyerId;

                try
                {
                    DatabaseDriver.Remove(article);
                    Logger.Info("L/Article with id=" + id + " is sold.");
                }
                catch (ArgumentNullException ex)
                {
                    Logger.Error("L/Could not remove article with id=" + id);
                    throw new Exception("SS/Could not remove article with id" + ex);
                }

            }

            #endregion
        }

        public Article GetById(int id)
        {
            return DatabaseDriver.GetById(id);
        }

    }


}
