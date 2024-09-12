using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemResultType;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string fileSystemAddress)
    {
        FileSystemAddress = fileSystemAddress;
    }

    public string FileSystemAddress { get; }
    public bool IsFileExists(string name)
    {
        var fileInfo = new FileInfo(name);
        return fileInfo.Exists;
    }

    public bool IsPathRooted(string path)
    {
        return Path.IsPathRooted(path);
    }

    public bool IsDirectoryExists(string name)
    {
        var dirInfo = new DirectoryInfo(name);
        return dirInfo.Exists;
    }

    public FileSystemResult MoveTo(string sourcePath, string destinationPath, string currentAddress)
    {
        if (Path.IsPathRooted(sourcePath) is false)
        {
            sourcePath = currentAddress + sourcePath;
        }

        if (Path.IsPathRooted(destinationPath) is false)
        {
            destinationPath = currentAddress + destinationPath;
        }

        var fileInfo = new FileInfo(sourcePath);
        var dirInfo = new DirectoryInfo(destinationPath);
        if (fileInfo.Exists is false) return new FileSystemResult.Fail("File is not exist");
        if (dirInfo.Exists is false) return new FileSystemResult.Fail("Directory is not exist");
        string newPath = CreateNewPath(fileInfo, destinationPath, fileInfo.Name);
        fileInfo.MoveTo(newPath);
        return new FileSystemResult.Success();
    }

    public FileSystemResult Show(string path, string currentAddress, IWriter writer)
    {
        if (Path.IsPathRooted(path) is false)
        {
            path = currentAddress + path;
        }

        var fileInfo = new FileInfo(path);
        if (fileInfo.Exists is false) return new FileSystemResult.Fail("Fail is not exist");
        string fileText = File.ReadAllText(path);
        writer.Print(fileText);
        return new FileSystemResult.Success();
    }

    public FileSystemResult Rename(string path, string currentAddress, string name)
    {
        if (Path.IsPathRooted(path) is false)
        {
            path = currentAddress + path;
        }

        var fileInfo = new FileInfo(path);
        if (fileInfo.Exists is false)
            return new FileSystemResult.Fail("File is not exist");

        if (fileInfo.DirectoryName is not null)
        {
            string newPath = CreateNewPath(fileInfo, fileInfo.DirectoryName, name);
            var newFile = new FileInfo(newPath);
            newFile.Create();
            fileInfo.Delete();
            return new FileSystemResult.Success();
        }

        return new FileSystemResult.Fail("File is not exist");
    }

    public FileSystemResult Copy(string sourcePath, string currentAddress, string destinationPath)
    {
        if (Path.IsPathRooted(sourcePath) is false)
        {
            sourcePath = currentAddress + sourcePath;
        }

        if (Path.IsPathRooted(destinationPath) is false)
        {
            destinationPath = currentAddress + destinationPath;
        }

        var fileInfo = new FileInfo(sourcePath);
        var dirInfo = new DirectoryInfo(destinationPath);
        if (fileInfo.Exists is false) return new FileSystemResult.Fail("File is not exist");
        if (dirInfo.Exists is false) return new FileSystemResult.Fail("Directory is not exist");
        string newPath = CreateNewPath(fileInfo, destinationPath, fileInfo.Name);
        fileInfo.CopyTo(newPath);
        return new FileSystemResult.Success();
    }

    public FileSystemResult Delete(string path, string currentAddress)
    {
        if (Path.IsPathRooted(path) is false)
        {
            path = currentAddress + path;
        }

        var fileInfo = new FileInfo(path);
        if (fileInfo.Exists is false)
            return new FileSystemResult.Fail("File is not exist");
        fileInfo.Delete();
        return new FileSystemResult.Success();
    }

    public IComponent CreateComponent(string fileSystemRootPath, int depth)
    {
        var dirRoot = new DirectoryInfo(fileSystemRootPath);
        IComponent fileSystemRoot = new DirectoryComponent(dirRoot.Name);
        string[] files = Directory.GetFiles(fileSystemRootPath);
        foreach (string fileFullPath in files)
        {
            var fileInfo = new FileInfo(fileFullPath);
            IComponent fileLeaf = new FileComponent(fileInfo.Name);
            fileSystemRoot.Add(fileLeaf);
        }

        string[] dirs = Directory.GetDirectories(fileSystemRootPath);

        if (depth <= 0)
            return fileSystemRoot;

        foreach (string dirFullPath in dirs)
        {
            fileSystemRoot.Add(CreateComponent(dirFullPath, depth - 1));
        }

        return fileSystemRoot;
    }

    private static string CreateNewPath(FileInfo fileInfo, string directory, string name)
    {
        string newPath = directory + name;
        var copyFileInfo = new FileInfo(newPath);
        if (copyFileInfo.Exists is false) return newPath;
        int index = 1;
        while (copyFileInfo.Exists)
        {
            newPath = directory + '(' + index + ')' + fileInfo.Name;
            copyFileInfo = new FileInfo(newPath);
            index++;
        }

        return newPath;
    }
}