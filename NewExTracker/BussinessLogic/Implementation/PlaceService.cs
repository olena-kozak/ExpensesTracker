using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Data.Repository.IRepository;
using NewExTracker.Models;
using NewExTracker.Mapper;
using System.Text.RegularExpressions;

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

        public Place GetPlaceByOtpName(PlaceRequest placeRequest)
        {
            return _placeRepository.GetPlaceByOtpName(placeRequest);
        }

        public string GetPlaceByOtpSmartName(string message)
        {
            Regex regex = new Regex(@"Misce[:]\s.+[.]");
            Match match = regex.Match(message);
            if (match.Success)
            {
                var matchingString = match.Value;
                int indexStart = matchingString.IndexOf(":") + 1;
                int indexEnd = matchingString.IndexOf(".");
                int length = indexEnd - indexStart;
                string place = matchingString.Substring(indexStart, length).Trim();
                return _placeRepository.GetPlaceByOtpSmartName(place);
            }
            return null;
        }

        public bool PlaceExist(string name)
        {
            return _placeRepository.PlaceExist(name);
        }
    }
}
