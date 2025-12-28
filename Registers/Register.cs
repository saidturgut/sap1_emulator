using sap1_emulator.Interfaces;

namespace sap1_emulator.Registers;
using Signals;

public class Register 
{
    protected byte value;
    
    public virtual void Drive(Bus bus, Signal[]  signals)
    {
        bus.Load(value);            
    }

    public virtual void Latch(Bus bus, Signal[]  signals)
    {
        value = bus.Output();
    }
}