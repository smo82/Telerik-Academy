using System;

public class Article : IComparable<Article>
{
    public Article(string barcode, string vendor, string title, decimal price)
    {
        this.Barcode = barcode;
        this.Vendor = vendor;
        this.Title = title;
        this.Price = price;
    }

    public string Barcode { get; private set; }

    public string Vendor { get; private set; }

    public string Title { get; private set; }

    public decimal Price { get; private set; }

    public int CompareTo(Article other)
    {
        return this.Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return string.Format("{0, -10}: {1, -15} = {2}", this.Barcode, this.Title, this.Price);
    }
}
