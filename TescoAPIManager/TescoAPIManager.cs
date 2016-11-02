using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace TescoAPIManager
{
    public static class TescoGetQuerys
    {
        const string APIKey = "b7ffe33968bf43e892ba62e3ff759e12";

        public static TescoGroceryRoot MakeGroceryRequest(string query, int offset = 0, string limit = "10")
        {
            HttpClient client = new HttpClient();
            var uri = String.Format("https://dev.tescolabs.com/grocery/products/?query={0}&offset={1}&limit={2}", query, offset, limit);

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", APIKey);

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TescoGroceryRoot>(response.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        public static TescoProductRoot GetProductInfo (string gtin = "", string tpnb = "", string tpnc = "")
        {
            HttpClient client = new HttpClient();

            var uri = "https://dev.tescolabs.com/product/?";

            if (!string.IsNullOrEmpty(gtin))
            {
                uri += "gtin="+gtin;
            }
            if (!string.IsNullOrEmpty(tpnb))
            {
                uri += "tpnb="+tpnb;
            }
            if (!string.IsNullOrEmpty(tpnc))
            {
                uri += "tpnc="+tpnc;
            }
            

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", APIKey);

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TescoProductRoot>(response.Content.ReadAsStringAsync().Result);
            }

            return new TescoProductRoot();
        }

    }
}

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

//----------------------------------------------
public class QtyContents
{
    public string quantity { get; set; }
    public string quantityUom { get; set; }
    public string avgMeasure { get; set; }
    public string netContents { get; set; }
}

public class Value
{
    public string name { get; set; }
    public List<string> values { get; set; }
    public string percent { get; set; }
}

public class GdaRef
{
    public string gdaDescription { get; set; }
    public List<string> headers { get; set; }
    public List<string> footers { get; set; }
    public List<Value> values { get; set; }
}

public class Gda
{
    public List<GdaRef> gdaRefs { get; set; }
}

public class CalcNutrient
{
    public string name { get; set; }
    public string valuePer100 { get; set; }
    public string valuePerServing { get; set; }
}

public class CalcNutrition
{
    public string per100Header { get; set; }
    public string perServingHeader { get; set; }
    public List<CalcNutrient> calcNutrients { get; set; }
}

public class Allergen
{
    public string allergenName { get; set; }
    public List<string> allergenValues { get; set; }
}

public class AllergenAdvice
{
    public List<Allergen> allergens { get; set; }
    public string allergenText { get; set; }
}

public class StorageType
{
    public string name { get; set; }
    public string value { get; set; }
}

public class PrepAndUsage
{
    public string name { get; set; }
    public string value { get; set; }
}

public class StorageInfo
{
    public StorageType storage_type { get; set; }
    public PrepAndUsage prep_and_usage { get; set; }
}

public class AdditivesOtherText2
{
    public string name { get; set; }
    public string value { get; set; }
}

public class AdditivesOtherText
{
    public AdditivesOtherText2 additives_other_text { get; set; }
}

public class AdditiveName
{
    public string name { get; set; }
    public string value { get; set; }
}

public class AdditiveAdvice
{
    public string name { get; set; }
    public string value { get; set; }
}

public class Additive
{
    public AdditiveName additive_name { get; set; }
    public AdditiveAdvice additive_advice { get; set; }
}

public class Lifestyle2
{
    public string name { get; set; }
    public string value { get; set; }
}

public class Lifestyle
{
    public Lifestyle2 lifestyle { get; set; }
}

public class Category
{
    public StorageInfo storage_info { get; set; }
    public AdditivesOtherText additives_other_text { get; set; }
    public List<Additive> additives { get; set; }
    public List<Lifestyle> lifestyle { get; set; }
}

public class ProductAttribute
{
    public List<Category> category { get; set; }
}

public class Product
{
    public string gtin { get; set; }
    public string tpnb { get; set; }
    public string tpnc { get; set; }
    public string description { get; set; }
    public string brand { get; set; }
    public QtyContents qtyContents { get; set; }
    public List<string> ingredients { get; set; }
    public Gda gda { get; set; }
    public CalcNutrition calcNutrition { get; set; }
    public AllergenAdvice allergenAdvice { get; set; }
    public List<string> storage { get; set; }
    public string marketingText { get; set; }
    public List<ProductAttribute> productAttributes { get; set; }
}

public class TescoProductRoot
{
    public List<Product> products { get; set; }
}