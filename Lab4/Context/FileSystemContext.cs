using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Context;

public record FileSystemContext(IFileSystem? FileSystem, string CurrentPath, string Prefix, string Indent)
{
    public string CurrentPath { get; set; } = CurrentPath;
    public IFileSystem? FileSystem { get; set; } = FileSystem;
}