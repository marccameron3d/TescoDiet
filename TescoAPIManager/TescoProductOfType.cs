using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TescoAPIManager
{
    class TescoProductOfType
    {
        public string Name;
        public string Img;
        public List<string> Lifestyles;
        public string tpnc { get; set; }
        public string tpnb { get; set; }
        public string gtin { get; set; }

        public TescoProductOfType(string name, string image, List<string> lifeStyles )
        {
            Name = name;
            Img = image;
            Lifestyles = lifeStyles;
        }
    }
}
