namespace sap1_emulator.Registers;
using Signals;

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
    }

    public void LatchFromAlu(byte input)
    {
        value = input;
    }
    
    public byte DriveToALU()
    {
        return value;
    }
}