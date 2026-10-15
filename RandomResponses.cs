using System;
using System.Collections.Generic;

namespace LUMI_Cyber_Nexus
{
    internal class RandomResponses
    {
        private Random random =
            new Random();

        private List<string> phishingTips =
            new List<string>()
            {
                "Always verify email addresses.",
                "Never click suspicious links.",
                "Avoid downloading unexpected attachments.",
                "Enable two-factor authentication.",
                "Be cautious of urgent requests."
            };

        public string GetRandomPhishingTip()
        {
            return phishingTips[
                random.Next(phishingTips.Count)];
        }
    }
}