﻿using System;

namespace FilmWebAPI.Requests.Get
{
    public class ItemPerson
    {
        private readonly Item _item;

        public ItemPerson(Item item)
        {
            _item = item;
        }

        public ItemType ItemType => _item.ItemType;
        public string[] Raw => _item.Raw;

        public Uri GetPhotoUrl()
        {
            var photoId = int.Parse(Raw[2]);

            if (photoId == 0)
                return new Uri("https://2.fwcdn.pl/gf/beta/ic/plugs/v01/plug.svg");

            return new Uri("https://fwcdn.pl/ppo" + photoId);
        }

        public ProfessionType GetProfessionType()
        {
            var professionTypeId = int.Parse(Raw[5]);

            if (professionTypeId == 0)
                return ProfessionType.we_własnej_osobie; /* Osoba */

            var professionSubTypeId = int.Parse(Raw[4]);
            var professionTypes = ProfessionTypeMap.Instance[professionTypeId];

            if (professionSubTypeId == 0)
                return professionTypes[0];

            return professionTypes[professionSubTypeId];
        }

        public string GetCaption()
        {
            return Raw[6];
        }

        public string GetFullName()
        {
            return Raw[3];
        }

        public int GetId()
        {
            return int.Parse(Raw[1]);
        }
    }
}