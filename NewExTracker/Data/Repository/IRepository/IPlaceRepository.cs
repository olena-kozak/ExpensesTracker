using NewExTracker.Models;

namespace NewExTracker.Data.Repository.IRepository
{
    public interface IPlaceRepository
    {
        bool PlaceExist(string name);

        public Place GetPlaceByOtpName(PlaceRequest placeRequest);

        public string GetPlaceByOtpSmartName(string otpSmartName);

        bool PlaceExist(int id);


        bool CreatePlace(Place place);


        bool UpdatePlace(Place place);


        bool DeletePlace(Place place);


        bool Save();
    }
}
