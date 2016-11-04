﻿using System;
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

        /// <summary>
        /// Product info from GTIN
        /// </summary>
        /// <param name="gtin"></param>
        /// <returns></returns>
        public static TescoProductRoot GetProductInfoGtin (string gtin = "")
        {
            HttpClient client = new HttpClient();
            var uri = "https://dev.tescolabs.com/product/?gtin=" + gtin;
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
        /// <summary>
        /// Product info from tbnc
        /// </summary>
        /// <param name="tpnc"></param>
        /// <returns></returns>
        public static TescoProductRoot GetProductInfoTpnc(string tpnc = "")
        {
            HttpClient client = new HttpClient();
            var uri = "https://dev.tescolabs.com/product/?tpnc=" + tpnc;
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
        /// <summary>
        /// Product info from tpnb
        /// </summary>
        /// <param name="tpnb"></param>
        /// <returns></returns>
        public static TescoProductRoot GetProductInfoTpnb(string tpnb = "")
        {
            HttpClient client = new HttpClient();
            var uri = "https://dev.tescolabs.com/product/?tpnb=" + tpnb;
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
