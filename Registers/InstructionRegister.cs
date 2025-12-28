namespace sap1_emulator.Registers;
using Signals;

public class InstructionRegister : Register
{
    public override void Drive(Bus bus, Signal[] signals)
    {
        //Console.WriteLine($"DEBUGGER {Convert.ToString(Convert.ToByte(value & 0x0F), 2).PadLeft(8, '0')}");
        
        if(signals.Contains(Signal.IR_ADDR_OUT))
            bus.Load(Convert.ToByte(value & 0x0F));
    }

    public override void Latch(Bus bus, Signal[] signals)
    {
        if(signals.Contains(Signal.IR_LOAD))
            base.Latch(bus, signals);
    }

    public byte DriveOpcodeToControlUnit()
    {
        return  (byte) (value & 0xFF);
    }
}