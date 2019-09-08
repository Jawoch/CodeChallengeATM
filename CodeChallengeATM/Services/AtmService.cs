using System;
using System.Collections.Generic;
using CodeChallengeATM.Exceptions;
using CodeChallengeATM.Models;
using CodeChallengeATM.Shared;

namespace CodeChallengeATM.Services
{
    public class AtmService : IAtmService

    {
        public void GetNotes(InputForm inputForm)
        {
            var results = new List<decimal>();

            if (!IsValidInput(inputForm.ImputedAmount)) return;
            CalculateBills(inputForm.ImputedAmount, ref results);
            FillUpWithZeros(ref results);
            inputForm.Results = results;
        }
        private static void FillUpWithZeros(ref List<decimal> results)
        {
            while (Constants.Denominations.Length - results.Count != 0)
                results.Add(0);
        }


        private static bool IsValidInput(decimal input)
        {
            if (input < 0)
                throw new InvalidArgumentException("Provided amount is invalid please provide new amount");

            if (input % 10 != 0)
                throw new NoteUnavailableException("Note Unavailable, lowest available note is 10 $");

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