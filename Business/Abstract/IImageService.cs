using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface IImageService
    {


        IResult Add(IFormFile file, Image carImage);
        IResult Delete(Image carImage);
        IResult Update(IFormFile formFile, Image carImage);

        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetByCarId(int carId);
        IDataResult<Image> GetByImageId(int imageId);
    }
}
