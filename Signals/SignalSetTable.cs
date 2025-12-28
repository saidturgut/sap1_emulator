namespace sap1_emulator.Signals;

public class SignalSetTable
{
    public readonly Dictionary<string, Signal[]> Table = new()
    {
        // IDENTIFY INSTRUCTION
        { "0_0", [Signal.PC_OUT, Signal.MAR_LOAD] },
        { "0_1", [Signal.RAM_OUT, Signal.IR_LOAD, Signal.PC_INC] },
        { "0_2", [Signal.IR_ADDR_OUT, Signal.MAR_LOAD] },
        
        // LDA x0
        { "0_3", [Signal.RAM_OUT, Signal.A_LOAD] },
        { "0_4", [Signal.None] },
        
        // ADD x1
        { "1_3", [Signal.RAM_OUT, Signal.B_LOAD] },
        { "1_4", [Signal.ALU_ADD, Signal.ALU_OUT, Signal.A_LOAD] },
        
        // SUB x2
        { "2_3", [Signal.RAM_OUT, Signal.B_LOAD] },
        { "2_4", [Signal.ALU_SUB, Signal.ALU_OUT, Signal.A_LOAD] },
        
        // JMP x3
        { "3_3", [Signal.RAM_OUT, Signal.PC_LOAD] },
        { "3_4", [Signal.None] },
        
        // OUT xE
        { "E_3", [Signal.A_OUT, Signal.PRINT] },
        { "E_4", [Signal.None] },
        
        // HLT xF
        { "F_3", [Signal.None] },
        { "F_4", [Signal.HLT] },
    };
}