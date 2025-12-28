namespace sap1_emulator.Signals;

public enum Signal
{
    None,
        
    PC_OUT,
    PC_LOAD,
    PC_INC,
        
    MAR_LOAD,
    RAM_OUT,
        
    IR_ADDR_OUT,
    IR_LOAD,
        
    A_OUT,
    A_LOAD,
        
    B_LOAD,
        
    ALU_OUT,
    ALU_ADD,
    ALU_SUB,
        
    PRINT,
        
    HLT,
}