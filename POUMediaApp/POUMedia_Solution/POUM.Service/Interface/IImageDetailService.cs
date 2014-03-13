using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using POUM.Entity;
using POUM.DataLayer;
using POUM.DataLayer.Interface;
using System.IO;

namespace POUM.Service.Interface
{
    public interface IImageDetailService : IRepository<ImageDetail>
    {
        int Save(ImageDetail imageDetail);

        byte[] HandleUpload(Stream fileStream);

        //byte[] LoadImage(byte[] fileStream, out string type);
    }
}
