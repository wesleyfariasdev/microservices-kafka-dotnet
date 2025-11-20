# 1 - Api de entrada

- Envio para o Apache Kafka -> Solicitação de Publicação
- Data de entrada
- Nome da pessoa que deu entrada
- Salva no Banco de dados MongoDb

# 2 - Consumer Services

- Consome Mensagem vinda do Tópico Kafka -> Solicitação de Publicação
- Processa Livro
  - Apto a doação
  - Venda
  - Empréstimo
- Data de Processamento
- Pública no Tópico Kafka -> Livro Processado
- Salva no Banco de dados MongoDb

# 3 - Api de biblioteca

- Consome da Livro Processado
- Solicitação de ação sobre o livro (Compra, Empréstimo, Doação)
- Solicitação de prolongamento de empréstimo

# 4 - Serviço de notificação

- Notifica pessoa que está adquirindo o livro
- Se for empréstimo vai ser enviado uma data de devolução estimada
- O usuário pode solicitar prolongamento da data
- Se for compra ou doação vai enviar a data de retirada na loja
- Envio do endereço
- Protocolo de retirada
- Envio de todas as infos do livro
