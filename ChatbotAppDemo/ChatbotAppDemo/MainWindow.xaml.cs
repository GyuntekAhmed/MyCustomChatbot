using System.Windows;

namespace ChatbotAppDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly DatabaseHelper _databaseHelper;
		private string userMessage = string.Empty;
		private List<string> answerList = new List<string>();
		private List<string> questionList = new List<string>();
		private List<string> faqList = new List<string>();

		public MainWindow(DatabaseHelper databaseHelper)
		{
			InitializeComponent();
			_databaseHelper = databaseHelper;
		}

		private void sendBtn_Click(object sender, RoutedEventArgs e)
		{
			userMessage = UserMessageTextBox.Text.ToLower();

			var faqs = _databaseHelper.GetFAQs();

			var (Question, Answer) = faqs.FirstOrDefault(f => f.Question.ToLower() == userMessage);
			var question = Question;
			var answer = Answer;

			if (question == null)
				answer = "Sorry, I don't understand your question.";
			
			answer ??= "Sorry, I don't have an answer for your question.";


			
			questionList.Add(question);
			answerList.Add(answer);
			int currentIndex = questionList.IndexOf(question);

			string currentMsg = $"You: {questionList[currentIndex]}\r\n Bot: {answerList[currentIndex]}";
			BotResponseTextBox.Text += currentMsg + "\r\n";
			clearMessage();


			//faqList.Add(currentMsg);

			//foreach (var msg in faqList)
			//{
			//	BotResponseTextBox.Text += msg + "\r\n";
			//}
			//BotResponseTextBox.Text = answer;
		}

		private void clearBtn_Click(object sender, RoutedEventArgs e)
		{
			BotResponseTextBox.Text = string.Empty;
		}

		private void clearMessage()
		{
			UserMessageTextBox.Text = string.Empty;
		}

		private void canlcelBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		//private void saveBtn_Click(object sender, RoutedEventArgs e)
		//{
		//	var question = UserMessageTextBox.Text;
		//	var answer = BotResponseTextBox.Text;

		//	_databaseHelper.SaveFAQ(question, answer);
		//}
	}
}