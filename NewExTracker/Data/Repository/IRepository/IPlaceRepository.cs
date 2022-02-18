using NewExTracker.Models;

namespace NewExTracker.Data.Repository.IRepository
{
    public interface IPlaceRepository
    { 
        bool PlaceExist(string name);


        bool PlaceExist(int id);


        bool CreatePlace(Place place);


        bool UpdatePlace(Place place);


        bool DeletePlace(Place place);


        bool Save();
    }
}
