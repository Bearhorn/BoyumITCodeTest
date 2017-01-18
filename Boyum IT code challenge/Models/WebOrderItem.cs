using System.Xml.Serialization;

namespace Boyum_IT_code_challenge.Models
{
    public class WebOrderItem
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlElement("Price")]
        public decimal Price { get; set; }
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}
