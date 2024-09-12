using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel;

[GenerateBuilder]
public partial record FileMoveModel(string FileSourcePath, string FileDestinationPath) : ICommandModel;