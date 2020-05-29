﻿using System;
using System.Collections.Generic;

namespace FilmWebAPI.Requests.Get
{
    public class ItemSerial
    {
        private readonly Item _item;

        public ItemSerial(Item item)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
        }

        public ItemType ItemType => _item.ItemType;
        public string[] Raw => _item.Raw;

        public int GetId()
        {
            return int.Parse(Raw[1]);
        }

        public Uri GetPhotoUrl()
        {
            var photoId = int.Parse(Raw[2]);

            if (photoId == 0)
                return new Uri("https://2.fwcdn.pl/gf/beta/ic/plugs/v01/plug.svg");

            return new Uri("https://fwcdn.pl/fpo" + photoId);
        }

        public List<string> GetTitles()
        {
            return new List<string>
            {
                Raw[3],
                Raw[4],
                Raw[5]
            };
        }

        public int? GetProductionYear()
        {
            if (string.Equals(Raw[6], string.Empty))
                return null;

            return int.Parse(Raw[6]);
        }

        public string GetCaption()
        {
            return Raw[7];
        }
    }
}