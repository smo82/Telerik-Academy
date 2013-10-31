using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class TradeCompanyMain
{
    public static void Main(string[] args)
    {
        OrderedMultiDictionary<decimal, Article> companyArticles = GetCompanyArticles();
        decimal startPrice = 1m;
        decimal endPrice = 120m;

        Article[] articlesInRange = GetArticlesInPriceRange(companyArticles, startPrice, endPrice);

        PrintArticleCollection(articlesInRange);
    }

    private static void PrintArticleCollection(ICollection<Article> articlesInRange)
    {
        foreach (Article article in articlesInRange)
        {
            Console.WriteLine(article);
        }
    }

    private static Article[] GetArticlesInPriceRange(OrderedMultiDictionary<decimal, Article> companyArticles, decimal startPrice, decimal endPrice)
    {
        return companyArticles.Range(startPrice, true, endPrice, true).Values.ToArray<Article>();
    }

    private static OrderedMultiDictionary<decimal, Article> GetCompanyArticles()
    {
        OrderedMultiDictionary<decimal, Article> companyArticles = new OrderedMultiDictionary<decimal, Article>(true);
        Random random = new Random();

        for (int i = 0; i < 10000; i++)
        {
            Article newArticle = new Article("#" + i, "Vendor" + i, "Some Title" + i, random.Next(0, 100000));
            companyArticles.Add(newArticle.Price, newArticle);
        }

        return companyArticles;
    }
}