// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.22.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
//importacoes do bot
namespace EchoBot1.Bots
// namespace conjunto de classes
{
    public class EchoBot : ActivityHandler
    // classe publica EchoBot que extende ActivityHandler
    {
        List<string> messageIds = new List<string>();
        // lista de strings com o nome de messageIds e depois instancia uma nova lista vazia
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        // classe que so pode ser acessada dentro desse codigo que sobrescreve o metodo OnMessageActivityAsync
        // Task indica que o metodo retornara um obj Task que representa uma operacao assincrona
        // IMessageActivity é um tipo generico
        // ITurnContext é uma interface que recebe o tipo generico
        // turnContext objeto de contexto da conversa
        // CancellationToken Obj que indica que a tarefa deve ser cancelada ou aguardar
        {
            var replyText = $"Echo: {turnContext.Activity.Text}";
            //var messageActivities = await turnContext.Activity.Get;
            //var reply = Activity.CreateMessageActivity();
            var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // await aguarda a conclusão da tarefa
            // turnContext objeto de contexto da conversa
            // SendActivityAsync envia uma mensagem
            // cancellationToken token de cancelamento
            
            if (turnContext.Activity.Text == "data")
            {
                //var teste = await turnContext.SendActivityAsync(MessageFactory.Text(test, test), cancellationToken);
                //var teste_str = teste.ToString();
                await turnContext.SendActivityAsync(MessageFactory.Text(date), cancellationToken);
            }
            else if (turnContext.Activity.Text == "showid")
            {
                foreach (var id in messageIds)
                    {
                        await turnContext.SendActivityAsync(MessageFactory.Text(id));
                    }
            }
            else if (turnContext.Activity.Text == "criar_os")
            {
                await turnContext.SendActivityAsync(MessageFactory.Text("Criando ordem de serviço..."));
            }
            else if (turnContext.Activity.Text == "listar_os")
            {
                await turnContext.SendActivityAsync(MessageFactory.Text("Listando ordens de serviço..."));
            }
            else if (turnContext.Activity.Text == "editar_os")
            {
                await turnContext.SendActivityAsync(MessageFactory.Text("Editando ordem de serviço..."));
            }
            else
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
            }
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {

            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var welcome_text = MessageFactory.Text("Bem vindo, o que deseja fazer?: ");
                    welcome_text.SuggestedActions = new SuggestedActions(){
                        Actions = new List<CardAction>() {
                            new CardAction() { Title = "Criar OS", Type = ActionTypes.ImBack, Value = "criar_os" },
                            new CardAction() { Title = "Listar OS", Type = ActionTypes.ImBack, Value = "listar_os" },
                            new CardAction() { Title = "Editar OS", Type = ActionTypes.ImBack, Value = "editar_os" },
                        },
                    };
                    await turnContext.SendActivityAsync(welcome_text, cancellationToken);
                }
            }
        }
    }
}
