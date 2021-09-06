using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRule.Run
                (CheckCarMaxImageLimit(carImage.CarId));

            var carImageResult = FileHelperManager.Upload(file);
            if (!carImageResult.Success)
            {
                return new ErrorResult(carImageResult.Message);
            }
            carImage.ImagePath = carImageResult.Message;
            carImage.UploadDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (image != null)
            {
                FileHelperManager.Delete(image.ImagePath);
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.CarImageDeleted);
            }
            return new ErrorResult(Messages.CarImageNotFound);
        }

        public IDataResult<CarImage> FindByID(int Id)
        {
            return new SuccessDataResult<CarImage>
                (_carImageDal.Get(c => c.CarId == c.CarImageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>
                (_carImageDal.GetAll(),Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetCarListByCarID(int carID)
        {
            IResult result = BusinessRule.Run(CarImageCheck(carID));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>
                (CarImageCheck(carID).Data,Messages.CarImageListed);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            var updated = FileHelperManager.Update(file, image.ImagePath);
            if (!updated.Success)
            {
                return new ErrorResult(updated.Message);
            }
            carImage.ImagePath = updated.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        //private metotlar
        private IDataResult<List<CarImage>> CarImageCheck(int carId)
        {
            try
            {
                string path = @"\images\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = carId, ImagePath = path, UploadDate = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
        }
        private IResult CheckCarMaxImageLimit(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (result > 5)
            {
                return new ErrorResult("Limit doldu.");
            }
            return new SuccessResult();
        }
    }
}
