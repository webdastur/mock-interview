using Application.Common.Interfaces;
using Application.Services.Files;
using AutoMapper;
using Infrastructure.Helpers;
using File = Domain.Entities.File;

namespace Infrastructure.Services.Files;

public class FileService : IFileService
{
    private readonly IRepository<File> repository;
    private readonly IMapper mapper;

    public FileService(IRepository<File> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<FileModel> CreateFile(FileCreateModel createFileModel)
    {
        string imageName = await ImageUploader.UploadImage(createFileModel.File);

        FileModel fileModel = new()
        {
            Name = imageName,
            Path = ImageUploader.ImagePath()
        };

        var mappingImageModel = mapper.Map<File>(fileModel);
        repository.Add(mappingImageModel);
        return mapper.Map<FileModel>(mappingImageModel);
    }

    public async Task<FileModel> File(int fileId)
    {
        File file = await repository.GetByIdAsync(fileId);
        if (file is null)
            throw new Exception("file not found");

        return mapper.Map<FileModel>(file);
    }
}
