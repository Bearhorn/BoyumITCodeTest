using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;

namespace Boyum_IT_code_challenge.Models
{
    [XmlRoot("WebOrder")]
    public class WebOrder
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("Customer")]
        public string Customer { get; set; }
        [XmlElement("Date")]
        public string RawDate { get; set; }
        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<WebOrderItem> Items { get; set; }

        [XmlIgnore]
        public DateTime Date => DateTime.ParseExact(RawDate, "yyyyMMdd", CultureInfo.InvariantCulture);
        [XmlIgnore]
        public decimal Total => Items.Select(x => x.Price * x.Quantity).Sum();
        [XmlIgnore]
        public decimal AvgPrice => Items.Average(x => x.Price);
    }
}
