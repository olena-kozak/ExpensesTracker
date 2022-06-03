using NewExTracker.BussinessLogic.Exceptions;
using NewExTracker.Data.Repository.IRepository;
using NewExTracker.Models;

namespace NewExTracker.Data.Repository
{
    public class PlaceRepository : IPlaceRepository
    {
        private ApplicationDbContext _dbContext;
        public PlaceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreatePlace(Place place)
        {
            _dbContext.Places.Add(place);
            return Save();
        }

        public Place GetPlaceByOtpName(PlaceRequest placeRequest)
        {
            if (PlaceExist(placeRequest.OTPSmartName))
            {
                return _dbContext.Places.Where(x => x.OtpsmartName == placeRequest.OTPSmartName).FirstOrDefault();
            }
            return new Place
            {
                OtpsmartName = placeRequest.OTPSmartName,
                Name = null
            };
        }

        public string GetPlaceByOtpSmartName(string otpSmartName)
        {

            if (PlaceExist(otpSmartName))
            {
                return _dbContext.Places.Where(x => x.OtpsmartName == otpSmartName).FirstOrDefault().Name;
            }
            return otpSmartName;

        }

        public bool DeletePlace(Place place)
        {
            throw new NotImplementedException();
        }

        public bool PlaceExist(string otpsmartName)
        {
            bool value = _dbContext.Places.Any(a => a.OtpsmartName.ToLower().Trim() == otpsmartName.ToLower().Trim());
            return value;
        }

        public bool PlaceExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdatePlace(Place place)
        {
            throw new NotImplementedException();
        }


    }
}
