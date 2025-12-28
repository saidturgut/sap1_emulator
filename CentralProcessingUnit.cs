using sap1_emulator.External;

namespace sap1_emulator;
using Registers;
using Signals;

public class CentralProcessingUnit
{    
    private readonly Bus Bus = new Bus();
    
    private readonly RandomAccessMemory RandomAccessMemory = new RandomAccessMemory();
    
    private readonly ControlUnit ControlUnit = new ControlUnit();
    private readonly ArithmeticLogicUnit ArithmeticLogicUnit = new ArithmeticLogicUnit();
    
    private readonly ProgramCounter ProgramCounter = new ProgramCounter();
    private readonly ARegister ARegister = new ARegister();
    private readonly BRegister BRegister = new BRegister();
    private readonly MemoryAddressRegister MemoryAddressRegister = new MemoryAddressRegister();
    private readonly InstructionRegister InstructionRegister = new InstructionRegister();
    
    public void Init()
    {
        RandomAccessMemory.Init
            (MemoryAddressRegister);
        
        Tick();
    }
    
    private void Tick()
    {
        Bus.Clear();
        
        Signal[] signals = 
            ControlUnit.SignalSet
                (InstructionRegister.DriveToControlUnit());
        
        ArithmeticLogicUnit.Compute
            (ARegister, BRegister, signals);
        
        Drive(signals);

        Latch(signals);
        
        ControlUnit.Tick();
        
        if (Flags.DebugMode) Console.WriteLine("********");
        
        if(signals.Contains(Signal.PRINT)) Console.WriteLine($"\nOUTPUT : {Bus.Output()}\n");
        
        if (!signals.Contains(Signal.HLT)) Tick();
    }

    private void Drive(Signal[] signals)
    {
        ProgramCounter.Drive(Bus, signals);
        RandomAccessMemory.Drive(Bus, signals);
        InstructionRegister.Drive(Bus, signals);
        ARegister.Drive(Bus, signals);
        ArithmeticLogicUnit.Drive(Bus, signals);
    }

    private void Latch(Signal[] signals)
    {
        ProgramCounter.Latch(Bus, signals);
        MemoryAddressRegister.Latch(Bus, signals);
        InstructionRegister.Latch(Bus, signals);
        ARegister.Latch(Bus, signals);
        BRegister.Latch(Bus, signals);
    }
}