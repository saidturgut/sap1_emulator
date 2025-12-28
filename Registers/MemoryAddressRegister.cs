namespace sap1_emulator.Registers;
using Signals;

public class MemoryAddressRegister : Register
{
    public override void Latch(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.MAR_LOAD))
            base.Latch(bus, signals);
    }

    public byte DriveToRam()
    {
        return value;
    }
}