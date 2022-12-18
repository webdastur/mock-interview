namespace Application.Services.Files;

public interface IFileService
{
    Task<FileModel> CreateFile(FileCreateModel createFileModel);
    Task<FileModel> File(int fileId);
}
