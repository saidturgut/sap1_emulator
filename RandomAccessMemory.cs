namespace sap1_emulator;
using Registers;
using Signals;
using External;

public class RandomAccessMemory
{
    private byte[] Memory = new byte[0x10];
    
    private MemoryAddressRegister? MemoryAddressRegister;
    
    public void Init(MemoryAddressRegister memoryAddressRegister)
    {
        Memory = Assembler.Assemble("Example.sap");

        for (int i = 0; i < 16; i++)
        {
            Console.WriteLine($"{i} -> {Convert.ToString(Memory[i], 2).PadLeft(8, '0')}");
        }

        MemoryAddressRegister = memoryAddressRegister;
    }
    
    public void Drive(Bus bus, Signal[] signals)
    {
        if (signals.Contains(Signal.RAM_OUT))
            bus.Load(Memory[MemoryAddressRegister!.DriveToRam()]);
    }
}