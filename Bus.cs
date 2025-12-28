namespace sap1_emulator;

public class Bus
{
    private byte value;
    
    private bool driven;
    
    public void Clear()
    {
        driven = false;
    }
    
    public void Load(byte input)
    {
        if (driven) 
            throw new Exception("Bus contention!");
        
        driven = true;
        value = input;
    }

    public byte Output()
    {
        return value;
    }
}