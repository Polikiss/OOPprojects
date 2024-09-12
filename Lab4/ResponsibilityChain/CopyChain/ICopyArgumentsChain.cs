using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CopyChain;

public interface ICopyArgumentsChain
{
    public void AddNext(ICopyArgumentsChain link);

    public ParseArgumentResult Handle(Request request, FileCopyModel.Builder builder);
}