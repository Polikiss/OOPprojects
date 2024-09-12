using Itmo.ObjectOrientedProgramming.Lab2.BIOS;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class MotherboardDirect : IMotherboardDirect
{
    private IMotherboardBuilder _builder;

    public MotherboardDirect(IMotherboardBuilder builder)
    {
        _builder = builder;
    }

    public IMotherboardBuilder Direct()
    {
        _builder.WithSocket("Intel", "AM3");
        _builder.WithAmountPcieLines(4);
        _builder.WithDdrStandard(3);
        _builder.WithFormFactor(FormFactor.Atx);
        _builder.WithAmountRamSlots(8);
        _builder.WithAmountSataPorts(4);

        IBiosBuilder biosBuilder = new BiosBuilder();
        IBiosDirect biosDirect = new BiosDirect(biosBuilder);
        biosBuilder = biosDirect.Direct();
        IBios bios = biosBuilder.BuildBios();
        _builder.WithBios(bios);

        return _builder;
    }
}