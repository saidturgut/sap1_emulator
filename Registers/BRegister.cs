namespace sap1_emulator.Registers;
using Signals;

public class BRegister : Register
{
    public override void Latch(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.B_LOAD))
            base.Latch(bus, signals);
    }
    
    public byte DriveToALU()
    {
        return value;
    }
}