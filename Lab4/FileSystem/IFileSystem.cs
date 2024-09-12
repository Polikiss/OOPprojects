using Itmo.ObjectOrientedProgramming.Lab4.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemResultType;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    public string FileSystemAddress { get; }
    public bool IsFileExists(string name);
    public bool IsPathRooted(string path);
    public bool IsDirectoryExists(string name);
    public FileSystemResult MoveTo(string sourcePath, string destinationPath, string currentAddress);
    public FileSystemResult Show(string path, string currentAddress, IWriter writer);
    public FileSystemResult Rename(string path, string currentAddress, string name);
    public FileSystemResult Copy(string sourcePath, string currentAddress, string destinationPath);
    public FileSystemResult Delete(string path, string currentAddress);
    public IComponent CreateComponent(string fileSystemRootPath, int depth);
}