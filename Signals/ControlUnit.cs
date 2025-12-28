namespace sap1_emulator.Signals;

public class ControlUnit : SignalSetTable
{
    private byte TimeRegister; // small register in control unit
    
    public Signal[] SignalSet(byte opcode)
    {
        string opc = TimeRegister > 2 ? 
            Convert.ToString(opcode, 16).ToUpper() : "0";
        
        return Table[$"{opc}_{TimeRegister}"];
    }
    
    public void Advance()
    {
        TimeRegister++;
        if (TimeRegister > 2) TimeRegister = 0;
    }
}