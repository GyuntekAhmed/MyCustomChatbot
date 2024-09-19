using System.Windows;

namespace ChatbotAppDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly DatabaseHelper _databaseHelper;

		public MainWindow(DatabaseHelper databaseHelper)
		{
			InitializeComponent();
			_databaseHelper = databaseHelper;
		}

		private void sendBtn_Click(object sender, RoutedEventArgs e)
		{
			string userMessage = UserMessageTextBox.Text;

			var faqs = _databaseHelper.GetFAQs();

			var (Question, Answer) = faqs.FirstOrDefault(f => f.Question == userMessage);
			var question = Question;
			var answer = Answer;

			BotResponseTextBox.Text = answer;
		}

		private void canlcelBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}