namespace sap1_emulator.External;

internal static class RunEmulator
{
    private static readonly CentralProcessingUnit Cpu = new CentralProcessingUnit();

    private static void Main() => Cpu.Init();
}