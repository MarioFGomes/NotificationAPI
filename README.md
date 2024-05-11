# Notification API

Notification API  é uma aplicação para facilitar o envio de Email e SMS usando os serviços da SendGrid e da Twillo

## Instalação e Configuração

### Pré-requisitos
- **.NET SDK**: Certifique-se de ter o .NET SDK instalado em sua máquina.
- **API Keys**: Você precisará das chaves de API da SendGrid e Twilio para autenticar as chamadas.

### Instalação
1. Clone o repositório.
2. Configure as chaves de API da SendGrid e Twilio no arquivo de configuração.
3. Instale o PostgreSQL e muda a connectionString no arquivo de configuração
4. Execute `dotnet build` para compilar o projeto.

### Docker
1. Instale o Docker Desktop
2. Clone o repositório
2. Execute `Docker compose up`

## Uso

### NotificationType

Pode salvar os tipos de notificação a ser envidas pela a sua aplicação 

#### Endpoint
`POST /api/email/send`

#### Parâmetros de Requisição
- `to`: Endereço de e-mail do destinatário.
- `subject`: Assunto do e-mail.
- `body`: Corpo do e-mail.

#### Exemplo de Requisição
```json
{
  "to": "destinatario@example.com",
  "subject": "Assunto da Notificação",
  "body": "Conteúdo da Notificação por E-mail"
}




![Alt text](NotificationSwagger-1.jpg)

![Alt text](<Diagrama NotificationAPI-1.jpg>)