using System;
using System.Windows.Forms;

namespace LUMI_Cyber_Nexus
{
    public partial class Form1 : Form
    {
        private ChatResponses chatResponses =
            new ChatResponses();

        private RandomResponses randomResponses =
            new RandomResponses();

        private MemoryManager memory =
            new MemoryManager();

        private SentimentAnalyzer sentiment =
            new SentimentAnalyzer();

        public Form1()
        {
            InitializeComponent();

            rtbChat.AppendText(
                "LUMI: Welcome to LUMI Cyber Nexus!" +
                Environment.NewLine +
                "Ask me about cybersecurity, phishing, ransomware, malware, VPNs, privacy, scams and password safety." +
                Environment.NewLine +
                Environment.NewLine);
        }

        private void Form1_Load(
            object sender,
            EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtUserInput_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void btnSend_Click(
            object sender,
            EventArgs e)
        {
            string question =
                txtUserInput.Text
                .ToLower()
                .Trim();

            if (string.IsNullOrEmpty(question))
                return;

            rtbChat.AppendText(
                "You: " +
                question +
                Environment.NewLine);

            AsyncLogger.Log(
                "User",
                question);

            string response = "";

            // Memory Feature
            if (question.Contains("my favourite topic is"))
            {
                memory.FavouriteTopic =
                    question.Replace(
                    "my favourite topic is",
                    "")
                    .Trim();

                response =
                    "I will remember that your favourite topic is " +
                    memory.FavouriteTopic + ".";
            }

            else if (question.Contains("what is my favourite topic"))
            {
                response =
                    "Your favourite topic is " +
                    memory.FavouriteTopic + ".";
            }

            // Random Phishing Tip
            else if (question.Contains("phishing tip"))
            {
                response =
                    randomResponses.GetRandomPhishingTip();

                memory.LastTopic =
                    "phishing";
            }

            // Conversation Flow
            else if (question.Contains("tell me more"))
            {
                switch (memory.LastTopic)
                {
                    case "phishing":

                        response =
                            "Phishing attacks often use fake websites and emails pretending to be trusted organisations.";

                        break;

                    case "ransomware":

                        response =
                            "Ransomware encrypts files and requires payment before access is restored.";

                        break;

                    case "vpn":

                        response =
                            "VPNs encrypt internet traffic and help protect online privacy.";

                        break;

                    default:

                        response =
                            "Please ask me about a cybersecurity topic first.";

                        break;
                }
            }

            // Sentiment Detection
            else
            {
                string mood =
                    sentiment.Analyze(question);

                if (mood == "positive")
                {
                    response =
                        "That's wonderful to hear!";
                }
                else if (mood == "negative")
                {
                    response =
                        "I'm sorry you're feeling that way.";
                }
            }

            // Dictionary Responses
            if (string.IsNullOrEmpty(response))
            {
                foreach (var item in chatResponses.Responses)
                {
                    if (question.Contains(item.Key))
                    {
                        response =
                            item.Value;

                        memory.LastTopic =
                            item.Key;

                        break;
                    }
                }
            }

            // Default Response
            if (string.IsNullOrEmpty(response))
            {
                response =
                    "I don't understand. Try asking about phishing, ransomware, malware, VPNs, privacy or password safety.";
            }

            rtbChat.AppendText(
                "LUMI: " +
                response +
                Environment.NewLine +
                Environment.NewLine);

            AsyncLogger.Log(
                "LUMI",
                response);

            txtUserInput.Clear();
            txtUserInput.Focus();
        }
    }
}