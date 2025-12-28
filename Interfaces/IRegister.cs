namespace sap1_emulator.Interfaces;
using Signals;

public interface IRegister
{
    public void Drive(Bus bus, Signal[]  signals);
    public void Latch(Bus bus, Signal[]  signals);
}