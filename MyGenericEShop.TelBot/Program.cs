#region First project
/*
using Telegram.Bot;
using Telegram.Bot.Extensions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("7712959982:AAGMmr7QYV9uBLsc2DAtt_TbvkCCxfpmGjw", cancellationToken: cts.Token);
var me = await bot.GetMe();
bot.OnMessage += OnMessage;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadKey();
cts.Cancel(); // stop the bot

// method that handle messages received by the bot:
async Task OnMessage(Message msg, UpdateType type)
{
	if (msg.Text is null) return;   // we only handle Text messages here


	Console.WriteLine($"Received {type} '{msg.Text}' in {msg.Chat}");
	// let's echo back received text in the chat
	await bot.SendMessage(msg.Chat, $"{msg.From} said: {msg.Text}");

}
*/
#endregion


#region Second Project


using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("The token of telegram bot", cancellationToken: cts.Token);
var me = await bot.GetMe();
bot.OnError += OnErrorAsync;
bot.OnMessage += OnMessageAsync;
bot.OnUpdate += OnUpdateAsync;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadKey();
cts.Cancel(); // stop the bot

// method to handle errors in polling or in your OnMessage/OnUpdate code
async Task OnErrorAsync(Exception exception, HandleErrorSource source)
{
	Console.WriteLine(exception); // just dump the exception to the console
}

// method that handle messages received by the bot:
async Task OnMessageAsync(Message msg, UpdateType type)
{
	if (msg.Text == "/start")
	{
		await bot.SendMessage(msg.Chat, "Welcome! Pick one direction",
			replyMarkup: new InlineKeyboardButton[] { "Left", "Right" });
	}
	if (msg.Text == "/Give")
	{
		await bot.SendMessage(msg.Chat.Id, "Choose an action:",
			replyMarkup: new ReplyKeyboardMarkup(new[]
			{
		new[] { new KeyboardButton("📷 Send Photo"), new KeyboardButton("📍 Send Location") },
		new[] { new KeyboardButton("❌ Cancel") }
			})
			{
				ResizeKeyboard = true
			});
	}
}

// method that handle other types of updates received by the bot:
async Task OnUpdateAsync(Update update)
{
	if (update is { CallbackQuery: { } query }) // non-null CallbackQuery
	{
		await bot.AnswerCallbackQuery(query.Id, $"You picked {query.Data}");
		await bot.SendMessage(query.Message!.Chat, $"User {query.From} clicked on {query.Data}");
	}
	if (update is { CallbackQuery: { } qeury })
	{
	}
}


#endregion
