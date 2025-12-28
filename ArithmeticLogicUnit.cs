namespace sap1_emulator;
using Registers;
using Signals;

public class ArithmeticLogicUnit
{
    private byte value;
    
    public void Compute(ARegister aRegister, BRegister bRegister, Signal[] signals)
    {
        byte a = aRegister.DriveToALU();
        byte b = bRegister.DriveToALU();

        if (signals.Contains(Signal.ALU_ADD))
            value = (byte)(a + b);
        if (signals.Contains(Signal.ALU_SUB))
            value =(byte)(a + ~b + 1);
    }

    public void Drive(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.ALU_OUT))
            bus.Load(value);
    }
}