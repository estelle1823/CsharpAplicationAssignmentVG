namespace Infrastructure.Interfaces;

public interface IFileService
{
    bool SaveJsonContentToFile(string jsonContent, string fileName);

    string GetJsonContentFromFile(string filePath);

}