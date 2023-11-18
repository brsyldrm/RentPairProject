
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> Get(int id);
    }
}
