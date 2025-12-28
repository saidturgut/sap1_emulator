namespace sap1_emulator.Signals;

public class ControlUnit : SignalSetTable
{
    private byte TimeRegister;
    
    public Signal[] SignalSet(byte opcode)
    {
        string opc = TimeRegister > 2 ? 
            Convert.ToString(opcode, 16).ToUpper() : "0";
        
        return Table[$"{opc}_{TimeRegister}"];
    }
    
    public void Tick()
    {
        TimeRegister++;
        if (TimeRegister > 4)
            TimeRegister = 0;
    }
}