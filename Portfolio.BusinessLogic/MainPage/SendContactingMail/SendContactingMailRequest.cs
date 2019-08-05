using Portfolio.Core.LogicAbstractions;

namespace Portfolio.BusinessLogic.MainPage.SendContactingMail
{
    public class SendContactingMailRequest : ILogicRequest<SendContactingMailResult>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Details { get; set; }
    }
}
