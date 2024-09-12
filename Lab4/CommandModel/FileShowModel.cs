using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel;

[GenerateBuilder]
public partial record FileShowModel(string FilePath, IWriter Mode) : ICommandModel;