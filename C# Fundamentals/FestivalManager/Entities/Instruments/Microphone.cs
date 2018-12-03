namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int MicRepairAmount = 80;
        protected override int RepairAmount => MicRepairAmount;
    }
}
