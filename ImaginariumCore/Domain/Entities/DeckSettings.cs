using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Domain.Entities
{
    public class DeckSettings
    {

        public DeckSettings()
        {
            SizeToCount = new Dictionary<int, int>();
            XmlReader reader = XmlReader.
                Create(@"C:\Csharp\ImaginariumCore\ImaginariumCore\ImaginariumCore\Domain\CardDistributorConfig.xml");//
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "players": SizeToCount.Add(Int32.Parse(reader.GetAttribute("count")) 
                        , reader.ReadElementContentAsInt());
                        break;
                }
            }
        }

        public static IDictionary<int,int> SizeToCount { get; private set; }

        public static int CountOfCards(int lobbySize)
        {
            return SizeToCount.SingleOrDefault(pair => pair.Key.Equals(lobbySize)).Value;
        }
    }
}