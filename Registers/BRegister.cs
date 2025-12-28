using sap1_emulator.External;

namespace sap1_emulator.Registers;
using Signals;

public class BRegister : Register
{
    public override void Latch(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.B_LOAD))
            base.Latch(bus, signals);
        
        if (!Flags.DebugMode) return;
        Console.WriteLine($"B REGISTER -> {Assembler.PrintBinary(value)}");
    }
    
    public byte DriveToALU()
    {
        return value;
    }
}