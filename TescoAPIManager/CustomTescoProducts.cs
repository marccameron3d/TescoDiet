using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TescoAPIManager;

namespace TescoCustomLibrary
{
    public class CustomTescoProducts
    {
        public List<Suggestion> SuggestedTerms { get; set; }
        public List<TescoProduct> TescoProducts { get; set; }
        private TescoGroceryRoot GroceryJson { get; set; }

        /// <summary>
        /// Parent class, holds all information required to build the output of the 
        /// search queries.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        public CustomTescoProducts(string query, int offset = 0, string limit = "10")
        {
            //get and store json
            GroceryJson = TescoGetQuerys.MakeGroceryRequest(query, offset, limit);
            //build grocery product from json
            GetGroceryFromJson();
            //get suggestedTerms
            GetSuggestedTerms(GroceryJson);
        }

        /// <summary>
        /// builds up the custom grocery information.
        /// </summary>
        private void GetGroceryFromJson()
        {
            TescoProducts = new List<TescoProduct>();

            if (GroceryJson != null)
            {
                foreach (var productsResult in GroceryJson.uk.ghs.products.results)
                {
                    TescoProduct tescoProduct = new TescoProduct(productsResult.name, productsResult.image, GetProductLifeStyles(productsResult.tpnb.ToString(), ProductSearch.Tpnb), productsResult.tpnb, GetGTIN(productsResult.image), GetTPNC(productsResult.tpnb.ToString()));
                    TescoProducts.Add(tescoProduct);
                }
            }
        }

        private List<Lifestyle> GetProductLifeStyles(string id, ProductSearch productSearch)
        {
            var productInfo = GetProductDetailJson(id, productSearch);
            if (productInfo.products != null)
            {
                if (productInfo.products.FirstOrDefault().productAttributes != null)
                {
                    if (productInfo.products.FirstOrDefault().productAttributes.FirstOrDefault().category != null)
                    {
                        if (
                            productInfo.products.FirstOrDefault()
                                .productAttributes.FirstOrDefault()
                                .category.FirstOrDefault()
                                .lifestyle != null)
                        {
                            return
                                productInfo.products.FirstOrDefault()
                                    .productAttributes.FirstOrDefault()
                                    .category.FirstOrDefault()
                                    .lifestyle;
                        }
                        return null;
                    }
                    return null;
                }
                return null;
            }
            return null;

        }

        /// <summary>
        /// private enum to sort which method to call for product infomation
        /// </summary>
        private enum ProductSearch
        {
        Gtin,
        Tpnb,
        Tpnc
        }

        /// <summary>
        /// Get the product information on a specific id and method call using the enum
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SearchType"></param>
        /// <returns></returns>
        private TescoProductRoot GetProductDetailJson(string id, ProductSearch searchType)
        {
            if (searchType == ProductSearch.Gtin)
            {
               return TescoGetQuerys.GetProductInfoGtin(id);
            }
            if (searchType == ProductSearch.Tpnb)
            {
                return TescoGetQuerys.GetProductInfoTpnb(id);
            }
            if (searchType == ProductSearch.Tpnc)
            {
                return TescoGetQuerys.GetProductInfoTpnc(id);
            }
            return null;
        }

        /// <summary>
        /// collects the id from the image url which is the GTIN
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetGTIN(string url)
        {
            return url.Split('/')[url.Split('/').Length-2];
        }

        /// <summary>
        /// Gets the TPNC using the TPNB id
        /// Call here hit the API, any further product detials should use expand off this call.
        /// </summary>
        /// <param name="tpnb"></param>
        /// <returns></returns>
        private string GetTPNC(string tpnb)
        {
            var productInfo = GetProductDetailJson(tpnb, ProductSearch.Tpnb);
            if (productInfo.products != null)
            {
                return productInfo.products.FirstOrDefault().tpnc;
            }
            return "invalidTPNC";
        }


        /// <summary>
        /// Collects the suggested terms from the api query
        /// </summary>
        /// <param name="productJson"></param>
        public void GetSuggestedTerms(TescoGroceryRoot productJson)
        {
            List<Suggestion> _suggestedTerms = new List<Suggestion>();
            if (productJson.uk.ghs.products.suggestions.Any())
            {
                foreach (var item in productJson.uk.ghs.products.suggestions)
                {
                    if (item != null)
                    {
                        _suggestedTerms.Add(item);
                    }
                }
            }
            SuggestedTerms = _suggestedTerms;
        }

        
    }

    public class TescoProduct
    {
        public string Name;
        public string Img;
        public List<Lifestyle> Lifestyles = new List<Lifestyle>();
        public string Tpnc { get; set; }
        public int Tpnb { get; set; }
        public string Gtin { get; set; }

        public TescoProduct(string name, string image, List<Lifestyle> lifestyles = null, int tpnb = 0, string gtin = "", string tpnc = "")
        {
            Name = name;
            Img = image;
            Lifestyles = lifestyles;
            Tpnc = tpnc;
            Tpnb = tpnb;
            Gtin = gtin;
        }
    }

}
