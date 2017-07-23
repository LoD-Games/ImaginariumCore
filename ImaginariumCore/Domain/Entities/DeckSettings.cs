using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Domain.Entities
{
    public class DeckSettings
    {

        public DeckSettings()
        {
            SizeToCount = new Dictionary<int, int>();
            var localPath =
                @"C:\Csharp\ImaginariumCore\ImaginariumCore\ImaginariumCore\Domain\CardDistributorConfig.xml";
            var configPath = localPath;
            var azurePath = @"CardDistributorConfig.xml";
            if (!File.Exists(localPath))
            {
                configPath = azurePath;
            }
            XmlReader reader = XmlReader.Create(configPath);// 
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