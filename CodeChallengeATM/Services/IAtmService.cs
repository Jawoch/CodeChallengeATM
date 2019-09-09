using System.Collections.Generic;
using CodeChallengeATM.Models;

namespace CodeChallengeATM.Services
{
    public interface IAtmService
    {
        List<decimal> GetNotes(InputForm inputForm);
    }
}