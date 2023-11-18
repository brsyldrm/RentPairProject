
using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Abstracts
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);
        IDataResult<bool> Upload(List<IFormFile> files);
    }
}
