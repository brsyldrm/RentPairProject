using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Concretes
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.ImageDate = DateTime.UtcNow;
            _carImageDal.Add(carImage);
            return new SuccessResult("resim başarıyla eklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        public IDataResult<CarImage> Get(int id)
        {

            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<bool> Upload(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return new ErrorDataResult<bool>(false);

            var yuklemeDizini = "YuklenenDosyalar"; // İstediğiniz bir dizin adı
            var yuklemeYolu = Path.Combine(Directory.GetCurrentDirectory(), yuklemeDizini);

            if (!Directory.Exists(yuklemeYolu))
                Directory.CreateDirectory(yuklemeYolu);

            foreach (var dosya in files)
            {
                if (dosya.Length == 0)
                    continue;

                var dosyaYolu = Path.Combine(yuklemeYolu, dosya.FileName);

                using (var stream = new FileStream(dosyaYolu, FileMode.Create))
                {
                    dosya.CopyTo(stream);
                }
            }

            return true;
        }

    }
}
}
