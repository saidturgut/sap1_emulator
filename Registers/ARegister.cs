namespace sap1_emulator.Registers;
using Signals;
using External;

public class ARegister : Register
{
    public override void Drive(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.A_OUT))
            base.Drive(bus, signals);
    }

    public override void Latch(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.A_LOAD))
            base.Latch(bus, signals);

        if (!Flags.DebugMode) return;
        Console.WriteLine($"A REGISTER -> {Assembler.PrintBinary(value)}");
    }
    
    public byte DriveToALU()
    {
        return value;
    }
}