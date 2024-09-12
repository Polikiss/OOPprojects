using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel;

[GenerateBuilder]
public partial record FileCopyModel(string FileSourcePath, string FileDestinationPath) : ICommandModel;