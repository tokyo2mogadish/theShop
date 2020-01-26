using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class Supplier
    {
        public bool ArticleInInventory(int id)
        {
            if (this.GetArticle(id) != null)
            {
                return true;
            }
            return false;
        }

        public Article GetArticle(int id)
        {
            return this.Articles.Where(a => a.ID == id).FirstOrDefault();
        }

        public List<Article> Articles { get; set; }
    }
}
