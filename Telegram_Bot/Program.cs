using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace Telegram_Bot
{

    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5244596233:AAH3Zvws_1caJb8Inc02dKoUnTxRZrMJ7UM");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать, ещё не погасшая душа, что тебя интересует?");
                    return;
                }

                if (message.Text.ToLower() == "/info")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Что? Тебе нужна информация? А, впрочем, не важно.. Я ещё в процессе разработки, понажимай на кнопки, а там уже все сам поймёшь, короче да..");
                    return;
                }

                if (message.Text.Contains("Как дела?"))
                {
                    await botClient.SendTextMessageAsync(message.Chat, "В отличии от тебя я просто программный код, поэтому у меня всё отлично. А ты как поживаешь? На самом деле это было из вежливости, давай перейдём ближе к сути");
                    return;
                }

                if (message.Text.Contains("Кристина"))
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Самая лучшая девочка на свете, @yremistake очень её любит! <3");
                    return;
                }

                if (message.Text.Contains("photo"))
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Вау, какая классная фотка!");
                    return;
                }

                await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
                
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}