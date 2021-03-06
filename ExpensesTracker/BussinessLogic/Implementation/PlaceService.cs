using ExpensesTracker.BussinessLogic.Abstract;
using ExpensesTracker.Data.Repository.IRepository;
using ExpensesTracker.Models;
using ExpensesTracker.Mapper;
using System.Text.RegularExpressions;
using RegexPaterns = ExpensesTracker.Models.RegexPaterns;
using ExpensesTracker.BussinessLogic.Exceptions;

namespace ExpensesTracker.BussinessLogic.Implementation
{
    public class PlaceService : IPlaceService
    {
        private IPlaceRepository _placeRepository;
        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public bool CreatePlace(PlaceRequest placeRequest)
        {
            Place placeEntity = placeRequest.ToEntity();
            return _placeRepository.CreatePlace(placeEntity);
        }

        public Place GetPlaceByOtpName(PlaceRequest placeRequest)
        {
            return _placeRepository.GetPlaceByOtpName(placeRequest);
        }

        public string GetPlaceByOtpSmartName(string message, string operationType)
        {
            var regex = new Regex(RegexPaterns.PAYMENT_MESSAGE_PLACE_PATTERN);
            var match = regex.Match(message);
            if (match.Success)
            {
                var matchingString = match.Value;
                int indexStart = matchingString.IndexOf(":") + 1;
                int indexEnd = matchingString.Length - 1;
                int length = indexEnd - indexStart;
                string place = matchingString.Substring(indexStart, length).Trim();
                return _placeRepository.GetPlaceByOtpSmartName(place);
            }
            else
            {
                throw new RegexException("Regex pattern didn't found");
            }
        }

        public bool PlaceExist(string name)
        {
            return _placeRepository.PlaceExist(name);
        }
    }
}
