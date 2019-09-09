using System;
using System.Collections.Generic;
using CodeChallengeATM.Exceptions;
using CodeChallengeATM.Models;
using CodeChallengeATM.Shared;

namespace CodeChallengeATM.Services
{
    public class AtmService : IAtmService

    {
        public List<decimal> GetNotes(InputForm inputForm)
        {
            if (inputForm.ImputedAmount == null || !IsValidInput(inputForm.ImputedAmount))
                return new List<decimal>();

            var results = new List<decimal>();

            CalculateBills((decimal)inputForm.ImputedAmount, ref results);
            FillUpWithZeros(ref results);
            return results;
        }
        private static void FillUpWithZeros(ref List<decimal> results)
        {
            while (Constants.Denominations.Length - results.Count != 0)
                results.Add(0);
        }


        private static bool IsValidInput(decimal? input)
        {
            if (input == null || input < 0)
                throw new InvalidArgumentException(Constants.ProvideNewAmountException);

            if (input % 10 != 0)
                throw new NoteUnavailableException(Constants.AvailableNoteIsException);

            return true;
        }


        private static void CalculateBills(decimal requestedAmount, ref List<decimal> result)
        {
            var denomination = Constants.Denominations[result.Count];

            result.Add(Math.Truncate(requestedAmount / denomination));
            var rest = requestedAmount % denomination;

            if (rest >= 10)
                CalculateBills(rest, ref result);
        }
    }
}