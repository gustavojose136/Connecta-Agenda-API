using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models.FilterModels;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.AddModels;
using Connect_agenda_models.Models.Utils;

namespace Connect_agenda_services.Services
{
    public class ScheduleService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProfissinalServiceRepository _profissinalServiceRepository;
        private readonly IUserCompanyRepository _userCompanyRepository;
        private readonly SendEmailService _sendEmailService;

        public ScheduleService(IUserRepository userRepository, IOrderRepository orderRepository, IProfissinalServiceRepository profissinalServiceRepository, SendEmailService sendEmailService, IUserCompanyRepository userCompanyRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _profissinalServiceRepository = profissinalServiceRepository;
            _sendEmailService = sendEmailService;
            _userCompanyRepository = userCompanyRepository;
        }

        public async Task<List<calendarEventsModel>> getAll(OrderFilterModel filter, string companyId)
        {
            try
            {
                filter.CompanyId = companyId;

                var orders = await _orderRepository.GetOrderByFilter(filter);

                return TratamentCallendar(orders);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderModel> CreateSchedule(OrderAddModel orderAdd, string companyId, string userCreateId)
        {
            try
            {
                var havSchedule = await HaveAnyScheduleForProfissional(orderAdd.ProfissionalServiceId, orderAdd.StartDate, orderAdd.EndDate);

                if (havSchedule)
                    throw new Exception("Já existe um agendamento para este profissional neste horário, por favor escolha outro horário.");

                var client = await _userRepository.GetUserById(orderAdd.ClientId);

                OrderModel order = new OrderModel();

                order.ProfissionalServiceId = orderAdd.ProfissionalServiceId;
                order.ClientId = orderAdd.ClientId;
                order.CompanyId = companyId;
                order.Observation = orderAdd.Observation;
                order.Status = orderAdd.Status;
                order.StartDate = orderAdd.StartDate;
                order.EndDate = orderAdd.EndDate;
                order.paymentMethod = orderAdd.paymentMethod;
                order.PlanCardId = orderAdd.PlanCardId;
                order.Price = orderAdd.Price;
                order.Discont = orderAdd.Discont ?? 0;
                order.IsPaid = orderAdd.IsPaid;
                order.IsPlanCoop = orderAdd.IsPlanCoop;
                order.PricePlanCoop = orderAdd.PricePlanCoop;
                order.UserUpdateId = userCreateId;
                order.UpdateDate = DateTime.Now;
                order.UserCreateId = userCreateId;
                order.CreateDate = DateTime.Now;

                await _orderRepository.Post(order);

                await SendConfirmationEmail(order, client.Email);

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Método para verificar se já existe um agendamento para o profissional no horário escolhido
        // Adicoinar Regra para pegar a configuração de horário do profissional
        public async Task<bool> HaveAnyScheduleForProfissional(string profissinalId, DateTime startDate, DateTime? endDate)
        {
            try
            {
                var profissional = await _profissinalServiceRepository.GetById(profissinalId);

                if (profissional == null)
                    throw new Exception("Profissional não encontrado.");

                var tempoAtendimento = profissional.Duration ?? 60;


                OrderFilterModel filter = new OrderFilterModel();
                filter.ProfissionalServiceId = profissinalId;
                filter.StartDate = startDate.AddDays(-tempoAtendimento);
                filter.EndDate = endDate ?? DateTime.Now;

                var orders = await _orderRepository.GetOrderByFilter(filter);

                return orders.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //Area para o tratamento de dados pra o agendamento
        public List<calendarEventsModel> TratamentCallendar(List<OrderModel> orders)
        {
            List<calendarEventsModel> ListaAgendamentos = new List<calendarEventsModel>();

            foreach (var order in orders)
            {
                calendarEventsModel agendamento = new calendarEventsModel();

                agendamento.Id = order.Id;
                agendamento.Title = order.Observation;
                agendamento.Start = order.StartDate;
                agendamento.End = order.EndDate;
                agendamento.OrderItem = order;
                agendamento.ClassName = "bg-info text-white";

                ListaAgendamentos.Add(agendamento);
            }

            return ListaAgendamentos;
        }

        private async Task SendConfirmationEmail(OrderModel order, string clientEmail)
        {
            try
            {
                EmailModel email = new EmailModel();
                email.Assunto = $"Agendamento Criado para o dia {order.StartDate}";
                email.Emails = clientEmail;
                email.Body = @$"<!DOCTYPE html>
                        <html lang=""en"">
                        <head>
                          <meta charset=""UTF-8"">
                          <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                          <title>Confirmação de Agendamento</title>
                          <style>
                            body {{
                              font-family: Arial, sans-serif;
                              background-color: #f4f4f4;
                              margin: 0;
                              padding: 0;
                            }}
                            .container {{
                              max-width: 600px;
                              margin: 20px auto;
                              background-color: #ffffff;
                              padding: 20px;
                              border-radius: 8px;
                              box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                            }}
                            .header {{
                              background-color: #4CAF50;
                              color: white;
                              padding: 10px 0;
                              text-align: center;
                              border-radius: 8px 8px 0 0;
                            }}
                            .content {{
                              margin: 20px 0;
                            }}
                            .footer {{
                              text-align: center;
                              color: #777;
                              margin-top: 20px;
                            }}
                            .button {{
                              display: inline-block;
                              padding: 10px 20px;
                              margin-top: 20px;
                              background-color: #4CAF50;
                              color: white;
                              text-decoration: none;
                              border-radius: 5px;
                            }}
                          </style>
                        </head>
                        <body>
                          <div class=""container"">
                            <div class=""header"">
                              <h1>Confirmação de Agendamento</h1>
                            </div>
                            <div class=""content"">
                              <p>Olá,</p>
                              <p>Seu agendamento foi criado com sucesso. Aqui estão os detalhes do seu agendamento:</p>
                              <ul>
                                <li><strong>Profissional:</strong> {order.ProfissionalServiceId}</li>
                                <li><strong>Data e Hora de Início:</strong> {order.StartDate}</li>
                                <li><strong>Data e Hora de Término:</strong> {order.EndDate}</li>
                                <li><strong>Observação:</strong> {order.Observation}</li>
                                <li><strong>Status:</strong> {order.Status}</li>
                              </ul>
                              <a href=""#"" class=""button"">Ver detalhes</a>
                            </div>
                            <div class=""footer"">
                              <p>&copy; {DateTime.Now.Year} Connecta. Todos os direitos reservados.</p>
                            </div>
                          </div>
                        </body>
                        </html>
                        ";


                // Exemplo de envio fictício:
                await _sendEmailService.PostEmail(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar o e-mail de confirmação.", ex);
            }
        }
    }
}
