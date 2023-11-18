
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
    }
}
