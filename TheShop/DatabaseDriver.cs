using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class DatabaseDriver
    {

        Supplier Supplier1 = new Supplier()
        {
            Articles = new List<Article>()
                {
                    new Article(){ID = 1,Name_of_article = "Article from supplier1_1",ArticlePrice = 58},
                    new Article(){ID = 2,Name_of_article = "Article from supplier1_2",ArticlePrice = 59},
                    new Article(){ID = 3,Name_of_article = "Article from supplier1_3",ArticlePrice = 60}
                }
        };

        Supplier Supplier2 = new Supplier()
        {
            Articles = new List<Article>()
                {
                    new Article(){ID = 1,Name_of_article = "Article from supplier2_1",ArticlePrice = 158},
                    new Article(){ID = 2,Name_of_article = "Article from supplier2_2",ArticlePrice = 159},
                    new Article(){ID = 3,Name_of_article = "Article from supplier2_3",ArticlePrice = 160}
                }
        };
        Supplier Supplier3 = new Supplier()
        {
            Articles = new List<Article>()
                {
                    new Article(){ID = 1,Name_of_article = "Article from supplier3_1",ArticlePrice = 658},
                    new Article(){ID = 2,Name_of_article = "Article from supplier3_2",ArticlePrice = 659},
                    new Article(){ID = 3,Name_of_article = "Article from supplier3_3",ArticlePrice = 660}
                }

        };
        private List<Article> _articles = new List<Article>();
        public DatabaseDriver()
        {
            this._articles = ((this.Supplier1.Articles.Concat(this.Supplier2.Articles).Concat(this.Supplier3.Articles)).Where(e => e.IsSold == false).ToList());
        }

        public Article GetById(int id)
        {
            Article article = this._articles.Where(x => x.ID == id && x.IsSold == false).FirstOrDefault();
            if (article == null)
            {
                //throw new Exception("Couldnt find article with ID=" + id);
                Console.WriteLine("Couldnt find article with ID=" + id);
            }
            return article;
        }
        public List<Article> GetAllArticles()
        {
            if (this._articles == null)
            {
                throw new Exception("Couldn't find list of articles");
            }
            return this._articles;
        }

        public void Save(Article article)
        {
            int expected = this._articles.Count + 1;
            this._articles.Add(article);
            if (expected != this._articles.Count)
            {
                throw new Exception("Could not add an article");
            }
        }
        public void Remove(Article article)
        {
            if (article.IsSold)
            {
                this._articles.Remove(article);
            }
            else
            {
                throw new Exception("DatabaseDriver couldn't remove sold article");
            }
        }
    }
}
