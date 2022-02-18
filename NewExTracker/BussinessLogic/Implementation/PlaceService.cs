using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Mapper;
using NewExTracker.Data.Repository.IRepository;
using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class PlaceService : IPlaceService
    {
        private IPlaceRepository _placeRepository;
        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public bool CreatePlace(PlaceRequest addPlaceRequest)
        {
            Place placeEntity = addPlaceRequest.ToEntity();
            return _placeRepository.CreatePlace(placeEntity);
        }

        public bool PlaceExist(string name)
        {
           return _placeRepository.PlaceExist(name);
        }
    }
}
