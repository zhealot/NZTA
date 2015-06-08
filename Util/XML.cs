using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NZTA_Contract_Generator.Util
{
    static class XML
    {

        //Check to see if this document has XML saved state and if so load it
        public static Contract loadFromXML()
        {
            Microsoft.Office.Core.DocumentProperties properties;
            properties = (Microsoft.Office.Core.DocumentProperties)NZTA_Contract_Generator.Globals.ThisDocument.CustomDocumentProperties;
            try
            {
                Microsoft.Office.Core.CustomXMLPart xmlPart = NZTA_Contract_Generator.Globals.ThisDocument.CustomXMLParts.SelectByID(properties["xmlId"].Value);
                XmlSerializer deserializer = new XmlSerializer(typeof(Contract));
                Contract c = (Contract)deserializer.Deserialize(new StringReader(xmlPart.XML));
                return c;
            }
            catch (System.ArgumentException e)
            {

            }
            return null;
        }

        //Save state to XML stored in document
        public static void saveToXML(Contract c)
        {

            StringWriter writer = new StringWriter();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(c.GetType());
            x.Serialize(writer, c);
            Microsoft.Office.Core.CustomXMLPart xmlPart = NZTA_Contract_Generator.Globals.ThisDocument.CustomXMLParts.Add(writer.ToString());
            
            
            Microsoft.Office.Core.DocumentProperties properties;
            properties = (Microsoft.Office.Core.DocumentProperties)NZTA_Contract_Generator.Globals.ThisDocument.CustomDocumentProperties;
            try
            {
                properties["xmlId"].Value = xmlPart.Id;
            }
            catch (System.ArgumentException e)
            {
                properties.Add("xmlId", false, MsoDocProperties.msoPropertyTypeString, xmlPart.Id);
            }
            

        }

    }
}
