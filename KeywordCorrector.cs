namespace CybersecurityAwarenessBot
{
    public static class KeywordCorrector
    {
        // Dictionary mapping misspelled cybersecurity terms to correct keywords
        private static readonly Dictionary<string, string> KeywordCorrections = new Dictionary<string, string>
        {
            // Password-related misspellings
            { "passwrd", "password" },
            { "pasword", "password" },
            { "pawssword", "password" },
            { "pssword", "password" },
            { "passwo", "password" },
            { "paswrd", "password" },
            { "paswoord", "password" },

            // Malware-related misspellings
            { "malaware", "malware" },
            { "malwar", "malware" },
            { "malwere", "malware" },
            { "mallware", "malware" },

            // Virus-related misspellings
            { "vyrus", "virus" },
            { "virrus", "virus" },
            { "viras", "virus" },

            // Safe Browsing-related misspellings
            { "safebrowsing", "safe browsing" },
            { "safe-browsing", "safe browsing" },
            { "saafe browsing", "safe browsing" },
            { "safe browsng", "safe browsing" },
            { "sfe browsing", "safe browsing" },

            // Phishing-related misspellings
            { "phshing", "phishing" },
            { "phisihng", "phishing" },
            { "phihsing", "phishing" },
            { "phising", "phishing" }
        };

        public static string CorrectKeyword(string input)
        {
            return KeywordCorrections.ContainsKey(input) ? KeywordCorrections[input] : input;
        }
    }
}
