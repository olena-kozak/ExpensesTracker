using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IPlaceService
    {
        public bool CreatePlace(PlaceRequest addPlaceRequest);
        public bool PlaceExist(string name);
    }
}
