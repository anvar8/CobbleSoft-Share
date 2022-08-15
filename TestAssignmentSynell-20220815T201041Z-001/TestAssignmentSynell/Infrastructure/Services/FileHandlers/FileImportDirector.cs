using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Services.FileHandlers.CSV;

namespace Infrastructure.Services.FileHandlers
{
    public class FileImportDirector<T>
    {
        private readonly Stream _fileStream;
        private readonly IStrategy _strategy;
        public FileImportDirector(Stream fileStream, string extension, IStrategy strategy)
        {
            _strategy = strategy;
            _fileStream = fileStream;
            SetFormatter(extension);


        }
        public FileImportDirector(Stream fileStream, string extension)
        {
            _fileStream = fileStream;
            SetFormatter(extension);


        }
        private void SetFormatter(string ext)
        {
            if (ext.ToLower().Trim() == ".csv")
            {
                _fileService = new CSVFileHandler<T>(_strategy);
            }
        }
        private FileService<T> _fileService;
        public List<T> GetObjectListFromStream()
        {
            return _fileService.StreamToObjectList(_fileStream);
        }
    }
}