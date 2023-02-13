using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _color;

        public ColorManager(IColorDal color)
        {
            _color = color;
        }

        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult(color.ColorName + Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult(color.ColorName + Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_color.Get(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult(color.ColorName + Messages.ColorUpdated);
        }
    }
}
