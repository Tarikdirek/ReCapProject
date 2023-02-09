using Business.Abstract;
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

        public void Add(Color color)
        {
            _color.Add(color);
            Console.WriteLine(color.ColorName+" color added on database.");
        }

        public void Delete(Color color)
        {
            _color.Delete(color);
            Console.WriteLine(color.ColorName + " color deleted from database.");
        }

        public List<Color> GetAll()
        {
            return _color.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _color.Get(c => c.ColorId == colorId);
        }

        public void Update(Color color)
        {
            _color.Update(color);
            Console.WriteLine(color.ColorName + " color update on database.");
        }
    }
}
