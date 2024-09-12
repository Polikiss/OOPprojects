using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public class ComputerCaseDirect : IComputerCaseDirect
{
    private IComputerCaseBuilder _builder;

    public ComputerCaseDirect(IComputerCaseBuilder builder)
    {
       _builder = builder;
    }

    public IComputerCaseBuilder Direct()
    {
        _builder.WithDimension(360, 175, 360);
        _builder.WithMaxWidthAndHighVideoCard(142, 300);
        _builder.AddFormFactors(FormFactor.Atx);
        _builder.AddFormFactors(FormFactor.MiniAtx);
        _builder.AddFormFactors(FormFactor.MicroAtx);

        return _builder;
    }
}