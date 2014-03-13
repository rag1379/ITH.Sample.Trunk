using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POUM.Service.Interface;
using POUM.DataLayer.Interface;
using POUM.DataLayer.Repository;
using POUM.Entity;

namespace POUM.Service
{
    public class ImageDetailService : Repository<ImageDetail>, IImageDetailService
    {

         private IUnitOfWork uow = null;

         private IImageDetailRepository repository = null;



        public ImageDetailService(IImageDetailRepository imageDetailRepository, IUnitOfWork unitOFWork)
            :base(unitOFWork)
        {
            this.uow = unitOFWork;
            this.repository = imageDetailRepository;
        }

        public int Save(ImageDetail imageDetail)
        {
            if (imageDetail.ImageId == 0)
            {                
                return repository.Add(imageDetail);
            }
            else
            {
                return repository.Update(imageDetail);
            }
        }


        public byte[] HandleUpload(Stream fileStream)
        {            
            try
            {
                byte[] documentBytes = new byte[fileStream.Length];
                fileStream.Read(documentBytes, 0, documentBytes.Length);
                
                return documentBytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public byte[] LoadImage(byte[] fileStream, out string type)
        //{

            

        //    byte[] fileBytes = null;
        //    string fileType = null;
        //    using (DocumentEntities databaseContext = new DocumentEntities())
        //    {
        //        var databaseDocument = databaseContext.Documents.FirstOrDefault(doc => doc.DocumentId == id);
        //        if (databaseDocument != null)
        //        {
        //            fileBytes = databaseDocument.FileContent;
        //            fileType = databaseDocument.Type;
        //        }
        //    }
        //    type = fileType;
        //    return fileBytes;
        //}
    }
}
