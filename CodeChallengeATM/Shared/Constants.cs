namespace CodeChallengeATM.Shared
{
    public class Constants
    {
        public static readonly int[] Denominations = { 100, 50, 20, 10 };
        public const string AvailableNoteIsException = "Note Unavailable, lowest available note is 10 $";
        public const string  ProvideNewAmountException = "Provided amount is invalid please provide new amount";
    }
}
