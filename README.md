# Arquitetura Geral

Os serviços são totalmente desacoplados e **não se comunicam diretamente**.  
Toda troca de informações ocorre por meio de **tópicos no Apache Kafka**, seguindo o padrão **Event-Driven Architecture**.

Principais características:

- Cada serviço é independente e não conhece os outros.
- Comunicação exclusivamente assíncrona via eventos.
- Cada serviço possui sua própria infraestrutura interna.
- Todos utilizam o mesmo MongoDB, porém **a arquitetura prevê separação futura por bases independentes** (melhor prática em microserviços).

---

# 1. API de Entrada

Funcionalidade:
- Recebe solicitações de publicação de livros.
- Publica evento `SolicitacaoPublicacao` no Kafka.

Dados enviados:
- Data de entrada  
- Nome da pessoa que deu entrada  

Persistência:
- Armazena o registro inicial no MongoDB.

---

# 2. Consumer Services (Processamento)

Funcionalidade:
- Consome o evento `SolicitacaoPublicacao`.
- Processa o livro classificando como:
  - Apto para doação  
  - Venda  
  - Empréstimo  

Ações:
- Define a data de processamento.
- Publica evento `LivroProcessado` no Kafka.
- Persiste o resultado da análise no MongoDB.

---

# 3. API de Biblioteca

Funcionalidade:
- Consome o evento `LivroProcessado`.
- Oferece endpoints para:
  - Solicitar compra  
  - Solicitar empréstimo  
  - Solicitar doação  
  - Solicitar prolongamento de empréstimo  

---

# 4. Serviço de Notificação

Funcionalidade:
- A partir dos eventos gerados pela API de Biblioteca:
  - Notifica o usuário da ação realizada.
  - Em caso de empréstimo: envia data estimada de devolução (com possibilidade de prolongamento).
  - Em caso de compra ou doação: envia data de retirada + endereço + protocolo.
  - Inclui informações completas do livro.

---

# 5. Configuração do Ambiente

Na pasta **/scripts** estão os arquivos necessários para subir toda a infraestrutura:
- Kafka + Zookeeper
- MongoDB

