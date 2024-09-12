using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel;

[GenerateBuilder]
public partial record FileRenameModel(string FilePath, string Name) : ICommandModel;