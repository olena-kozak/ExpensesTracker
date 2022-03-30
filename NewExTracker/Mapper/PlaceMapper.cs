﻿using NewExTracker.Models;

namespace NewExTracker.Mapper
{
    public static class PlaceMapper
    {
        public static Place ToEntity(this PlaceRequest place)
        {
            if (place != null)
            {
                return new Place
                {
                    OtpsmartName = place.OTPSmartName,
                    Name = place.Name
                };
            }
            else { return null; }
        }
    }
}