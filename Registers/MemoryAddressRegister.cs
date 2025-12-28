namespace sap1_emulator.Registers;
using Signals;
using External;

public class MemoryAddressRegister : Register
{
    public override void Latch(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.MAR_LOAD))
            base.Latch(bus, signals);
        
        if (!Flags.DebugMode) return;
        Console.WriteLine($"MEMORY ADDRESS REGISTER -> {Assembler.PrintBinary(value)}");
    }

    public byte DriveToRam()
    {
        return value;
    }
}