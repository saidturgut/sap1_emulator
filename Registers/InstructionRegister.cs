namespace sap1_emulator.Registers;
using Signals;
using External;

public class InstructionRegister : Register
{
    public override void Drive(Bus bus, Signal[] signals)
    {
        if(signals.Contains(Signal.IR_ADDR_OUT))
            bus.Load(Convert.ToByte(value & 0x0F));
    }

    public override void Latch(Bus bus, Signal[] signals)
    {
        if(signals.Contains(Signal.IR_LOAD))
            base.Latch(bus, signals);
        
        if (!Flags.DebugMode) return;
        Console.WriteLine($"INSTRUCTION REGISTER -> {Assembler.PrintBinary(value)}");
    }

    public byte DriveToControlUnit()
    {
        return Convert.ToByte(value >> 4);
    }
}