namespace sap1_emulator.Registers;
using Signals;
using External;

public class ProgramCounter : Register
{
    public override void Drive(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.PC_OUT))
            base.Drive(bus, signals);
    }

    public override void Latch(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.PC_INC))
            value++;
        
        if (signals.Contains(Signal.PC_LOAD))
            base.Latch(bus, signals);
        
        if (!Flags.DebugMode) return;
        Console.WriteLine($"PROGRAM COUNTER -> {Assembler.PrintBinary(value)}");
    }
}