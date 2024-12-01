using Sexual_health_platform.Data;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Sexual_health_platform
{
    public partial class ChatPage : ContentPage
    {
        public ObservableCollection<Message> Messages { get; set; }

        public ChatPage()
        {
            InitializeComponent();
            Messages = new ObservableCollection<Message>();
            ChatCollectionView.ItemsSource = Messages;
        }

        private async void OnSendMessageClicked(object sender, EventArgs e)
        {
            var userMessage = MessageEntry.Text?.Trim();
            if (string.IsNullOrWhiteSpace(userMessage)) return;

            // Add user message to the chat
            Messages.Add(new Message { Text = userMessage, IsUserMessage = true });
            MessageEntry.Text = string.Empty;

            // Process specific commands (Google Calendar and Zoom, for now just placeholder)
            if (userMessage.Contains("reserve time", StringComparison.OrdinalIgnoreCase))
            {
                Messages.Add(new Message { Text = "Time reservation feature is coming soon!", IsUserMessage = false });
            }
            else if (userMessage.Contains("zoom link", StringComparison.OrdinalIgnoreCase))
            {
                Messages.Add(new Message { Text = "Zoom link feature is coming soon!", IsUserMessage = false });
            }
            else
            {
                Messages.Add(new Message { Text = "How can I assist you further?", IsUserMessage = false });
            }
        }
    }

    public class Message
    {
        public string Text { get; set; }
        public bool IsUserMessage { get; set; }
    }
}
