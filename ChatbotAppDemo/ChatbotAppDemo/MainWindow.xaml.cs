using System.Windows;

namespace ChatbotAppDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void sendBtn_Click(object sender, RoutedEventArgs e)
		{
			string userMessage = UserMessageTextBox.Text;

			var faqs = new DatabaseHelper().GetFAQs();

			var (Question, Answer) = faqs.FirstOrDefault(f => f.Question == userMessage);
			var question = Question;
			var answer = Answer;

			BotResponseTextBox.Text = answer;
		}
	}
}