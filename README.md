# Connecta Agenda

## Integrantes do projeto: Gustavo José Rosa, Thomas Taiga Nagawa


Este projeto visa desenvolver um Sistema Gerenciador de Agenda Eletrônica para facilitar o controle e organização de estabelecimentos de saúde. O sistema é destinado a três tipos principais de usuários: Dono do Estabelecimento, Profissional Vinculado e Cliente do Estabelecimento.

## 1. Dono do Estabelecimento
### 1.1 Cadastros
- **Profissionais:** Permite ao dono cadastrar profissionais associados ao estabelecimento.
- **Clientes:** Facilita o registro e gerenciamento de clientes vinculados ao estabelecimento.
- **Planos de Saúde:** Possibilita a inclusão e gestão de diferentes planos de saúde.
- **Serviços:** Permite o cadastro e atualização dos serviços oferecidos no estabelecimento.

### 1.2 Visualizações
- **Profissionais e Pacientes:** Fornece uma visão geral dos profissionais e pacientes cadastrados no estabelecimento.
- **Agendamentos:** Permite ao dono criar agendamentos, visualizar os agendamentos do dia e gerenciar cargos no sistema.

## 2. Profissional Vinculado
### 2.1 Cadastros
- **Pacientes:** Permite ao profissional cadastrar novos pacientes associados ao seu atendimento.
- **Terapias:** Facilita o registro e controle das terapias realizadas pelo profissional.

### 2.2 Agendamentos
- **Criar Agendamentos:** Permite que o profissional crie agendamentos exclusivos com seus pacientes.
- **Visualizar Agendamentos:** Possibilita a visualização dos agendamentos do profissional para um melhor gerenciamento.

### 2.3 Visualizações e Filtragem
- **Visualizar Pacientes:** Permite ao profissional visualizar e filtrar os pacientes por nome, documentos e planos de saúde, otimizando o atendimento.

## 3. Cliente do Estabelecimento
- **Agendamentos:** Permite que o cliente agende consultas de acordo com a disponibilidade dos profissionais.
- **Visualização de Dados:** Oferece aos clientes a capacidade de visualizar seus próprios dados cadastrados no sistema.
- **Confirmação do Agendamento:** Permite aos clientes confirmarem seus agendamentos.

Este sistema busca proporcionar uma gestão eficiente da agenda eletrônica, melhorando a experiência tanto para os profissionais quanto para os clientes, garantindo um ambiente organizado e facilitando o atendimento no estabelecimento.

#Tecnologias
Front-end: Angular
Back-end: .Net
Banco: SQL

#Como usar:
- Ter o sdk do .net 8 instalado
- Dar o comando update-database no console de pacotes nuget para criar o banco
- Dar o insert (Logo a baixo), para ter um usuario criado no sistema
- Rodar o projeto
- Login: gjose2980@gmail.com
- Senha: teste

#Insert:
INSERT INTO `user` VALUES ('eaafdb55-ad79-4dfe-88cf-0b3739158753','gustavo','gjose2980@gmail.com','46070d4bf934fb0d4b06d9e2c46e346944e322444900a435d7d9a95e6d7435f5','4242','BETONEIRA','2024-04-11 00:23:32.691000',1,1,NULL,'teste','2024-04-11 00:23:32.691000','2024-04-11 00:23:32.691000',NULL,NULL,'4242','432','d');

INSERT INTO `address` VALUES ('teste','das','ds','ds','fs','fs','fs','fs',0,NULL,'2024-04-10 21:39:58.000000',NULL,'2024-04-10 21:39:58.000000','ds','ds');

INSERT INTO `company` VALUES ('EMPRESATESTE','Teste Company','teste@example.com',1,_binary 'image.jpg','1234567890','teste','eaafdb55-ad79-4dfe-88cf-0b3739158753','eaafdb55-ad79-4dfe-88cf-0b3739158753','2024-05-20 20:13:19.000000','eaafdb55-ad79-4dfe-88cf-0b3739158753','2024-05-20 20:13:19.000000','12345678000100');

INSERT INTO `usercompany` VALUES ('RELACIOMENTOTESTE','eaafdb55-ad79-4dfe-88cf-0b3739158753','EMPRESATESTE',1,'eaafdb55-ad79-4dfe-88cf-0b3739158753','2024-05-20 12:34:56.000000','eaafdb55-ad79-4dfe-88cf-0b3739158753','2024-05-20 12:00:00.000000');

INSERT INTO `role` VALUES ('Admin','Admin','Administrator role with full permissions','READ,WRITE,DELETE',1,'EMPRESATESTE','eaafdb55-ad79-4dfe-88cf-0b3739158753','2024-05-20 12:34:56.000000','eaafdb55-ad79-4dfe-88cf-0b3739158753','2024-05-20 12:00:00.000000'),('Cliente','Cliente','Cliente PadrÃ£o','READ',1,'EMPRESATESTE','eaafdb55-ad79-4dfe-88cf-0b3739158753','2024-05-20 12:34:56.000000','eaafdb55-ad79-4dfe-88cf-0b3739158753','2024-05-20 12:00:00.000000');


