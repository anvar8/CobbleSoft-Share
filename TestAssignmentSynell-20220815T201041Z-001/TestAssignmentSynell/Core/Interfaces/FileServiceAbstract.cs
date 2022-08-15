using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    //we need abstract class in case we want to add standard operations for all classes inheriting from it
    public  abstract class FileService<T>
    {
         public  abstract List<T> StreamToObjectList(Stream stream);
    }
}