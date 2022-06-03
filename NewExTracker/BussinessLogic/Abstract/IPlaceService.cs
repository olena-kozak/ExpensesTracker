using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IPlaceService
    {
        public bool CreatePlace(PlaceRequest addPlaceRequest);
        public bool PlaceExist(string name);
        public Place GetPlaceByOtpName(PlaceRequest placeRequest);
        public string GetPlaceByOtpSmartName(string message, string operationType);


    }
}
