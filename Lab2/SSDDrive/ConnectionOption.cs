namespace Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;

public record ConnectionOption()
{
    public sealed record PciE : ConnectionOption;

    public sealed record Sata : ConnectionOption;
}