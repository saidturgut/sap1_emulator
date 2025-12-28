using System.Security.Cryptography;

namespace sap1_emulator.External;

public static class Assembler
{
    private static Dictionary<string, string> OpcodeTable = new()
    {
        { "LDA", "0" },
        { "ADD", "1" },
        { "SUB", "2" },
        { "JMP", "3" },
        { "OUT", "E" },
        { "HLT", "F" },
    };
    
    public static byte[] Assemble(string programName)
    {
        string[] raw = File.ReadAllText(programName).Split('\n').
            Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

        byte[] output = new byte[0x10];
        
        for (int i = 0; i < raw.Length; i++)
        {
            string[] instruction =  raw[i].Split(' ').
                Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            if (OpcodeTable.ContainsKey(instruction[0]))
            {
                byte address = instruction.Length > 1 ? Hex(instruction[1]) : byte.MinValue;
                
                output[i] = Convert.ToByte((Hex(OpcodeTable[instruction[0]]) << 4) | address);
            }
            else
            {
                output[Hex(instruction[0])] = Hex(instruction[1]);
            }
        }
        
        return output;
    }

    private static byte Hex(string input)
    {
        return Convert.ToByte(input, 16);
    }
}