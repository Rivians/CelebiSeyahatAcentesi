﻿using CelebiSeyehat.Dto.Hotel;
using CelebiSeyehat.Dto.HotelRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.HotelType
{
    public class RoomTypeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string HotelId { get; set; }
    }
}
