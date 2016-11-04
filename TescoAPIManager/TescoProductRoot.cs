using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TescoAPIManager
{
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

    public class ProductDetail
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
        public List<ProductDetail> products { get; set; }
    }
}
