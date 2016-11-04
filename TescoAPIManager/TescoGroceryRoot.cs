using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TescoAPIManager
{
    public class Result
    {
        public string image { get; set; }
        public int tpnb { get; set; }
        public double price { get; set; }
        public string PromotionDescription { get; set; }
        public string ContentsMeasureType { get; set; }
        public string name { get; set; }
        public int UnitOfSale { get; set; }
        public List<string> description { get; set; }
        public double AverageSellingUnitWeight { get; set; }
        public string UnitQuantity { get; set; }
        public double ContentsQuantity { get; set; }
        public double unitprice { get; set; }
    }

    public class Totals
    {
        public int all { get; set; }
        public int offer { get; set; }
        public int @new { get; set; }
    }

    public class Suggestion
    {
        public int freq { get; set; }
        public string score { get; set; }
        public string text { get; set; }
    }

    public class Products
    {
        public List<Result> results { get; set; }
        public List<Suggestion> suggestions { get; set; }
        public Totals totals { get; set; }
    }

    public class Ghs
    {
        public Products products { get; set; }
    }

    public class Uk
    {
        public Ghs ghs { get; set; }
    }

    public class TescoGroceryRoot
    {
        public Uk uk { get; set; }
    }
}
