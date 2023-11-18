
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);
    }
}
